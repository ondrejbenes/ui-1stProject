using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    class Node
    {
        static long currentId = 0L;

        public long Id { get; private set; }
        /// <summary>
        /// Action that lead to the Node's State
        /// </summary>
        public AbstractAction Action { get; set; }
        public AbstractState State { get; set; }
        public Node Parent { get; set; }
        public List<Node> Children { get; set; }
        public long Depth { get; set; }

        /// <summary>
        /// Root constructor
        /// </summary>
        /// <param name="State"></param>
        public Node(AbstractState State)
        {
            this.Id = ++currentId;
            this.State = State;
            this.Children = new List<Node>();
            this.Depth = 0;
        }

        /// <summary>
        /// Common construcor
        /// </summary>
        /// <param name="Action"></param>
        /// <param name="State"></param>
        /// <param name="Parent"></param>
        public Node(AbstractAction Action, AbstractState State, Node Parent)
        {
            this.Id = ++currentId;
            this.Action = Action;
            this.State = State;
            this.Parent = Parent;
            this.Children = new List<Node>();
            this.Depth = Parent.Depth + 1;
        }

        public NodeTreeWidthIterator GetWidthIterator()
        {
            return new NodeTreeWidthIterator(this);
        }

        public NodeTreeDepthIterator GetDepthIterator()
        {
            return new NodeTreeDepthIterator(this);
        }

        public override string ToString()
        {
            return String.Format("Id: {0}\nParent Id: {1}\nReached by: {2}\nDepth: {3}\nState: {4}\n", this.Id, (this.Parent == null) ? "N/A" : this.Parent.Id.ToString(), this.Action, this.Depth, this.State);
        }

    }
}
