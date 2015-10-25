using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    class BarinException : Exception
    {
        public BarinException(string message) : base(message) { }
    }

    class PathNotFoundException : BarinException
    {
        public PathNotFoundException(string message) : base(message) { }
    }
}
