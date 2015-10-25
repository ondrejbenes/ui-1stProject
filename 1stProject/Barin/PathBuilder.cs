using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    class PathBuilder
    {
        public static LinkedList<Node> BuildNodePath(Node Start, Node Goal, long NodesCountInSystem)
        {
            int depthLimit = 0;
            bool found = false;
            TreeNode start = new TreeNode(Start);
            TreeNode goal = new TreeNode(Goal);
            LinkedList<TreeNode> toExpand = new LinkedList<TreeNode>();
            Dictionary<long, TreeNode> discoveredNodes = new Dictionary<long, TreeNode>();

            toExpand.AddFirst(start);
            discoveredNodes.Add(start.Node.Id, start);
            while (!found)
            {
                toExpand = FringeSearchIteration(goal, toExpand, discoveredNodes, depthLimit, ref found);
                depthLimit++;
                if (discoveredNodes.Count == NodesCountInSystem)
                    throw new PathNotFoundException("Path not found!");
            }

            LinkedList<Node> path = new LinkedList<Node>();
            TreeNode cur = goal;
            while (cur != start)
            {
                path.AddFirst(cur.Node);
                cur = cur.Parent;
            }
            path.AddFirst(cur.Node);

            return path;
        }

        /*
         * Fringe search makes use of a data structure that is more or less two lists to iterate over the frontier or fringe of the search tree. 
         * One list now, stores the current iteration, and the other list later stores the immediate next iteration. 
         * So from the root node of the search tree, now will be the root and later will be empty. 
         * Then the algorithm takes one of two actions: If ƒ(head) is greater than the current threshold, remove head from now and append it to the end of later; 
         * i.e. save head for the next iteration. 
         * Otherwise, if ƒ(head) is less than or equal to the threshold, expand head and discard head, consider its children, adding them to the beginning of now. 
         * At the end of an iteration, the threshold is increased, the later list becomes the now list, and later is emptied.
         */
        private static LinkedList<TreeNode> FringeSearchIteration(TreeNode Goal, LinkedList<TreeNode> toExpand, Dictionary<long, TreeNode> discoveredNodes, int depthLimit, ref bool found)
        {
            LinkedList<TreeNode> now = toExpand;
            LinkedList<TreeNode> later = new LinkedList<TreeNode>();

            while (now.Count != 0)
            {
                TreeNode Current = now.First();
                now.RemoveFirst();
                if (Current.Node.State.Equals(Goal.Node.State))
                {
                    Goal.Parent = Current.Parent;
                    found = true;
                }
                if (Current.Depth > depthLimit)
                {
                    later.AddLast(Current);
                }
                else
                {
                    foreach (var child in Current.Node.Children)
                    {
                        if (!discoveredNodes.ContainsKey(child.Item1.Id))
                        {
                            TreeNode Tem = new TreeNode(child.Item1, Current);
                            discoveredNodes.Add(Tem.Node.Id, Tem);
                            now.AddFirst(Tem);
                        }
                    }
                }
            }
            return later;
        }
    }
}
