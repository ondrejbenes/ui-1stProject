using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barin;

namespace Prace_4
{
    class MazeHeuristicCalculator : HeuristicCalculator
    {
        public override double Calculate(AbstractState start, AbstractState goal)
        {
            if (!(start is MazeState) && !(goal is MazeState))
                throw new ArgumentException("Only MazeState allowed");

            var startMazeState = (MazeState)start;
            var goalMazeState = (MazeState)goal;

            double heuristic = Math.Pow(
                Math.Pow(startMazeState.ActiveCellXCoord - goalMazeState.ActiveCellXCoord, 2) + 
                Math.Pow(startMazeState.ActiveCellXCoord - goalMazeState.ActiveCellXCoord, 2), 0.5);

            return heuristic;
        }
    }
}
