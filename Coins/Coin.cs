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


        //method that gives change
        //public void ChangeToGive(double change)
        //{
        //    Coin coins = this;

        //    List<double> changeCoins = new List<double>();
        //    double[] coinsss = { 2.0, 1.0, 0.5, 0.2, 0.1, 0.05 };

        //    //meant to be the reduced change as the program progresses.
        //    //without actually touching the actual change so that
        //    //change can be used as a parameter
        //    decimal changeHolder = Convert.ToDecimal(change);

        //    while (changeHolder > 0)
        //    {
        //        //double closest = coinsss[0];

        //        List<double> coinsLessThanCoinList = new List<double>();

        //        foreach (double coin in coinsss)
        //        {
        //            //put all values less than coin in a list
        //            //if current coin needed is 0 use the next possible coins
        //            if (coin <= Convert.ToDouble(changeHolder))
        //            {
        //                //check if coin is zero before adding to list
        //                //if it is remove coin from array and use the next coin
        //                coinsLessThanCoinList.Add(coin);
        //            }
        //        }





        //        //assign the first variable as the change
        //        decimal actualChange = Convert.ToDecimal(coinsLessThanCoinList[0]);

        //        //add the first variable to list of change
        //        //if coin we need is not available then write error

        //        changeCoins.Add(Convert.ToDouble(actualChange));

        //        //minus [0] from change to update change
        //        changeHolder -= actualChange;

        //    }


        //    //remove coin from pool when change is complete
        //    removeFromCoinInventory(changeCoins, coins);


        //    //print change
        //    foreach (double number in changeCoins)
        //    {
        //        Console.WriteLine(number);
        //    }

        //    //check if coin is in coin pool if not use next available coin

            

        //}

        


        


        //check if coin quantity is zero
        //public bool checkIfCoinIsZero(List<double> changePool)
        //{
        //    Coin coin = this;


        //    //loops through change pool to give
        //    foreach (double coins in changePool)
        //    {

        //        //checks that the coin in the change pool is not null
        //        while (coin != null)
        //        {
        //            if (coin.getCoinValue() == coins && coin.getCoinQuantity() == 0)
        //            {
        //                return true;

        //                //Console.WriteLine($"The coin {coin}  has a quantity of 0.");

        //            }

        //            //to see if coin is avaialble for change
        //            else
        //            {
        //                return false;
        //                // Console.WriteLine("There's Coin");
        //            }

        //            coin = coin.getNextCoin();
        //        }

        //    }

        //    return false;
        //}








































        //private Dictionary<double, int> coinInventory;

        //      public Coin()
        //      {
        //	coinInventory = new Dictionary<double, int>();
        //	coinInventory.Add(2.0, 2);
        //          coinInventory.Add(1.0, 3);
        //          coinInventory.Add(0.5, 0);
        //          coinInventory.Add(0.2, 5);
        //          coinInventory.Add(0.1, 10);
        //	coinInventory.Add(0.05, 20);
        //      }

        //public Dictionary<double, int> GetCoinInventory()
        //{
        //	return coinInventory;
        //}

        //      public void SetCoinInventory(Dictionary<double, int> newInventory)
        //      {
        //          coinInventory = newInventory;
        //      }

        //public bool UpdateInventory(double key, int quantity)
        //{
        //	int currentQuantity;

        //	if(coinInventory.TryGetValue(key, out currentQuantity))
        //	{
        //		coinInventory[key] = currentQuantity + quantity;
        //		return true;
        //	}
        //	return false;
        //}

        //public void Print()
        //{
        //	foreach (KeyValuePair<double, int> kvp in coinInventory)
        //	{
        //		Console.WriteLine("Coin: {0} , Quantity: {1}", kvp.Key, kvp.Value);
        //	}

        //}

        //      public double ChangeChecker(List<double> input, Snacks snack)
        //      {
        //          //if statement to check if equal to

        //          double total = input.Sum();

        //          double change = total - snack.getSnackPrice();

        //         return change;
        //      }

        //public void ChangeToGive(double change)
        //{
        //	List<double> changeCoins = new List<double>();
        //	double[] coinsss = {2.0, 1.0, 0.5, 0.2, 0.1, 0.05};

        //          //meant to be the reduced change as the program progresses.
        //          //without actually touching the actual change so that
        //          //change can be used as a parameter
        //          decimal changeHolder = Convert.ToDecimal(change);

        //	while (changeHolder > 0)
        //	{
        //              //double closest = coinsss[0];

        //              List<double> coinsLessThanCoinList = new List<double>();

        //              foreach (double coin in coinsss)
        //		{
        //			//put all values less than coin in a list
        //                  //if current coin needed is 0 use the next possible coins
        //			if(coin <= Convert.ToDouble(changeHolder))
        //			{
        //                      coinsLessThanCoinList.Add(coin);
        //                  }
        //              }

        //              //assign the first variable as the change
        //              decimal actualChange = Convert.ToDecimal(coinsLessThanCoinList[0]);

        //              //add the first variable to list of change
        //              //if coin we need is not available then write error

        //              changeCoins.Add(Convert.ToDouble(actualChange));

        //              //minus [0] from change to update change
        //              changeHolder -= actualChange;

        //          }

        //          foreach (double number in changeCoins)
        //          {
        //              Console.WriteLine(number);
        //          }

        //          //if any coin is zero then do not remove from inventory else do
        //          if (checkIfCoinIsZero(changeCoins))
        //          {
        //              return;
        //          }
        //          else
        //          {
        //              //remove coin from pool when change is complete
        //              removeFromCoinInventory(changeCoins);
        //          }

        //          //check if coin is in coin pool if not use next available coin

        //          //method for if coin pool is finished therefore unable to provide change
        //      }

        //      //figure out why this is here!!!!!!!
        //      public bool IsChangeComplete(double change)
        //      {
        //	List<double> changePool = new List<double>();

        //          double total = changePool.Sum();

        //          if (total < change)
        //	{
        //		return true;
        //	}
        //	else
        //	{
        //              return false;
        //          }
        //      }

        //      public void sumOfMoneyInPool()
        //      {
        //          List<decimal> sumOfEachCoin = new List<decimal>();
        //          //read dictionary of coin in money pool
        //          //return key x value to get total amount
        //          foreach (KeyValuePair<double, int> kvp in coinInventory)
        //          {
        //              decimal eachCoinValue = Convert.ToDecimal(kvp.Key) * Convert.ToDecimal(kvp.Value);
        //              sumOfEachCoin.Add(eachCoinValue);
        //          }

        //          Console.WriteLine(sumOfEachCoin.Sum());
        //      }

        //      public void removeFromCoinInventory(List<double>changeCoins)
        //      {
        //          foreach (double coin in changeCoins)
        //          {
        //              if (coinInventory.ContainsKey(coin))
        //              {
        //                  coinInventory[coin]--;
        //              }
        //              //to see if coin is available for change
        //              else
        //              {
        //                  Console.WriteLine("Error: Coin not found in inventory!");
        //              }
        //          }


        //      }

        //      public bool checkIfCoinIsZero(List<double>changePool)
        //      {
        //          foreach (double coin in changePool)
        //          {
        //              if (!coinInventory.ContainsKey(coin) || coinInventory[coin] == 0)
        //              {
        //                  return true;
        //                  //Console.WriteLine($"The coin {coin}  has a quantity of 0.");

        //              }
        //              else
        //              {
        //                  return false;
        //                 // Console.WriteLine("There's Coin");
        //              }
        //          }

        //          return false;
        //      }
    }
}

