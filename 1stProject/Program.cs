using System;
using System.Collections.Generic;
using Barin;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] rootMatrix = new int[,]
            {
                {7, 2, 4 },
                {5, 0, 6 },
                {8, 3, 1 }
            };
            TilesState rootState = new TilesState(rootMatrix);
            
            IList<AbstractAction> actions = new List<AbstractAction>();
            actions.Add(new ShiftEmptyTileLeftAction());
            actions.Add(new ShiftEmptyTileRightAction());
            actions.Add(new ShiftEmptyTileUpAction());
            actions.Add(new ShiftEmptyTileDownAction());

            Node root = new Node(rootState);

            NextStatesProvider nextStatesProvider = new NextTileStatesProvider(actions);

            ICollection<AbstractState> uniqueStates = nextStatesProvider.GetUniqueStates(root);

            Console.WriteLine(uniqueStates.Count);

            /*
            NodeTreeFactory.CreateNodeTree(root, 21, actions.ToArray());

            var it = root.GetWidthIterator();
            while(it.HasNext())
            {
                Console.WriteLine(it.Next().State.GetHashCode());
            }
            */


            Console.ReadKey();
        }
    }
}
