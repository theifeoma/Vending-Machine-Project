using System;
namespace VendingMachineProject
{
	public class onePound : Coin
	{
        public onePound()
        {
        }

        public onePound(double value, int quantity, Coin nextValue)
            : base(value, quantity, nextValue)
        {
            this.value = 1.0;
            this.quantity = 3;
            this.nextCoin = nextCoin;
        }

        public onePound()
        {
            this.value = 1.0;
            this.quantity = 3;
            this.nextCoin = nextCoin;
        }

        protected override void dispenseCoins(int count)
        {
            Console.WriteLine($"{count} x £0.10 coin");
        }
    }
}

