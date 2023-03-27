using System;
using VendingMachineProject.Snacks;

namespace VendingMachineProject;

public class Program
{
    static void Main(string[] args)
    {

        Coin coins = new twoPound(2.0, 2, new onePound(1.0, 0, new fiftyPence(0.5, 0, new twentyPence(0.2, 5, new tenPence(0.1, 10, new fivePence(0.05, 10, null))))));

        Snack[] snacks = new Snack[5];
        cola Cola = new cola("Cola", 1.50, 10);
        chocBar ChocBar = new chocBar("Choc Bar", 1.25, 10);
        skittles Skittles = new skittles("Skittles", 1.70, 8);
        bikkies Bikkies = new bikkies("Bikkies", 1.25, 10);
        gala Gala = new gala("Gala", 1.35, 4);

        snacks[0] = Cola;
        snacks[1] = ChocBar;
        snacks[2] = Skittles;
        snacks[3] = Bikkies;
        snacks[4] = Gala;

        while (true)
        {
            Console.WriteLine("##################################");
            Console.WriteLine("#  Mecachrome Vending Merchant  #");
            Console.WriteLine(" #     Hawking Edible Wares    #");
            Console.WriteLine(" ################################ ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   Snack      --Price   --Qty   ");
            Console.WriteLine($"1. {Cola.getSnackName()}       --{Cola.getSnackPrice()}     --{Cola.getSnackQuantity()} ");
            Console.WriteLine($"2. {ChocBar.getSnackName()}   --{ChocBar.getSnackPrice()}    --{ChocBar.getSnackQuantity()} ");
            Console.WriteLine($"3. {Skittles.getSnackName()}   --{Skittles.getSnackPrice()}     --{Skittles.getSnackQuantity()} ");
            Console.WriteLine($"4. {Bikkies.getSnackName()}    --{Bikkies.getSnackPrice()}    --{Bikkies.getSnackQuantity()} ");
            Console.WriteLine($"5. {Gala.getSnackName()}       --{Gala.getSnackPrice()}    --{Gala.getSnackQuantity()} ");
            Console.WriteLine();
            Console.WriteLine("   Please enter your choice: ");


            int option = Convert.ToInt32(Console.ReadLine());


            switch (option)
            {
                case 1:
                    {
                        Input.AskForInput(Cola, coins);
                    }

                    break;

                case 2:
                    {
                        Input.AskForInput(ChocBar, coins);
                    }

                    break;

                case 3:
                    {
                        Input.AskForInput(Skittles, coins);
                    }

                    break;

                case 4:
                    {
                        Input.AskForInput(Bikkies, coins);
                    }

                    break;

                case 5:
                    {
                        Input.AskForInput(Gala, coins);
                    }

                    break;

                case 1011:
                    {
                        Console.WriteLine("Please enter password: ");

                        string password = Console.ReadLine();

                        switch (password)
                        {
                            case "A5144l":
                                {
                                    Console.WriteLine("##          ADMIN MENU         ##");
                                    Console.WriteLine("#################################");
                                    Console.WriteLine("#  Mecachrome Vending Merchant  #");
                                    Console.WriteLine(" #     Hawking Edible Wares    #");
                                    Console.WriteLine("#################################");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("1. Change Snack Prices");
                                    Console.WriteLine("2. Increase Change Pool");
                                    Console.WriteLine("3. See Total Amount of Money in Machine");
                                    Console.WriteLine("4. Go Back To Customer Menu");
                                    Console.WriteLine();
                                    Console.WriteLine("   Please enter your choice: ");

                                    int adminOption = Convert.ToInt32(Console.ReadLine());

                                    switch (adminOption)
                                    {
                                        case 1:

                                            Console.WriteLine("What snack would you like to increase the price of?");
                                            string snackToChange = Console.ReadLine();

                                            Console.WriteLine("What would be the new price? ");
                                            double newPrice = Convert.ToDouble(Console.ReadLine());

                                            //check if this reflects with the change and finished coins
                                            foreach(Snack sna in snacks)
                                            {
                                            
                                                 if (sna.getSnackName() == snackToChange)
                                                 {
                                                    sna.setSnackPrice(newPrice);

                                                 }
                                                 else
                                                 {
                                                    Console.WriteLine("Invalid Snack Name");
                                                 }
                                            }
                                            

                                            break;

                                        case 2:
                                            
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

                                            break;

                                        case 3:
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
                                            break;

                                        case 4:
                                            //go back to customer menu with "if" statement below
                                            break;

                                        default:

                                            break;
                                    }
                                }
                                break;

                            default:
                                Console.WriteLine("Password incorrect");

                                //option to go to back menu maybe
                                break;
                        }

                    }
                    break;

                default:
                    Console.WriteLine("Please enter an option from 1 - 5");
                    break;
            }

        }
    }

}
