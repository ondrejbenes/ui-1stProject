using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    abstract class NodeTreeIterator
    {
        protected Node root;
        protected LinkedList<Node> collection;

        public bool HasNext()
        {
            return collection.Count > 0;
        }

        public abstract Node Next();
    }

    class NodeTreeDepthIterator : NodeTreeIterator
    {
        public NodeTreeDepthIterator(Node root)
        {
            this.root = root;
            collection = new LinkedList<Node>();
            collection.AddFirst(root);
        }
        
        public override Node Next()
        {
            var ret = collection.First();
            collection.RemoveFirst();
            ret.Children.Reverse();
            ret.Children.ForEach(o => collection.AddFirst(o));
            ret.Children.Reverse();

            return ret;
        }
    }

    class NodeTreeWidthIterator : NodeTreeIterator
    {
        public NodeTreeWidthIterator(Node root)
        {
            this.root = root;
            collection = new LinkedList<Node>();
            collection.AddFirst(root);
        }

        public override Node Next()
        {
            var ret = collection.First();
            collection.RemoveFirst();
            ret.Children.ForEach(o => collection.AddLast(o));

            return ret;
        }
    }
}
