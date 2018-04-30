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
        int availableMoney;

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


    }
}
