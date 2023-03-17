using System;
using System.Drawing;
using System.Threading.Channels;

namespace VendingMachineProject
{
	public abstract class Coin
	{
        protected double value;//coin name
        protected int quantity;
        protected Coin nextCoin;

        public Coin(double name, int quantity, Coin nextCoin)
        {
            this.value = 0.1;
            this.quantity = 10;
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

        public double getCoinQuantity()
        {
            return quantity;
        }


        //sets the value of the next coin
        public void SetNextCoin(Coin coin)
        {
            this.nextCoin = coin;
        }


        //method to dispense change using recuresion
        public void Dispense(double amount)
        {
            int count = (int)(amount / value);
            double remainder = amount % value;

            if (count > 0)
            {
                dispenseCoins(count);
            }

            if (remainder > 0 && nextCoin != null)
            {
                nextCoin.Dispense(remainder);
            }
        }

        //abstract method implemented by other classes for the dispense function
        protected abstract void dispenseCoins(int count);
       













































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

