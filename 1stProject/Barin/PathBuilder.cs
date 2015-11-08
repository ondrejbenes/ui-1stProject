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
        public static LinkedList<Node> BuildNodePathUsingAStar(Node Start, Node Goal, HeuristicCalculator Calculator, NextStatesProvider Provider)
        {
            int expandedNodesCount = 0;
            bool found = false;
            TreeNode start = new TreeNode(Start);
            TreeNode goal = new TreeNode(null);
            var toExpand = new C5.IntervalHeap<TreeNode>(new TreeNodeCostComparer());
            var discoveredTreeNodes = new Dictionary<int, TreeNode>();

            start.Cost = Calculator.Calculate(Start.State, Goal.State);
            toExpand.Add(start);
            discoveredTreeNodes.Add(start.Node.State.GetHashCode(), start);

            while (toExpand.Count > 0)
            {
                TreeNode Current = toExpand.FindMin();
                toExpand.DeleteMin();

                if (Current.Node.State.Equals(Goal.State))
                {
                    goal = Current;
                    found = true;
                    break;
                }

                expandedNodesCount++;
                foreach (var nextNode in Provider.GetNodesWithNextStates(Current.Node))
                {
                    double Cost = Calculator.Calculate(nextNode.State, Goal.State);
                    if (!discoveredTreeNodes.ContainsKey(nextNode.State.GetHashCode()))
                    {
                        TreeNode Tem = new TreeNode(nextNode, Current, Current.Cost + Cost);
                        Current.Children.AddLast(Tem);
                        discoveredTreeNodes.Add(nextNode.State.GetHashCode(), Tem);
                        toExpand.Add(Tem);
                    }
                    else 
                    {
                        CheckIfBetterPathWasFound(discoveredTreeNodes, Current, nextNode, Cost);                    
                    }
                }   
            }

            Console.WriteLine("Expanded {0} nodes", expandedNodesCount);

            if (!found)
                throw new PathNotFoundException("Path not found!");
            
            return createPath(goal, start);
        }

        private static void CheckIfBetterPathWasFound(Dictionary<int, TreeNode> discoveredTreeNodes, TreeNode Current, Node nextNode, double Cost)
        {
            var updateCandidate = discoveredTreeNodes[nextNode.State.GetHashCode()];
            if (updateCandidate.Cost > Current.Cost + Cost)
            {
                var costDifference = updateCandidate.Cost - (Current.Cost + Cost);

                Current.Children.AddLast(updateCandidate);
                updateCandidate.Parent.Children.Remove(updateCandidate);
                updateCandidate.Parent = Current;
                updateCandidate.Cost = Current.Cost + Cost;

                var candidateChildren = new LinkedList<TreeNode>(updateCandidate.Children);
                while (candidateChildren.Count > 0)
                {
                    var child = candidateChildren.First();
                    candidateChildren.RemoveFirst();

                    foreach (var item in child.Children)
                        candidateChildren.AddLast(item);

                    child.Cost -= costDifference;
                }
            }
        }


        public static LinkedList<Node> BuildNodePath(Node Start, Node Goal, long NodesCountInSystem)
        {
            int expandedNodesCount = 0;
            int nodesInNowList = 0;
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
                toExpand = FringeSearchIteration(goal, toExpand, discoveredNodes, depthLimit, ref found, ref expandedNodesCount);
                nodesInNowList += toExpand.Count;
                depthLimit++;
                if (discoveredNodes.Count == NodesCountInSystem)
                    throw new PathNotFoundException("Path not found!");
            }

            Console.WriteLine("Expanded {0} nodes", expandedNodesCount);
            Console.WriteLine("Nodes in now list: {0}", nodesInNowList);

            return createPath(goal, start);
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
        private static LinkedList<TreeNode> FringeSearchIteration(TreeNode Goal, LinkedList<TreeNode> toExpand, Dictionary<long, TreeNode> discoveredNodes, int depthLimit, ref bool found, ref int expendedNodesCount)
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
                    expendedNodesCount++;
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

        private static LinkedList<Node> createPath(TreeNode from, TreeNode to)
        {
            LinkedList<Node> path = new LinkedList<Node>();

            TreeNode cur = from;
            while (cur != to)
            {
                path.AddFirst(cur.Node);
                cur = cur.Parent;
            }
            path.AddFirst(cur.Node);

            return path;
        }
    }
}
