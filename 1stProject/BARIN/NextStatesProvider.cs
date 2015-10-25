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

        public Dictionary<int, AbstractState> GetUniqueStates(Node root)
        {
            Dictionary<int, AbstractState> uniqeStates = new Dictionary<int, AbstractState>();
            uniqeStates.Add(root.State.GetHashCode(), root.State);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                IList<AbstractState> states = GetNextStates(queue.Dequeue());
                foreach (var state in states)
                {
                    if (!uniqeStates.ContainsKey(state.GetHashCode()))
                    {
                        uniqeStates.Add(state.GetHashCode(), state);
                        queue.Enqueue(new Node(state));
                    }
                }
            }

            return uniqeStates;
        }
    }
}
