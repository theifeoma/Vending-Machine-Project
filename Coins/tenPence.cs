using System;
namespace VendingMachineProject
{
	public class tenPence : Coin
    {
        public tenPence(double value, int quantity, Coin nextValue)
            : base(value, quantity, nextValue)
        {
           
        }

        //protected override void dispenseCoins(int count)
        //{
        //    if(quantity < count)
        //    {
        //        int remainder = count - quantity;

        //        quantity = count - remainder;

        //        double leftover = (double)remainder* value;

        //        nextCoin.dispenseCoins(leftover);
        //    }

        //    Console.WriteLine($"{count} x £0.10 coin");

        //    quantity = quantity - count;

        //    Console.WriteLine($"£0.10 coin has {quantity} left ");
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

