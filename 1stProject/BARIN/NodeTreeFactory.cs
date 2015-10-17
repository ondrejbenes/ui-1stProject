using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    class NodeTreeFactory
    { 
        public static void CreateNodeTree(Node root, long maxNodes, params AbstractAction[] actions)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            for(long i = 0; i < maxNodes; i++)
            {
                Node curNode = queue.Dequeue();
                foreach (var action in actions)
                {
                    AbstractState state = action.execute(curNode);
                    if(state != null) { 
                         Node newNode = new Node(action, state, curNode);
                         curNode.Children.Add(newNode);
                         queue.Enqueue(newNode);
                    }
                }
            }
        }
    }
}
