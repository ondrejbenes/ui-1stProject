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

        /// <exception cref="PathNotFoundException">Throws if all nodes are traveresd and no Path is found</exception>
        public static LinkedList<Node> BuildNodePath(Node Start, Node Goal, long NodesCountInSystem)
        {
            bool cutOff = false;
            int depth = 1;
            TreeNode start = new TreeNode(Start);
            TreeNode goal = new TreeNode(Goal);
            while (cutOff == false)
            {
                cutOff = DepthLimitedSearch(start, goal, depth, NodesCountInSystem);
                depth *= 2;
            }
            return BuildPath(start, goal);
        }
        
        public static LinkedList<AbstractAction> TransformNodePathToActionPath(LinkedList<Node> NodePath)
        {
            var nodePathArray = NodePath.ToArray();
            LinkedList<AbstractAction> actionPath = new LinkedList<AbstractAction>();
            for(int i = 0; i < NodePath.Count; i++)
            {
                foreach(var child in nodePathArray[i].Children)
                {
                    if (child.Item1.State.Equals(nodePathArray[i + 1].State))
                        actionPath.AddLast(child.Item2);
                }
            }

            return actionPath;
        }

        /// <exception cref="PathNotFoundException">Throws if all nodes are traveresd and no Path is found</exception>
        private static bool DepthLimitedSearch(TreeNode Start, TreeNode Goal, int depthLimit, long NodesCountInSystem)
        {
            Dictionary<long, TreeNode> discoveredNodes = new Dictionary<long, TreeNode>();
            Stack<TreeNode> Fringe = new Stack<TreeNode>();
            Fringe.Push(Start);
            while (Fringe.Count != 0)
            {
                TreeNode Parent = Fringe.Pop();
                if (Parent.Node.State.Equals(Goal.Node.State))
                {
                    Goal.Parent = Parent.Parent;
                    return true;
                }
                if (Parent.Depth == depthLimit)
                    continue;
                else
                {
                    foreach(var child in Parent.Node.Children)
                    {
                        if (!discoveredNodes.ContainsKey(child.Item1.Id))
                        {
                            TreeNode Tem = new TreeNode(child.Item1, Parent);
                            discoveredNodes.Add(Tem.Node.Id, Tem);
                            Fringe.Push(Tem);
                        }
                    }
                }
            }
            if (discoveredNodes.Count == NodesCountInSystem)
                throw new PathNotFoundException("Path not found!");
            return false;
        }

        private static LinkedList<Node> BuildPath(TreeNode Start, TreeNode Goal)
        {
            LinkedList<Node> path = new LinkedList<Node>();
            TreeNode cur = Goal;
            while(cur != Start)
            {
                path.AddFirst(cur.Node);
                cur = cur.Parent;
            }
            path.AddFirst(cur.Node);

            return path;
        }
    }
}
