using System;
namespace VendingMachineProject
{
	public class onePound : Coin
	{
        public onePound(double value, int quantity, Coin nextValue)
            : base(value, quantity, nextValue)
        {
           
        }

        protected override void dispenseCoins(int count)
        {
            //if current count of what we need is higher than quantity of coins we have
            if (quantity < count)
            {
                int dispensedCoins = quantity;
                Console.WriteLine($"Dispensed {dispensedCoins} coin(s) of {value} cents");
                quantity = 0;
                double remainingCoins = Math.Round((count - dispensedCoins) * value, 4);

                if (nextCoin != null)
                {
                    nextCoin.Dispense(remainingCoins);
                }
            }

            //reduce as needed
            else
            {
                quantity -= count;
                Console.WriteLine($"Dispensed {count} coin(s) of {value} cents");
            }
        }


    }
}

