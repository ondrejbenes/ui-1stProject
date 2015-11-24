using Barin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prace_4
{
    class Maze
    {
        public Dictionary<long, Node> Cells { get; set; }

        public Maze() { }

        public static Maze CreateFromFile(string CellsFileName, string GraphFileName, char columnsSeparator)
        {
            var ret = new Maze();
            ret.Cells = createNodes(CellsFileName, columnsSeparator);
            createGraph(ret.Cells, readLines(GraphFileName), columnsSeparator);

            return ret;
        }

        private static Dictionary<long, Node> createNodes(string FileName, char separator)
        {
            var nodes = new Dictionary<long, Node>();
            var lines = readLines(FileName);

            foreach (var line in lines)
            {
                var coords = line.Split(separator);
                var val = Convert.ToDouble(coords[0]);
                var state = new MazeState(Convert.ToDouble(coords[0]), Convert.ToDouble(coords[1]));
                var node = new Node(state);
                nodes.Add(node.Id, node);
            }

            return nodes;
        }

        public static void createGraph(Dictionary<long, Node> nodes, LinkedList<String> matrix, char separator)
        {
            long i = 0;
            foreach (var line in matrix)
            {
                var incidencies = line.Split(separator);
                for (long j = 0; j < incidencies.Length; j++) {
                    if (Int32.Parse(incidencies[j]) == 1)
                        nodes[i].Children.Add(
                            new Tuple<Node, AbstractAction>(
                                nodes[j], determineAction(
                                    nodes[i].State as MazeState, nodes[j].State as MazeState)));
                }  
                i++;
            }
        }

        private static ChangeActiveMazeCellAction determineAction(MazeState from, MazeState to)
        {
            if(from.ActiveCellXCoord == to.ActiveCellXCoord)
            {
                if (from.ActiveCellYCoord < to.ActiveCellYCoord)
                    return new ChangeActCellDownAction();
                else if (from.ActiveCellYCoord > to.ActiveCellYCoord)
                    return new ChangeActCellUpAction();
            } else if (from.ActiveCellYCoord == to.ActiveCellYCoord)
            {
                if (from.ActiveCellXCoord < to.ActiveCellXCoord)
                    return new ChangeActCellRightAction();
                else if (from.ActiveCellXCoord > to.ActiveCellXCoord)
                    return new ChangeActCellLeftAction();
            }

            throw new Exception("Unknown action");
        }

        private static LinkedList<String> readLines(string FileName)
        {
            LinkedList<String> lines = new LinkedList<String>();
            try
            {
                using (StreamReader sr = new StreamReader(FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        lines.AddLast(sr.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return lines;
        }

        private static int getColumnsCountInFile(LinkedList<String> lines, char separator)
        {
            int rowCount = lines.First().Split(separator).Length;
            foreach(var line in lines)
            {
                if(line.Split(separator).Length != rowCount)
                    throw new IOException("Corrupted File, column count is not constant");
            }
            return rowCount;
        }
    }
}
