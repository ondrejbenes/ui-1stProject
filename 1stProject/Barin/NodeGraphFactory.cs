using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    class NodeGraphFactory
    {
        public static Dictionary<AbstractState, Node> CreateGraph(Node root, params AbstractAction[] actions)
        {
            Dictionary<AbstractState, Node> uniqeNodes = new Dictionary<AbstractState, Node>();
            uniqeNodes.Add(root.State, root);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node curNode = queue.Dequeue();
                foreach (var action in actions)
                {
                    AbstractState state = action.execute(curNode);
                    if (state != null)
                        if (!uniqeNodes.ContainsKey(state))
                        {
                            Node newNode = new Node(state);
                            curNode.Children.Add(new Tuple<Node, AbstractAction>(newNode, action));
                            uniqeNodes.Add(state, newNode);
                            queue.Enqueue(newNode);
                        }
                        else
                        {
                            curNode.Children.Add(new Tuple<Node, AbstractAction>(uniqeNodes[state], action));
                        }
                }
            }

            return uniqeNodes;
        }
    }
}
