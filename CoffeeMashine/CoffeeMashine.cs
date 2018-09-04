using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMashine
{
    class CoffeeMashine
    {
        private float coffee;
        private float water;
        private float sugar;

        private int coins = 0;
        Dictionary<int, int> coffeetypetoprice = new Dictionary<int, int>(10);
        List<List<float>> coffeereceipt = new List<List<float>>(10);

        public CoffeeMashine(string ingredientspath, string receiptspath)
        {
            using (StreamReader sr = new StreamReader(ingredientspath))
            {

                string ingredients = sr.ReadLine();
                if (ingredients != null)
                {
                    string[] ingredientarray = ingredients.Split(' ');
                    if (ingredientarray.Length == 3)
                    {

                        if (!float.TryParse(ingredientarray[0], out coffee))
                        {
                            //todo
                        }

                        if (!float.TryParse(ingredientarray[1], out water))
                        {
                            //todo
                        }
                        if (!float.TryParse(ingredientarray[2], out sugar))
                        {
                            //todo
                        }
                    }
                }
            }
            using (StreamReader str = new StreamReader(receiptspath))
            {
                string receipt;
                while ((receipt = str.ReadLine()) != null)
                {
                    string[] receiptarray = receipt.Split(' ');
                    if (receiptarray != null)
                    {
                        if (receiptarray.Length == 4)
                        {
                            List<float> receiptfloat = receiptarray.Select(x => float.Parse(x)).ToList();
                            coffeereceipt.Add(receiptfloat);
                        }
                    }
                }
            }
        }
        public void Check()
        {
            coins = 0;
        }
        public void ChooseCoffee(int type)
        {

            int price = (int)coffeereceipt[type][3];
            if (coins >= price)
            {
                if (coffeereceipt[type][0] <= coffee || coffeereceipt[type][1] <= water || coffeereceipt[type][2] <= sugar)
                {
                    coins -= price;
                    coffee -= coffeereceipt[type][0];
                    water -= coffeereceipt[type][1];
                    sugar -= coffeereceipt[type][2];

                    Console.WriteLine("Coffee is Ready");
                }

                else
                {
                    Console.WriteLine("ne dostatochno ingridientov");
                }

            }
            else
            {
                Console.WriteLine("Your money is not enough.");
            }
        }
        public void insertCoin(int coin)
        {
            if (coin == 50 || coin == 100 || coin == 200 || coin == 500)
            {
                coins += coin;
            }
            else
            {
                Console.WriteLine("Please enter the correct coins");
            }
        }
        public int GetAvailableCoins()
        {
            return coins;
        }
    }
}
