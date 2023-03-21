using System;
namespace VendingMachineProject
{
	public class twoPound : Coin
	{
        public twoPound()
        {
        }

        public twoPound(double value, int quantity, Coin nextValue)
             : base(value, quantity, nextValue)
        {
            this.value = 2.0;
            this.quantity = 2;
        }

        protected override void dispenseCoins(int count)
        {
            Console.WriteLine($"{count} x £0.10 coin");
        }
    }
}

