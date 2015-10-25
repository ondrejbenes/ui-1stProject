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
        /*

        public static void CreateNodeTree(Node root, long maxNodes, params AbstractAction[] actions)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            for (long i = 0; i < maxNodes; i++)
            {
                Node curNode = queue.Dequeue();
                foreach (var action in actions)
                {
                    AbstractState state = action.execute(curNode);
                    if (state != null)
                    {
                        Node newNode = new Node(action, state, curNode);
                        curNode.Children.Add(newNode);
                        queue.Enqueue(newNode);
                    }
                }
            }
        }

        public static void CreateNodeTreeWithUniqueStates(Node root, params AbstractAction[] actions)
        {
            SortedSet<AbstractState> uniqeStates = new SortedSet<AbstractState>();
            uniqeStates.Add(root.State);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node curNode = queue.Dequeue();
                foreach (var action in actions)
                {
                    AbstractState state = action.execute(curNode);
                    if (state != null && !uniqeStates.Contains(state))
                    {
                        Node newNode = new Node(action, state, curNode);
                        curNode.Children.Add(newNode);
                        uniqeStates.Add(state);
                        queue.Enqueue(newNode);
                    }
                }
            }
        }

        public static Node CreateNodeTreeWithUniqueStatesUntilStateIsReached(Node root, AbstractState finishState, params AbstractAction[] actions)
        {
            SortedSet<AbstractState> uniqeStates = new SortedSet<AbstractState>();
            uniqeStates.Add(root.State);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node curNode = queue.Dequeue();
                foreach (var action in actions)
                {
                    AbstractState state = action.execute(curNode);
                    if (state != null && !uniqeStates.Contains(state))
                    {
                        Node newNode = new Node(action, state, curNode);
                        curNode.Children.Add(newNode);

                        if (state.Equals(finishState))
                            return newNode;
                        uniqeStates.Add(state);
                        queue.Enqueue(newNode);
                    }
                }
            }
            throw new Exception("Unable to reach Finish State");
        }
        */
    }
}
