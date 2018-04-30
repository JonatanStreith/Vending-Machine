using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Food : Product
    {
        public Food(string receivedName)
        {
            name = receivedName;
        }
    }
}
