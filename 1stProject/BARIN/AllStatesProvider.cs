using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    class AllStatesProvider
    {
        private NextUniqeStatesProvider nextUniqeStatesProvider;

        public AllStatesProvider(NextUniqeStatesProvider nextUniqeStatesProvider)
        {
            this.nextUniqeStatesProvider = nextUniqeStatesProvider;
        }

        public void Populate(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                IList<Node> nodes = nextUniqeStatesProvider.GetNodesWithNextStates(queue.Dequeue());
                foreach (var node in nodes)
                    queue.Enqueue(node);
            }
        }
    }
}
