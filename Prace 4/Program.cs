using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Barin;

namespace Prace_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            HeuristicCalculator calculator = new MazeHeuristicCalculator();

            Maze maze = Maze.CreateFromFile("spat.txt", "graph.txt", ',');

            try
            {
                var path = PathBuilder.BuildNodePathUsingAStarWithSystem(maze.Cells[0], maze.Cells[199], calculator);

                foreach (var action in PathTransformer.TransformNodePathToActionPath(path))
                    Console.WriteLine(action);
            }
            catch (PathNotFoundException e)
            {

            }
            
            Console.ReadLine();
        }
    }
}
