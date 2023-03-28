using System;
using VendingMachineProject.Snacks;

namespace VendingMachineProject
{
    public class Menu
    {
        private Coin coins;
        private Snack[] snacks;

        private cola Cola;
        private chocBar ChocBar;
        private skittles Skittles;
        private bikkies Bikkies;
        private gala Gala;

        public Menu()
        {
            coins = new twoPound(2.0, 2, new onePound(1.0, 3, new fiftyPence(0.5, 4, new twentyPence(0.2, 5, new tenPence(0.1, 10, new fivePence(0.05, 20, null))))));

            Cola = new cola("Cola", 1.50, 10);
            ChocBar = new chocBar("Choc Bar", 1.25, 10);
            Skittles = new skittles("Skittles", 1.70, 8);
            Bikkies = new bikkies("Bikkies", 1.25, 10);
            Gala = new gala("Gala", 1.25, 4);

            snacks = new Snack[] { Cola, ChocBar, Skittles, Bikkies, Gala };
        }

        public void Run()
        {
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
                            Controller.PurchaseSnack(Cola, coins);
                        }

                        break;

                    case 2:
                        {
                            Controller.PurchaseSnack(ChocBar, coins);
                        }

                        break;

                    case 3:
                        {
                            Controller.PurchaseSnack(Skittles, coins);
                        }

                        break;

                    case 4:
                        {
                            Controller.PurchaseSnack(Bikkies, coins);
                        }

                        break;

                    case 5:
                        {
                            Controller.PurchaseSnack(Gala, coins);
                        }

                        break;

                    case 1011:
                        {
                            Console.WriteLine("Please enter password: ");

                            string password = Console.ReadLine();

                            switch (password)
                            {
                                case "A5144I":
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

                                                Controller.ChangeSnackPrice(snacks);

                                                break;

                                            case 2:

                                                Controller.increaseChangePool(coins);

                                                break;

                                            case 3:

                                                Controller.getTotalMoneyInPool(coins);
                                                break;

                                            case 4:
                                                //go back to customer menu
                                                break;

                                            default:

                                                break;
                                        }
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Password incorrect");

                                    break;
                            }

                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Snack Selection. Please enter an option from 1 - 5");
                        break;
                }

            }
        }
    }
}