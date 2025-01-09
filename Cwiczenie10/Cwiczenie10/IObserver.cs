using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie10
{
    public interface IObserver
    {
        public void Update(decimal balance, decimal amount, bool increase);
    }
}
