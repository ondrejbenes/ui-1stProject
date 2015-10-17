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

            /* 
            NextStatesProvider nextStatesProvider = new NextTileStatesProvider(actions);

            ICollection<AbstractState> uniqueStates = nextStatesProvider.GetUniqueStates(root);
            
            Console.WriteLine(uniqueStates.Count);
            */

            NodeTreeFactory.CreateNodeTreeWithUniqueStates(root, actions.ToArray());
            Console.BufferHeight = 2000;

            long counter = 0L;

            /*
            var widthIt = root.GetWidthIterator();
            while (widthIt.HasNext())
            {
                Console.WriteLine(widthIt.Next());
            }
            */

            var depthIt = root.GetDepthIterator();
            while (depthIt.HasNext() && counter < 100)
            {
                Console.WriteLine(depthIt.Next());
                counter++;
            }


            Console.ReadKey();
        }
    }
}
