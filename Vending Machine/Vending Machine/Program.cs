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

            Console.WriteLine();
            Console.WriteLine("Welcome to Quick-Snack, your premier choice for avoiding starvation death!");
            Console.WriteLine();
            Console.WriteLine("To make a purchase, deposit as much money as you like \ninto the marked receptacles, then choose any product from the menu.");
            Console.WriteLine();
            Console.WriteLine("Enjoy your snack, and remember: The Quick-Snack Corporation is not held liable \nfor any injury or death caused by using Quick-Snack!");
            Console.ReadLine();
            Console.Clear();




            while (true)
            {
                Console.WriteLine();
                PrintMenu();
                Console.WriteLine();

                Console.WriteLine($"You have {QS.GetAvailableMoney()}kr available for purchases.");
                Console.WriteLine();

                Console.Write("Choice: ");

                QS.keyPressed = Console.ReadKey(true);      //Store the key pressed

                Console.Clear();
                Console.WriteLine();

                switch (QS.keyPressed.Key)
                {
                    case ConsoleKey.M:
                        QS.ChangeAvailableMoney(DepositMoney(QS));
                        break;

                    case ConsoleKey.L:
                        ListProductsWithoutSelectors();
                        break;

                    case ConsoleKey.P:
                        PurchaseProducts(QS);
                        break;

                    case ConsoleKey.I:
                        InspectProduct(QS);
                        break;

                    case ConsoleKey.C:
                        ConsumeProducts(QS);
                        break;

                    case ConsoleKey.R:
                        PayBack(QS);
                        break;

                    case ConsoleKey.Q:
                        Quit();
                        break;

                    case ConsoleKey.Escape:
                        Quit();
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
            Console.WriteLine("Inspect purchase: I");
            Console.WriteLine("Consume purchase: C");
            Console.WriteLine("Return remaining money: R");
            Console.WriteLine("Quit: Q or Escape");
            Console.WriteLine();
        }









        public static int DepositMoney(Vending_Machine machine)                                                //Turn this into quick keypresses on a list later
        {
            int deposited = 0;
            int total = 0;
            Console.WriteLine("Choose money to deposit. Machine will not accept non-legal tender. Press Return or Escape to finish.");
            Console.WriteLine();

            for (int i = 0; i < machine.moneyArray.Length; i++)
            { Console.WriteLine($"{i + 1}: {machine.moneyArray[i]}kr"); }

            do
            {
                machine.keyPressed = Console.ReadKey(true);      //Store the key pressed
                deposited = 0;

                if ((machine.keyPressed.Key == ConsoleKey.D1) || (machine.keyPressed.Key == ConsoleKey.NumPad1))
                { deposited = 1; }
                else if ((machine.keyPressed.Key == ConsoleKey.D2) || (machine.keyPressed.Key == ConsoleKey.NumPad2))
                { deposited = 5; }
                else if ((machine.keyPressed.Key == ConsoleKey.D3) || (machine.keyPressed.Key == ConsoleKey.NumPad3))
                { deposited = 10; }
                else if ((machine.keyPressed.Key == ConsoleKey.D4) || (machine.keyPressed.Key == ConsoleKey.NumPad4))
                { deposited = 20; }
                else if ((machine.keyPressed.Key == ConsoleKey.D5) || (machine.keyPressed.Key == ConsoleKey.NumPad5))
                { deposited = 50; }
                else if ((machine.keyPressed.Key == ConsoleKey.D6) || (machine.keyPressed.Key == ConsoleKey.NumPad6))
                { deposited = 100; }
                else if ((machine.keyPressed.Key == ConsoleKey.D7) || (machine.keyPressed.Key == ConsoleKey.NumPad7))
                { deposited = 500; }
                else if ((machine.keyPressed.Key == ConsoleKey.D8) || (machine.keyPressed.Key == ConsoleKey.NumPad8))
                { deposited = 1000; }
                else if ((machine.keyPressed.Key == ConsoleKey.Escape) || (machine.keyPressed.Key == ConsoleKey.Enter))
                { Console.WriteLine("Thank you for depositing your money!"); }
                else
                { Console.WriteLine("Illegal command."); }

                total += deposited;

                if (deposited > 0)
                { Console.WriteLine($"You deposit {deposited} for a total of {total}kr so far."); }



            } while (!((machine.keyPressed.Key == ConsoleKey.Escape) || (machine.keyPressed.Key == ConsoleKey.Enter)));

            Console.WriteLine($"You have deposited {total}kr.");

            return total;

        }






        public static void ListProducts()
        {
            for (int i = 0; i < Data.vendingMenu.GetLength(0); i++)
            { Console.WriteLine($"{Data.vendingMenu[i, 0]}: {Data.vendingMenu[i, 1]}"); }
        }

        public static void ListProductsWithoutSelectors()
        {
            for (int i = 0; i < Data.vendingMenu.GetLength(0); i++)
            { Console.WriteLine($"{Data.vendingMenu[i, 1]}"); }
        }







        public static void PurchaseProducts(Vending_Machine machine)
        {

            string choice;
            int price;
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
                price = Convert.ToInt32(Data.vendingMenu[purchase, 3]);
                if (price > machine.GetAvailableMoney())
                { Console.WriteLine("Sorry, you can't afford that with currently available funds."); }
                else
                {
                    Console.WriteLine($"You chose {Data.vendingMenu[purchase, 0]}: {Data.vendingMenu[purchase, 2]} for {price}kr.");
                    machine.ChangeAvailableMoney(-price);


                    AddPurchase(purchase, machine);
                }
            }



        }

        public static void InspectProduct(Vending_Machine machine)
        {
            Console.WriteLine("You have purchased so far:");
            ListPurchases(machine);
            Console.WriteLine();
            Console.WriteLine("What would you like to look at?");
            Console.WriteLine();
            Console.Write("Choice: ");

            bool realNumber = Int32.TryParse(Console.ReadLine(), out int choice);

            string textChoice = machine.GetList()[choice - 1].GetName();



            Console.WriteLine(Data.descriptions[textChoice]);


        }




        public static void ConsumeProducts(Vending_Machine machine)
        {

            Console.WriteLine("You have purchased so far:");
            ListPurchases(machine);
            Console.WriteLine();
            Console.WriteLine("What would you like to consume?");
            Console.WriteLine();
            Console.Write("Choice: ");


            bool realNumber = Int32.TryParse(Console.ReadLine(), out int choice);

            if (realNumber && choice > 0)
            {
                if (machine.GetList()[choice - 1] is Drink)
                { Console.WriteLine($"You guzzle down the {machine.GetList()[choice - 1].GetName()}. Refreshing... in a way."); }
                else if (machine.GetList()[choice - 1] is Food)
                { Console.WriteLine($"You eat the {machine.GetList()[choice - 1].GetName()}. It's probably nutritious. Probably."); }
                else if (machine.GetList()[choice - 1] is Snack)
                { Console.WriteLine($"You munch on the {machine.GetList()[choice - 1].GetName()}. Delicious! ...if you don't think too much about it."); }
                machine.RemoveProductFromList(choice - 1);
            }
            else
            { Console.WriteLine("Illegal input."); }


        }

        public static void PayBack(Vending_Machine machine)
        {
            ReturnMoney(machine.GetAvailableMoney());
            machine.SetAvailableMoney(0);

        }






        public static void ReturnMoney(int money)                                                   //Make the return line nicer later!
        {
            int[] payArray = { 0, 0, 0, 0, 0, 0, 0, 0 };    //1, 5, 10, 20, 50, 100, 500, 1000
            List<string> payout = new List<string>();
            string payLine = "";


            int currentMoney = money;


            while (currentMoney >= 1000)        //Add a 1000-bill to the payout, decrease money by 1000
            {
                payArray[0] += 1;
                currentMoney -= 1000;
            }

            while (currentMoney >= 500)
            {
                payArray[1] += 1;
                currentMoney -= 500;
            }

            while (currentMoney >= 100)
            {
                payArray[2] += 1;
                currentMoney -= 100;
            }

            while (currentMoney >= 50)
            {
                payArray[3] += 1;
                currentMoney -= 50;
            }

            while (currentMoney >= 20)
            {
                payArray[4] += 1;
                currentMoney -= 20;
            }

            while (currentMoney >= 10)
            {
                payArray[5] += 1;
                currentMoney -= 10;
            }

            while (currentMoney >= 5)
            {
                payArray[6] += 1;
                currentMoney -= 5;
            }

            while (currentMoney >= 1)
            {
                payArray[7] += 1;
                currentMoney -= 1;
            }

            if (payArray[0] == 1)
                payout.Add($"{payArray[0]} 1000kr bill");
            else if (payArray[0] > 1)
                payout.Add($"{payArray[0]} 1000kr bills");

            if (payArray[1] == 1)
                payout.Add($"{payArray[1]} 500kr bill");
            else if (payArray[1] > 1)
                payout.Add($"{payArray[1]} 500kr bills");

            if (payArray[2] == 1)
                payout.Add($"{payArray[2]} 100kr bill");
            else if (payArray[2] > 1)
                payout.Add($"{payArray[2]} 100kr bills");

            if (payArray[3] == 1)
                payout.Add($"{payArray[3]} 50kr bill");
            else if (payArray[3] > 1)
                payout.Add($"{payArray[3]} 50kr bills");

            if (payArray[4] == 1)
                payout.Add($"{payArray[4]} 20kr bill");
            else if (payArray[4] > 1)
                payout.Add($"{payArray[4]} 20kr bills");

            if (payArray[5] == 1)
                payout.Add($"{payArray[5]} 10kr coin");
            else if (payArray[5] > 1)
                payout.Add($"{payArray[5]} 10kr coins");

            if (payArray[6] == 1)
                payout.Add($"{payArray[6]} 5kr coin");
            else if (payArray[6] > 1)
                payout.Add($"{payArray[6]} 5kr coins");

            if (payArray[7] == 1)
                payout.Add($"{payArray[7]} 1kr coin");
            else if (payArray[7] > 1)
                payout.Add($"{payArray[7]} 1kr coins");

            if (payout.Count > 2)
            {
                for (int i = 0; i < payout.Count - 2; i++)
                { payout[i] += ", "; }
            }

            if (payout.Count > 1)
            { payout[payout.Count - 2] += " and "; }


            foreach (string line in payout)
            { payLine += line; }



            Console.WriteLine($"You receive {payLine}.");
        }






        public static void ListPurchases(Vending_Machine machine)
        {

            for (int i = 0; i < machine.GetList().Count; i++)
            {
                Console.WriteLine($"{i + 1}: {machine.GetList()[i].GetName()}");

            }


        }






        public static void AddPurchase(int product, Vending_Machine machine)
        {

            if (Data.vendingMenu[product, 0].StartsWith("D"))    //Is a drink
            { machine.AddProductToList(new Drink(Data.vendingMenu[product, 2])); }
            else if (Data.vendingMenu[product, 0].StartsWith("F"))    //Is a food
            { machine.AddProductToList(new Food(Data.vendingMenu[product, 2])); }
            else if (Data.vendingMenu[product, 0].StartsWith("S"))    //Is a snack
            { machine.AddProductToList(new Snack(Data.vendingMenu[product, 2])); }
            else { Console.WriteLine("Unrecognized format."); }

            Console.WriteLine($"You receive {Data.vendingMenu[product, 2]}.");
        }


        public static void Quit()
        {
            Console.WriteLine("Goodbye! Enjoy your snacks, and thank you for using Quick-Snack for all your quick snack needs!");
            Console.WriteLine("The Quick-Snack Corporation hopes that you'll survive long enough to use Quick-Snack again!");
            Console.ReadLine();
            Environment.Exit(0);
        }

    }
}
