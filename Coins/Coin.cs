using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Threading.Channels;

namespace VendingMachineProject
{
	public abstract class Coin
	{
        protected double value; //coin name
        protected int quantity;
        protected Coin nextCoin;

        public Coin(double value, int quantity, Coin nextCoin)
        {
            this.value = value;
            this.quantity = quantity;
            this.nextCoin = nextCoin;
        }

        //getters and setters
        public void setCoinValue(double value)
        {
            this.value = value;
        }

        public double getCoinValue()
        {
            return value;
        }

        public void setCoinQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public int getCoinQuantity()
        {
            return quantity;
        }

        private double getCoinQuantity(double coinValue)
        {
            return quantity;
        }

        private void setCoinQuantity(double coinValue, double v)
        {
            this.quantity = (int)(coinValue + v);
        }


        //sets the value of the next coin
        public void SetNextCoin(Coin coin)
        {
            this.nextCoin = coin;
        }

        //abstract method implemented by other classes for the dispense function
        protected abstract void dispenseCoins(int count);


        public override string ToString()
        {
            return $"Coin: value={value}, count={quantity}";
        }

        public void PrintCoins()
        {
            Coin currentCoin = this;
            while (currentCoin != null)
            {
                Console.WriteLine(currentCoin.ToString());
                currentCoin = currentCoin.getNextCoin();
            }
        }


        //get value of total coins in system
        public double GetTotalValue()
        {
            double total = 0;
            Coin currentCoin = this;
            while (currentCoin != null)
            {
                total += currentCoin.value * currentCoin.quantity;
                currentCoin = currentCoin.nextCoin;
            }
            return total;
        }


        //to check if we can accept transaction
        public bool successfulCoinTransaction(double amount)
        {
            double remainingAmount = amount;
            Coin currentCoin = this;

            while (remainingAmount > 0 && currentCoin != null)
            {
                int count = (int)(remainingAmount / currentCoin.value);

                if (count > currentCoin.quantity)
                {
                    Console.WriteLine($"Not enough coins of £{currentCoin.value} available, checking other available coins");
                    if (currentCoin.nextCoin != null && currentCoin.nextCoin.successfulCoinTransaction(remainingAmount - currentCoin.quantity * currentCoin.value))
                    {
                        // if the next coin can perform the transaction, continue with the next coin
                        return true;
                    }
                    return false;
                }

                remainingAmount -= count * currentCoin.value;
                currentCoin = currentCoin.nextCoin;
            }

            // check if the coin dispenser has enough coins to dispense the change
            currentCoin = this;
            double changeAmount = amount - remainingAmount;
            while (changeAmount > 0 && currentCoin != null)
            {
                int count = (int)(changeAmount / currentCoin.value);

                if (count > currentCoin.quantity)
                {
                    Console.WriteLine($"Cannot perform transaction. Not enough coins of £{currentCoin.value} available to dispense the change.");
                    return false;
                }

                changeAmount -= count * currentCoin.value;
                currentCoin = currentCoin.nextCoin;
            }

            return true;
        }

        //method to dispense coins
        public void Dispense(double amount)
        {
            int count = (int)(amount / value);
            double remainder = Math.Round(amount % value, 4);


            // if coin to dispense quantity is zero call the next coin down
            if (quantity == 0 && nextCoin != null)
            {
                nextCoin.Dispense(amount);
            }

            // if coin can be used as change
            else if (count > 0 && quantity != 0)
            {
                dispenseCoins(count);

                // if coin can be used as change but we run out of current coin, call next coin
                if (remainder > 0 && nextCoin != null)
                {
                    nextCoin.Dispense(remainder);
                }
            }

            // if change is remaining call next coin
            else if (remainder >= 0 && nextCoin != null)
            {
                nextCoin.Dispense(remainder);
            }

        }


        //removes from coininventory and return coins added
        public void removeFromCoinInventory(List<double> changeCoins, Coin head)
        {

            foreach (double coins in changeCoins)
            {

                Coin coin = head;

                while (coin != null)
                {
                    //check if current coin is a coin
                    if (coin.getCoinValue() == coins)
                    {
                        int currentQuantity = coin.getCoinQuantity();

                        coin.setCoinQuantity(currentQuantity - 1);
                        
                    }

                    coin = coin.getNextCoin();

                }
            }
        }
       
        public void printCoin()
        {
            Console.WriteLine($" Coin Value: {value}  Coin Quantity: {quantity}");
        }

        public Coin getNextCoin()
        {
            return nextCoin;
        }

        //add coin to coin pool
        public bool UpdateInventory(double key, int quantity)
        {
            Coin currentCoin = this;

            while (currentCoin != null)
            {
                if (currentCoin.getCoinValue() == key)
                {
                    int currentQuantity = currentCoin.getCoinQuantity();
                    currentCoin.setCoinQuantity(currentQuantity + quantity);
                    return true;
                }
                currentCoin = currentCoin.getNextCoin();
            }

            return false;
        }

        //check for difference between sum of snack price and total amount in coin input list to return change amount 
        public double ChangeChecker(List<double> input, Snack snack)
        {
            //if statement to check if equal to

            double total = input.Sum();

            double change = total - snack.getSnackPrice();

            return change;
        }
    }
}

