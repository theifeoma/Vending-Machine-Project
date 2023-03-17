using System;
namespace VendingMachineProject
{
	public static class Input
	{
        public static bool AskForInput(Snacks snack)
        {
            List<double> inputList = new List<double>();
            Coin dummy = new Coin();
            double price = snack.getSnackPrice();
            //Snacks snackk = new Snacks();

            if (snack.getSnackQuantity() == 0)
            {
                Console.WriteLine("OUT OF STOCK");
                
            }

            else
            {

                while (IsSumLowerThanPrice(inputList, price))
            {
                //snack.SnackCheck(snack);

                

                
                    Console.Write("Please enter coins that total to less than £10: ");

                    double coinsToAdd = Convert.ToDouble(Console.ReadLine());

                    //call upon function to check each input from user == coin denomination
                    //before entry into the list

                    if (CoinCheck(coinsToAdd))
                    {
                        //change to check from 10 to total value in pool inventory
                        if (IsGreaterThan10(coinsToAdd, inputList))

                        {
                            //total is > 10
                            Console.WriteLine("Coin will not be added, {0} is greater than 10", coinsToAdd + inputList.Sum());
                        }

                        else
                        {
                            //coin input from user
                            inputList.Add(coinsToAdd);

                            //updates the coin added to the coinPool
                            dummy.UpdateInventory(coinsToAdd, 1);

                            //reduce snack quantity
                            snack.reduceSnackQuantity();

                            //change to be dispensed
                            double change = dummy.ChangeChecker(inputList, snack);
                            //Console.WriteLine(change);


                            dummy.ChangeToGive(change);

                            //test for if coin is decrementing and incrementing
                            dummy.Print();

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



        
    }
}

