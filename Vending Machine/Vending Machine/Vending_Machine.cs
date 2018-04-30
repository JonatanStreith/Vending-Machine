using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Vending_Machine
    {
        public ConsoleKeyInfo keyPressed;
        public int[] moneyArray = { 1, 5, 10, 20, 50, 100, 500, 1000 };

        int availableMoney;

        List<Product> purchasedList = new List<Product>();


        public Vending_Machine()
        {
            availableMoney = 0;
        }

        public int GetAvailableMoney()
        { return availableMoney; }

        public void SetAvailableMoney(int money)
        { availableMoney = money; }

        public void ChangeAvailableMoney(int money)
        { availableMoney += money; }


        public List<Product> GetList()
        { return purchasedList; }

        public void AddProductToList(Product prod)
        { purchasedList.Add(prod); }

        public void RemoveProductFromList(int pos)
        { purchasedList.RemoveAt(pos); }

    }
}
