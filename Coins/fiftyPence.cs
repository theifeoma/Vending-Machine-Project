using System;
namespace VendingMachineProject
{
	public class fiftyPence : Coin
	{
        public fiftyPence()
        {
            this.value = 0.5;
            this.quantity = 4;
            this.nextCoin = nextCoin;
        }

        public fiftyPence(double value, int quantity, Coin nextValue)
            : base(value, quantity, nextValue)
        {
            this.value = 0.5;
            this.quantity = 4;
            this.nextCoin = nextCoin;
        }

        protected override void dispenseCoins(int count)
        {
            Console.WriteLine($"{count} x £0.50 coin");
        }
    
	}
}

