using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie10
{
    public class SafetyModule : IObserver
    {
        public void Update(decimal balance, decimal amount, bool increase)
        {
            decimal treshold = 2000;

            if (amount >= treshold && !increase)
            {
                Console.WriteLine("Uwaga! Duża wypłata!");
            }
        }
    }
}
