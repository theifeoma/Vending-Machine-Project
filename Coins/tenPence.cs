using System;
namespace VendingMachineProject
{
	public class tenPence : Coin
    {
        public tenPence(double value, int quantity, Coin nextValue)
            : base(value, quantity, nextValue)
        {
            this.value = 0.1;
            this.quantity = 10;
            this.nextCoin = nextCoin;
        }

        public tenPence()
        {
            this.value = 0.1;
            this.quantity = 10;
            this.nextCoin = nextCoin;
        }



        protected override void dispenseCoins(int count)
        {
            Console.WriteLine($"{count} x £0.10 coin");
        }

    }
}

