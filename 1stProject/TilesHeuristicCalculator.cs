using Barin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stProject
{
    class TilesHeuristicCalculator : HeuristicCalculator
    {
        override public double Calculate(AbstractState start, AbstractState goal)
        {
            if (!(start is TilesState) || !(goal is TilesState))
                throw new ArgumentException("Only TileStates are allowed");

            TilesState startState = (TilesState)start;
            TilesState goalState = (TilesState)goal;
            double heuristic = 0;

            for (int i = 0; i < TilesState.rows; i++)
            {
                for (int j = 0; j < TilesState.columns; j++)
                {
                    Tuple<int, int> indexesInGoal = getIndexes(startState.GetTiles()[i, j], goalState.GetTiles());
                    heuristic += Math.Abs(indexesInGoal.Item1 - i) + Math.Abs(indexesInGoal.Item2 - j);
                }
            }

            return heuristic;
        }

        private Tuple<int, int> getIndexes(int tileValue, int[,] tiles)
        {
            for (int i = 0; i < TilesState.rows; i++)
            {
                for (int j = 0; j < TilesState.columns; j++)
                {
                    if(tiles[i, j] == tileValue)
                        return new Tuple<int, int>(i, j);
                }
            }

            throw new BarinException("Value " + tileValue + "not found in tilesMatrix");
        }
    }
}
