using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie10
{
    public class CreditCardModule : IObserver
    {
        private int counter = 0;
        //public CreditCardModule() { }
        public void Update(decimal balance, decimal amount, bool increase)
        {
            if (!increase)
            {
                counter++;
            }

            int treshold = 10;
            if (counter >= treshold)
            {
                Console.WriteLine("4 z 5 posiadaczy karty kredytowej w naszym banku jest z niej zadowolonych! Zamów kartę już dziś!");
                counter = 0;
            }
        }
    }
}
