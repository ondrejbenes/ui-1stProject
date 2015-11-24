using Barin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prace_4
{
    class MazeState : AbstractState
    {
        public double ActiveCellXCoord { get; set; }
        public double ActiveCellYCoord { get; set; }

        public MazeState(double ActiveCellXCoord, double ActiveCellYCoord) {
            this.ActiveCellXCoord = ActiveCellXCoord;
            this.ActiveCellYCoord = ActiveCellYCoord;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MazeState))
                return false;
            return (
                this.ActiveCellXCoord == (obj as MazeState).ActiveCellXCoord && 
                this.ActiveCellYCoord == (obj as MazeState).ActiveCellYCoord);
        }

        public override int CompareTo(object obj)
        {
            if (!(obj is MazeState))
                return 0;
            return this.ActiveCellXCoord.CompareTo((obj as MazeState).ActiveCellXCoord);
        }
    }
}
