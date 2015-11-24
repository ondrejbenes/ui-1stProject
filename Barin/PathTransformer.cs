using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barin
{
    public class PathTransformer
    {
        public static LinkedList<AbstractAction> TransformNodePathToActionPath(LinkedList<Node> NodePath)
        {
            var nodePathArray = NodePath.ToArray();
            LinkedList<AbstractAction> actionPath = new LinkedList<AbstractAction>();
            for (int i = 0; i < NodePath.Count - 1; i++)
            {
                foreach (var child in nodePathArray[i].Children)
                {
                    if (child.Item1.State.Equals(nodePathArray[i + 1].State))
                        actionPath.AddLast(child.Item2);
                }
            }

            return actionPath;
        }
    }
}
