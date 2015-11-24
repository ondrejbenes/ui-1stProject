using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barin;

namespace Barin
{
    public abstract class AbstractAction
    {
        abstract public AbstractState execute(Node node);
    }
}
