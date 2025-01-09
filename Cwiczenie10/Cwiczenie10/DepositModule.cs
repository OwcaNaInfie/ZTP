using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie10
{
    internal class DepositModule : IObserver
    {
        public void Update(decimal balance, decimal amount, bool increase)
        {
            decimal treshold = 10000;

            if (amount >= treshold && increase) 
            {
                Console.WriteLine("Najlepsze lokaty tylko w naszym banku!");
            }
        }
    }
}
