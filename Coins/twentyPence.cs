using System;
namespace VendingMachineProject
{
	public class twentyPence : Coin
	{
        public twentyPence(double value, int quantity, Coin nextValue)
            : base(value, quantity, nextValue)
        {
            this.value = 0.2;
            this.quantity = 5;
            this.nextCoin = nextCoin;
        }

        public twentyPence()
        {
            this.value = 0.2;
            this.quantity = 5;
            this.nextCoin = nextCoin;
        }

        protected override void dispenseCoins(int count)
        {
            Console.WriteLine($"{count} x £0.20 coin");
        }
    }
}

