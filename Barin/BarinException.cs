using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    public class BarinException : Exception
    {
        public BarinException(string message) : base(message) { }
    }

    public class PathNotFoundException : BarinException
    {
        public PathNotFoundException(string message) : base(message) { }
    }
}
