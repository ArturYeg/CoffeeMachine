using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMashine
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMashine cm;
            try
            {
                cm = new CoffeeMashine(@"C:\Users\Artur\source\repos\CoffeeMashine\CoffeeMashine\Ingredients.txt",
                    @"C:\Users\Artur\source\repos\CoffeeMashine\CoffeeMashine\Receipts.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Please choose the action");
            Console.WriteLine();
            Console.WriteLine("1. Enter the coin");
            Console.WriteLine("2. Select Coffee");
            Console.WriteLine("3. Pick up the coin");
            Console.WriteLine("4. Exit");
            Console.WriteLine();

            while (true)
            {
                int number = Convert.ToInt32(Console.ReadLine());

                if (number == 1)
                {
                    Console.WriteLine("Enter the coin");

                    int coin = int.Parse(Console.ReadLine());
                    cm.insertCoin(coin);
                    Console.WriteLine("Balance =" + cm.GetAvailableCoins());
                }
                else if (number == 2)
                {
                    Console.WriteLine("Select Coffee");
                    int coffeetype = Convert.ToInt32(Console.ReadLine());
                    cm.ChooseCoffee(coffeetype);
                    Console.WriteLine("Balance =" + cm.GetAvailableCoins());
                }
                else if (number == 3)
                {
                    Console.WriteLine("Pick up the coin");
                    cm.Check();
                    Console.WriteLine("Balance =" + cm.GetAvailableCoins());

                }
                else if (number == 4)
                {
                    Console.WriteLine("Exit");
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
