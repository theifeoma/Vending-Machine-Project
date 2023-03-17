using System;
namespace VendingMachineProject
{
	public class twentyPence : Coin
	{
        public twentyPence(double name, int quantity, Coin nextValue)
            : base(name, quantity, nextValue)
        {
            this.value = 0.2;
            this.quantity = 5;
        }

        protected override void dispenseCoins(int count)
        {
            Console.WriteLine($"{count} x £0.10 coin");
        }
    }
}

