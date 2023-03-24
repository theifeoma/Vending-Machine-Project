using System;
namespace VendingMachineProject
{
	public class onePound : Coin
	{
        public onePound(double value, int quantity, Coin nextValue)
            : base(value, quantity, nextValue)
        {
           
        }

        //protected override void dispenseCoins(int count)
        //{
        //    Console.WriteLine($"{count} x £1.0 coin");
        //    //after dispensing reduce quantity


        //    quantity = quantity - count;
        //    //edge case of if quantity is less than or equal to zero, call next coin
        //}

        protected override void dispenseCoins(int count)
        {
            //Console.WriteLine($"{count} x £{value} coin");

            if (quantity < count)
            {
                int dispensedCoins = quantity;
                Console.WriteLine($"Dispensed {dispensedCoins} coin(s) of {value} cents");
                //Console.WriteLine($"Remaining change: {Math.Round((count - dispensedCoins) * value, 4)}");
                quantity = 0;
                double remainingCoins = Math.Round((count - dispensedCoins) * value, 4);
                if (nextCoin != null)
                {
                    nextCoin.Dispense(remainingCoins);
                }
            }
            else
            {
                quantity -= count;
                Console.WriteLine($"Dispensed {count} coin(s) of {value} cents");
                //Console.WriteLine($"Remaining change: {Math.Round(amount - (value * count), 4)}");
            }
        }
    }
}

