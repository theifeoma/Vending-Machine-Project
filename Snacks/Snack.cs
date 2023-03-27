using System;
namespace VendingMachineProject
{
	public class Snack
	{
		protected string snackName;
		protected int snackQuantity;
        protected double snackPrice;

		public Snack(string snackName, double snackPrice, int snackQuantity)
		{
			this.snackName = snackName;
			this.snackQuantity = snackQuantity;
			this.snackPrice = snackPrice;
		}

        public Snack()
        {
            this.snackName = snackName;
            this.snackQuantity = snackQuantity;
            this.snackPrice = snackPrice;
        }

        public Snack(string snackName)
        {
            this.snackName = snackName;
            this.snackQuantity = snackQuantity;
            this.snackPrice = snackPrice;
        }

        public string getSnackName()
		{
			return snackName;
		}

        public int getSnackQuantity()
        {
            return snackQuantity;
        }

        public void setSnackQuantity(int snackQuantity)
        {
            this.snackQuantity = snackQuantity;
        }

        public double getSnackPrice()
        {
            return snackPrice;
        }

        public void setSnackPrice(double snackPrice)
        {
            this.snackPrice = snackPrice;
        }

        public void printSnack()
        {
            Console.WriteLine($"{snackName}    {snackPrice}    {snackQuantity}");
        }

        public void reduceSnackQuantity()
        {
                snackQuantity--;
        }

        public bool SnackCheck(Snack snacks)
        {
            if (snacks.getSnackQuantity() == 0)
            {
                Console.WriteLine("OUT OF STOCK");
                
            }

            return false;
        }

        public void changeSnackPrice(Snack snacks)
        {

            Console.WriteLine("");

            double newSnackPrice = double.Parse(Console.ReadLine());
            snacks.setSnackPrice(newSnackPrice);
        }
    }
}

