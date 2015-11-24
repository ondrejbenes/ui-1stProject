using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    public abstract class NextStatesProvider
    {
        protected IList<AbstractAction> actions;

        public NextStatesProvider(IList<AbstractAction> actions)
        {
            this.actions = actions;
        }

        public abstract IList<AbstractState> GetNextStates(Node node);

        public abstract IList<Node> GetNodesWithNextStates(Node node);
    }
}