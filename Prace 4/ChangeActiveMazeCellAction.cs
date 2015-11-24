using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barin;

namespace Prace_4
{
    abstract class ChangeActiveMazeCellAction : AbstractAction
    {
        // public static readonly double cellSize = 47.25; 

        public enum ShiftDirectionEnum { LEFT, RIGHT, UP, DOWN }

        public ShiftDirectionEnum ShiftDirection { get; private set; }

        public ChangeActiveMazeCellAction (ShiftDirectionEnum ShiftDirection)
        {
            this.ShiftDirection = ShiftDirection;
        }
        public override string ToString()
        {
            return "Shift " + ShiftDirection;
        }
    }

    class ChangeActCellUpAction : ChangeActiveMazeCellAction 
    {
        public ChangeActCellUpAction() : base(ShiftDirectionEnum.UP) { }

        public override AbstractState execute(Node node)
        {
            throw new NotImplementedException();
        }
    }

    class ChangeActCellDownAction : ChangeActiveMazeCellAction
    {
        public ChangeActCellDownAction() : base(ShiftDirectionEnum.DOWN) { }

        public override AbstractState execute(Node node)
        {
            throw new NotImplementedException();
        }
    }

    class ChangeActCellLeftAction : ChangeActiveMazeCellAction
    {
        public ChangeActCellLeftAction() : base(ShiftDirectionEnum.LEFT) { }

        public override AbstractState execute(Node node)
        {
            throw new NotImplementedException();
        }
    }

    class ChangeActCellRightAction : ChangeActiveMazeCellAction
    {
        public ChangeActCellRightAction() : base(ShiftDirectionEnum.RIGHT) { }

        public override AbstractState execute(Node node)
        {
            throw new NotImplementedException();
        }
    }
}
