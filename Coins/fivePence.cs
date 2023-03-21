using System;
namespace VendingMachineProject
{
	public class fivePence : Coin
	{
        public fivePence(double value, int quantity, Coin nextValue)
            : base(value, quantity, nextValue)
        {
            this.value = 0.05;
            this.quantity = 20;
            this.nextCoin = nextCoin;
        }

        public fivePence()
        {
            this.value = 0.05;
            this.quantity = 20;
            this.nextCoin = nextCoin;
        }



        protected override void dispenseCoins(int count)
        {
            Console.WriteLine($"{count} x £0.05 coin");
        }
    }
}

