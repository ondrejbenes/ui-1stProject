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
            int[,] rootMatrix = new int[,] {{7, 2, 4 },{5, 0, 6 },{8, 3, 1 }};
            TilesState rootState = new TilesState(rootMatrix);
            
            IList<AbstractAction> actions = new List<AbstractAction>();
            actions.Add(new ShiftEmptyTileLeftAction());
            actions.Add(new ShiftEmptyTileRightAction());
            actions.Add(new ShiftEmptyTileUpAction());
            actions.Add(new ShiftEmptyTileDownAction());

            Node root = new Node(rootState);

            var uniqueNodes = NodeGraphFactory.CreateGraph(root, actions.ToArray());

            Console.WriteLine(uniqueNodes.Count);

            try
            {
                var path = PathBuilder.BuildNodePath(root, new Node(new TilesState(new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } })), uniqueNodes.Count);

                foreach (var action in PathTransformer.TransformNodePathToActionPath(path))
                    Console.WriteLine(action);
            }
            catch (PathNotFoundException ex) { Console.WriteLine(ex.Message); }
            
            Console.WriteLine("\n-----------\n");

            try
            {
                var path = PathBuilder.BuildNodePath(root, new Node(new TilesState(new int[,] { { 8, 0, 6 }, { 5, 4, 7 }, { 2, 3, 1 } })), uniqueNodes.Count);

                foreach (var action in PathTransformer.TransformNodePathToActionPath(path))
                    Console.WriteLine(action);
            }
            catch (PathNotFoundException ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine("\n-----------\n");

            try
            {
                var path = PathBuilder.BuildNodePath(root, new Node(new TilesState(new int[,] { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } })), uniqueNodes.Count);

                foreach (var action in PathTransformer.TransformNodePathToActionPath(path))
                    Console.WriteLine(action);
            }
            catch (PathNotFoundException ex) { Console.WriteLine(ex.Message); }

            Console.ReadKey();
        }
    }
}
