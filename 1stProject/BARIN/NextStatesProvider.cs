using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    abstract class NextStatesProvider
    {
        protected IList<AbstractAction> actions;

        public NextStatesProvider(IList<AbstractAction> actions)
        {
            this.actions = actions;
        }
        
        public abstract IList<AbstractState> GetNextStates(Node node);

        public abstract IList<Node> GetNodesWithNextStates(Node node);

        public SortedSet<AbstractState> GetUniqueStates(Node root)
        {
            SortedSet<AbstractState> uniqeStates = new SortedSet<AbstractState>();
            uniqeStates.Add(root.State);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                IList<AbstractState> states = GetNextStates(queue.Dequeue());
                foreach (var state in states)
                {
                    if (!uniqeStates.Contains(state))
                    {
                        uniqeStates.Add(state);
                        queue.Enqueue(new Node(state));
                    }
                }
            }

            return uniqeStates;
        }
    }
}
