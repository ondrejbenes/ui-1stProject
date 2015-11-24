using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    public class Node
    {
        static long currentId = 0L;

        public long Id { get; private set; }
        public AbstractState State { get; set; }
        public List<Tuple<Node, AbstractAction>> Children { get; set; }

        public Node(AbstractState State)
        {
            this.Id = currentId++;
            this.State = State;
            this.Children = new List<Tuple<Node, AbstractAction>>();
        }
        
        public override string ToString()
        {
            return String.Format("Id: {0}\nState: {1}\n", this.Id, this.State);
        }

    }
}
