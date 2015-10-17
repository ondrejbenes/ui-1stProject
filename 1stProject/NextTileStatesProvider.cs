using System;
using Barin;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stProject
{
    class NextTileStatesProvider : NextStatesProvider
    {
        public NextTileStatesProvider(IList<AbstractAction> actions) : base(actions) {}

        public override IList<AbstractState> GetNextStates(Node node)
        {
            IList<AbstractState> states = new List<AbstractState>();
            foreach(var action in actions)
            {
                AbstractState state = action.execute(node);
                if (state != null && state is TilesState)
                {
                    states.Add(state);
                }
            }
            return states;
        }

        public override IList<Node> GetNodesWithNextStates(Node node)
        {
            IList<Node> nodes = new List<Node>();
            foreach (var action in actions)
            {
                AbstractState state = action.execute(node);
                if (state != null && state is TilesState)
                {
                    Node newNode = new Node(action, state, node);
                    node.Children.Add(newNode);
                    nodes.Add(newNode);
                }
            }
            return nodes;
        }

    }
}
