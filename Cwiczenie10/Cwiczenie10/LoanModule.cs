using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie10
{
    public class LoanModule : IObserver
    {
        public void Update(decimal balance, decimal amount, bool increase)
        {
            decimal treshold = 100;

            if (balance <= treshold)
            {
                Console.WriteLine("Złóż już dziś aplikację na kredyt!");
            }
        }
    }
}
