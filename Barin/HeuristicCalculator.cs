using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    public abstract class HeuristicCalculator
    {
        public abstract Double Calculate(AbstractState start, AbstractState goal);
    }
}
