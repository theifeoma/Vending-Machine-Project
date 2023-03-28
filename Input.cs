using System;
using static System.Formats.Asn1.AsnWriter;

namespace VendingMachineProject
{
	public static class Input
	{
        public static bool AskForInput(Snack snack, Coin coin)
        {
            List<double> inputList = new List<double>();

            double price = snack.getSnackPrice();

            Coin one = coin.getNextCoin();
            Coin fifty = one.getNextCoin();
            Coin twenty = fifty.getNextCoin();
            Coin ten = twenty.getNextCoin();
            Coin five = ten.getNextCoin();
            five.SetNextCoin(null);

            if (snack.getSnackQuantity() == 0)
            {
                Console.WriteLine("OUT OF STOCK");
                
            }

            else
            {

                while (IsSumLowerThanPrice(inputList, price))
            {

                    Console.Write("Please enter coins that total to less than £10: ");

                    double coinsToAdd = Convert.ToDouble(Console.ReadLine());

                    //call upon function to check each input from user == coin denomination
                    //before entry into the list

                    if (CoinCheck(coinsToAdd))
                    {
                        //input is greater than £10 we do not want to accept user's money
                        if (IsGreaterThan10(coinsToAdd, inputList))

                        {
                            //total is > 10
                            Console.WriteLine("Coin will not be added, {0} is greater than 10", coinsToAdd + inputList.Sum());
                        }

                        else
                        {


                            //coin input from user
                            inputList.Add(coinsToAdd);

                            //update inventory with input from customer

                            //input == 2
                            if (coin.getCoinValue() == coinsToAdd)
                            {
                                //update inventory
                                coin.UpdateInventory(2.0, 1);
                            }

                            //input ==1
                            else if (one.getCoinValue() == coinsToAdd)
                            {
                                //update invententory
                                one.UpdateInventory(1.0, 1);
                            }
                            
                            //input ==0.5
                            else if (fifty.getCoinValue() == coinsToAdd)
                            {
                                //update invententory
                                fifty.UpdateInventory(0.5, 1);
                            }

                            //input ==0.2
                            else if (twenty.getCoinValue() == coinsToAdd)
                            {
                                //update invententory
                                twenty.UpdateInventory(0.2, 1);
                            }

                            //input ==0.1
                            else if (ten.getCoinValue() == coinsToAdd)
                            {
                                //update invententory
                                ten.UpdateInventory(0.1, 1);
                            }

                            //input ==0.05
                            else if (five.getCoinValue() == coinsToAdd)
                            {
                                //update invententory
                                five.UpdateInventory(0.05, 1);
                            }

                            coin.PrintCoins();
                            Console.WriteLine();

                            //change to be dispensed after purchasing
                            double changeToGiv = Math.Round(coin.ChangeChecker(inputList, snack), 4);



                            //change output at every input. Value will be a minus value until user enters moeny equal to or over
                            //can be commented out
                            Console.WriteLine($"Your change is: {changeToGiv}");
                            Console.WriteLine();

                            //boolean to check if we have enough coins for change
                            if (coin.successfulCoinTransaction(changeToGiv))
                            {
                                    //dispense coins
                                    coin.Dispense(changeToGiv);

                                    if(inputList.Sum() >= snack.getSnackPrice())
                                {
                                    //reduce snack quantity
                                    Console.WriteLine();
                                    Console.WriteLine($"Here is your Snack: {snack.getSnackName()}");
                                    snack.reduceSnackQuantity();
                                }
                                    
                                    
                            }
                            else
                            {
                                Console.WriteLine("We can not process your order as machine is out of change");

                                //return coin added in inputList
                                coin.removeFromCoinInventory(inputList, coin);
                                Console.WriteLine($"Here is your money");

                                //print out money to give back to customer
                                foreach (double inputCoin in inputList)
                                {
                                    Console.Write($"£{inputCoin},");
                                }
                            }


                            //test for if coin is decrementing and incrementing
                            Console.WriteLine();

                            coin.PrintCoins();

                        }
                    }

                    else
                    {
                        Console.WriteLine("Invalid Coin:");
                    }
                }
        
            }
            return true;
        }

        //boolean to check if sum of input is greater than 10
        //need to change this to sum of money in pool
        private static bool IsGreaterThan10(double numberToAdd, List<double> inputList)
        {
            return numberToAdd + inputList.Sum() > 10;
        }

        //boolean to check if sum of input is lower than snack price
        private static bool IsSumLowerThanPrice(List<double> inputList, double price)
        {
            return inputList.Sum() < price;
        }

        //boolean to check if input contains coin values
        public static bool CoinCheck(double coinInput)
        {
            double[] coinsss = {2.0, 1.0, 0.5, 0.2, 0.1, 0.05};

            if (coinsss.Contains(coinInput))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //admin menu: increase change pool
        public static void increaseChangePool(Coin coins)
        {

            Console.WriteLine("What coin would you like to increase the change pool of? ");
            double coinKey = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("How many would of this coin would you like to add? ");
            int coinAmount = Convert.ToInt32(Console.ReadLine());

            if (Input.CoinCheck(coinKey))
            {
                coins.UpdateInventory(coinKey, coinAmount);
                coins.PrintCoins();
            }
            else
            {
                Console.WriteLine("Unable To Update. Invalid Coin Value.");
            }
        }

        //admin menu: get total change pool
        public static void getTotalMoneyInPool(Coin coins)
        {
            double total = coins.GetTotalValue();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Current Coins in Machine");
            Console.WriteLine();
            Console.WriteLine();
            coins.PrintCoins();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Total value of coins in machine is {total}");
            Console.WriteLine();
            Console.WriteLine();
        }

        //admin menu: change snack price
        public static void ChangeSnackPrice(Snack[] snacks)
        {

            Console.WriteLine("What snack would you like to increase the price of?");
            string snackToChange = Console.ReadLine();

            Console.WriteLine("What would be the new price? ");
            double newPrice = Convert.ToDouble(Console.ReadLine());

            foreach (Snack sna in snacks)
            {
                if (sna.getSnackName() == snackToChange)
                {
                    sna.setSnackPrice(newPrice);
                    Console.WriteLine($"Price of {snackToChange} changed to {newPrice}.");
                    return;
                }

            }
            Console.WriteLine("Invalid snack name.");
        }
    }
}

