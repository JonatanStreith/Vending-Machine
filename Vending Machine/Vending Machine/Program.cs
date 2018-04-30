using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Program
    {



        static void Main(string[] args)
        {

            Vending_Machine QS = new Vending_Machine();


            Console.WriteLine("Welcome to Quick-Snack, your premier choice for avoiding strvation death!");
            Console.WriteLine();
            Console.WriteLine("To make a purchase, deposit as much money as you like \ninto the marked receptacles, then choose any product from the menu.");
            Console.WriteLine();
            Console.WriteLine("Enjoy your snack, and remember: The Quick-Snack Corporation is not held liable \nfor any injury or death caused by using Quick-Snack!");
            Console.ReadLine();
            Console.Clear();



            List<Product> purchasedList = new List<Product>();

            while (true)
            {
                PrintMenu();
                Console.WriteLine();

                Console.WriteLine($"You have {QS.GetAvailableMoney()}kr available for purchases.");

                Console.WriteLine();

                Console.Write("Choice: ");

                QS.keyPressed = Console.ReadKey(true);      //Store the key pressed

                switch (QS.keyPressed.Key)
                {
                    case ConsoleKey.M:
                        QS.ChangeAvailableMoney(DepositMoney());
                        break;

                    case ConsoleKey.L:
                        ListProducts();
                        break;

                    case ConsoleKey.P:
                        PurchaseProducts();
                        break;

                    case ConsoleKey.C:
                        ConsumeProducts();
                        break;

                    case ConsoleKey.R:
                        ReturnMoney(QS.GetAvailableMoney());
                        QS.SetAvailableMoney(0);
                        break;

                    case ConsoleKey.Q:
                        Console.WriteLine("Goodbye! Enjoy your snacks!");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine("Goodbye! Enjoy your snacks!");
                        Console.ReadLine();
                        Environment.Exit(0);
                        break;


                    default:
                        Console.WriteLine("Illegal input.");
                        break;
                }

                Console.ReadLine();
                Console.Clear();


            }



        }

        public static void PrintMenu()
        {
            Console.WriteLine("Deposit money: M");
            Console.WriteLine("See list of products: L");
            Console.WriteLine("Make purchase: P");
            Console.WriteLine("Consume product: C");
            Console.WriteLine("Return remaining money: R");
            Console.WriteLine("Quit: Q or Escape");
            Console.WriteLine();
        }








        public static int DepositMoney()                                                //Turn this into quick keypresses on a list later
        {
            int deposited;
            int total = 0;
            bool realNumber;
            Console.WriteLine("1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr and 1000kr are the only recognized denominations. Deposit nothing to return to menu.");
            do
            {
                Console.Write("Your deposit: ");
                realNumber = Int32.TryParse(Console.ReadLine(), out deposited);
                total += deposited;
            } while (realNumber);

            Console.WriteLine("Thank you!");

            return total;
        }








        public static void ListProducts()
        {
            Console.Clear();
            for (int i = 0; i < Data.vendingMenu.GetLength(0); i++)
            { Console.WriteLine($"{Data.vendingMenu[i, 0]}: {Data.vendingMenu[i, 1]}"); }
        }








        public static void PurchaseProducts()
        {

            string choice;
            //string[] choiceProduct;
            int purchase = -1;

            ListProducts();

            Console.WriteLine();
            Console.Write("What would you like to purchase? ");

            choice = Console.ReadLine().ToUpper();


            for (int i = 0; i < Data.vendingMenu.GetLength(0); i++)
            {
                if (Data.vendingMenu[i, 0] == choice)
                { purchase = i; }
            }


            if (purchase == -1)
            { Console.WriteLine("Sorry, that's not a Quick-Snack registered product."); }
            else
            {
                Console.WriteLine($"You chose {Data.vendingMenu[purchase, 0]}: {Data.vendingMenu[purchase, 2]} for {Data.vendingMenu[purchase, 3]}kr.");
                
                //Add purchase
            }



        }

        public static void ConsumeProducts()
        {

        }








        public static void ReturnMoney(int money)                                                   //Make the return line nicer later!
        {
            int[] payArray = { 0, 0, 0, 0, 0, 0, 0, 0 };    //1, 5, 10, 20, 50, 100, 500, 1000
            int currentMoney = money;


            while (currentMoney >= 1000)        //Add a 1000-bill to the payout, decrease money by 1000
            {
                payArray[7] += 1;
                currentMoney -= 1000;
            }

            while (currentMoney >= 500)
            {
                payArray[6] += 1;
                currentMoney -= 500;
            }

            while (currentMoney >= 100)
            {
                payArray[5] += 1;
                currentMoney -= 100;
            }

            while (currentMoney >= 50)
            {
                payArray[4] += 1;
                currentMoney -= 50;
            }

            while (currentMoney >= 20)
            {
                payArray[3] += 1;
                currentMoney -= 20;
            }

            while (currentMoney >= 10)
            {
                payArray[2] += 1;
                currentMoney -= 10;
            }

            while (currentMoney >= 5)
            {
                payArray[1] += 1;
                currentMoney -= 5;
            }

            while (currentMoney >= 1)
            {
                payArray[0] += 1;
                currentMoney -= 1;
            }

            Console.WriteLine($"You receive {payArray[7]} 1000-bills, {payArray[6]} 500-bills, {payArray[5]} 100-bills, {payArray[4]} 50-bills, {payArray[3]} 20-bills, {payArray[2]} 10-coins, {payArray[1]} 5-coins, and {payArray[7]} 1-coins.");

        }
    }
}
