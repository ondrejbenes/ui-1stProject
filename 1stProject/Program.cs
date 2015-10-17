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

            ICollection<AbstractState> states = new SortedSet<AbstractState>();
            states.Add(rootState);

            IList<AbstractAction> actions = new List<AbstractAction>();
            actions.Add(new ShiftEmptyTileLeftAction());
            actions.Add(new ShiftEmptyTileRightAction());
            actions.Add(new ShiftEmptyTileUpAction());
            actions.Add(new ShiftEmptyTileDownAction());

            NextUniqeStatesProvider nextUniqeStatesProvider = new NextUniqeTileStatesProvider(states, actions);
            AllStatesProvider allStatesProvider = new AllStatesProvider(nextUniqeStatesProvider);

            Node root = new Node(rootState);

             allStatesProvider.Populate(root);

             Console.WriteLine(states.Count);

            /*
            NodeTreeFactory.CreateNodeTree(root, 21, actions.ToArray());

            var it = root.GetWidthIterator();
            while(it.HasNext())
            {
                Console.WriteLine(it.Next().State.GetHashCode());
            }
            */

            // hey

            Console.ReadKey();
        }
    }
}
