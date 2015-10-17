using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    abstract class NextUniqeStatesProvider
    {
        protected ICollection<AbstractState> uniqeStates;

        protected IList<AbstractAction> actions;

        public NextUniqeStatesProvider(ICollection<AbstractState> uniqeStates, IList<AbstractAction> actions)
        {
            this.uniqeStates = uniqeStates;
            this.actions = actions;
        }
        
        public abstract IList<AbstractState> GetNextStates(Node node);

        public abstract IList<Node> GetNodesWithNextStates(Node node);
    }
}
