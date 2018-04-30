using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Drink : Product
    {
        public Drink(string receivedName)
        {
            name = receivedName;
        }
    }
}
