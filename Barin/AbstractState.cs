using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    public abstract class AbstractState : IComparable
    {
        public abstract int CompareTo(object obj);
    }
}
