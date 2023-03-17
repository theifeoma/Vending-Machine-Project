using System;
namespace VendingMachineProject
{
	public class fivePence : Coin
	{
        public fivePence(double name, int quantity, Coin nextValue)
            : base(name, quantity, nextValue)
        {
            this.value = 0.05;
            this.quantity = 20;
        }

        protected override void dispenseCoins(int count)
        {
            Console.WriteLine($"{count} x £0.10 coin");
        }
    }
}

