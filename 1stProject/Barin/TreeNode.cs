using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    class TreeNode
    {
        public Node Node { get; set; }
        public TreeNode Parent { get; set; }
        public int Depth { get; set; }
        public double Cost { get; set; }
        public LinkedList<TreeNode> Children { get; set; }

        /// <summary>
        /// Root TreeNode Constructor
        /// </summary>
        /// <param name="Node"></param>
        public TreeNode(Node Node)
        {
            this.Node = Node;
            this.Depth = 0;
            this.Children = new LinkedList<TreeNode>();
        }

        public TreeNode(Node Node, TreeNode Parent)
        {
            this.Node = Node;
            this.Parent = Parent;
            this.Depth = Parent.Depth + 1;
            this.Children = new LinkedList<TreeNode>();
        }

        public TreeNode(Node Node, TreeNode Parent, double Cost)
        {
            this.Node = Node;
            this.Parent = Parent;
            this.Cost = Cost;
            this.Depth = Parent.Depth + 1;
            this.Children = new LinkedList<TreeNode>();
        }
    }

    class TreeNodeCostComparer : Comparer<TreeNode>
    {

        public override int Compare(TreeNode x, TreeNode y)
        {
            return x.Cost.CompareTo(y.Cost);
        }
    }
}
