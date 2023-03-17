using System;
namespace VendingMachineProject
{
	public class fiftyPence : Coin
	{
        public fiftyPence(double value, int quantity, Coin nextValue)
            : base(value, quantity, nextValue)
        {
            this.value = 0.5;
            this.quantity = 4;
        }

        protected override void dispenseCoins(int count)
        {
            Console.WriteLine($"{count} x £0.10 coin");
        }
    
	}
}

