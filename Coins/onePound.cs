using System;
namespace VendingMachineProject
{
	public class onePound : Coin
	{
        public onePound(double name, int quantity, Coin nextValue)
            : base(name, quantity, nextValue)
        {
            this.value = 1.0;
            this.quantity = 3;
        }

        protected override void dispenseCoins(int count)
        {
            Console.WriteLine($"{count} x £0.10 coin");
        }
    }
}

