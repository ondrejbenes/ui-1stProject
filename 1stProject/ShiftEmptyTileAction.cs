using System;
using Barin;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stProject
{
    abstract class ShiftEmptyTileAction : AbstractAction
    {
        public enum ShiftDirectionEnum { LEFT, RIGHT, UP, DOWN }

        public ShiftDirectionEnum ShiftDirection { get; private set; }

        public ShiftEmptyTileAction(ShiftDirectionEnum shiftDirection) 
        {
            this.ShiftDirection = shiftDirection;
        }

        public override abstract AbstractState execute(Node node);

        protected bool CanShift(ShiftDirectionEnum direction, int EmptyTileRowCoord, int EmptyTileColumnCoord)
        {
            switch(direction)
            {
                case ShiftDirectionEnum.LEFT:
                    return EmptyTileColumnCoord > 0;
                case ShiftDirectionEnum.RIGHT:
                    return EmptyTileColumnCoord < TilesState.columns - 1;
                case ShiftDirectionEnum.UP:
                    return EmptyTileRowCoord > 0;
                case ShiftDirectionEnum.DOWN:
                    return EmptyTileRowCoord < TilesState.rows - 1;
                default: throw new ArgumentException("Unknown direction");
            }
        }

        public override string ToString()
        {
            return "Shift " + ShiftDirection;
        }
        
    }

    class ShiftEmptyTileLeftAction : ShiftEmptyTileAction
    {
        public ShiftEmptyTileLeftAction() : base(ShiftDirectionEnum.LEFT) {}

        public override AbstractState execute(Node node)
        {
            if (!(node.State is TilesState))
                throw new InvalidCastException();
            TilesState state = node.State as TilesState;
            int[,] tiles = state.GetTiles();
            int rowCoord = state.EmptyTileRowCoord;
            int colCoord = state.EmptyTileColumnCoord;
            if (CanShift(ShiftDirectionEnum.LEFT, rowCoord, colCoord))
            {
                tiles[rowCoord, colCoord] = tiles[rowCoord, colCoord - 1];
                tiles[rowCoord, colCoord - 1] = 0;
                state = new TilesState(tiles);
                return state;
            }
            return null;
        }
    }

    class ShiftEmptyTileRightAction : ShiftEmptyTileAction
    {
        public ShiftEmptyTileRightAction() : base(ShiftDirectionEnum.RIGHT) { }

        public override AbstractState execute(Node node)
        {
            if (!(node.State is TilesState))
                throw new InvalidCastException();
            TilesState state = node.State as TilesState;
            int[,] tiles = state.GetTiles();
            int rowCoord = state.EmptyTileRowCoord;
            int colCoord = state.EmptyTileColumnCoord;
            if (CanShift(ShiftDirectionEnum.RIGHT, rowCoord, colCoord))
            {
                tiles[rowCoord, colCoord] = tiles[rowCoord, colCoord + 1];
                tiles[rowCoord, colCoord + 1] = 0;
                state = new TilesState(tiles);
                return state;
            }
            return null;
        }
    }

    class ShiftEmptyTileUpAction : ShiftEmptyTileAction
    {
        public ShiftEmptyTileUpAction() : base(ShiftDirectionEnum.UP) { }

        public override AbstractState execute(Node node)
        {
            if (!(node.State is TilesState))
                throw new InvalidCastException();
            TilesState state = node.State as TilesState;
            int[,] tiles = state.GetTiles();
            int rowCoord = state.EmptyTileRowCoord;
            int colCoord = state.EmptyTileColumnCoord;
            if (CanShift(ShiftDirectionEnum.UP, rowCoord, colCoord))
            {
                tiles[rowCoord, colCoord] = tiles[rowCoord - 1, colCoord];
                tiles[rowCoord - 1, colCoord] = 0;
                state = new TilesState(tiles);
                return state;
            }
            return null;
        }
    }

    class ShiftEmptyTileDownAction : ShiftEmptyTileAction
    {
        public ShiftEmptyTileDownAction() : base(ShiftDirectionEnum.DOWN) { }

        public override AbstractState execute(Node node)
        {
            if (!(node.State is TilesState))
                throw new InvalidCastException();
            TilesState state = node.State as TilesState;
            int[,] tiles = state.GetTiles();
            int rowCoord = state.EmptyTileRowCoord;
            int colCoord = state.EmptyTileColumnCoord;
            if (CanShift(ShiftDirectionEnum.DOWN, rowCoord, colCoord))
            {
                tiles[rowCoord, colCoord] = tiles[rowCoord + 1, colCoord];
                tiles[rowCoord + 1, colCoord] = 0;
                state = new TilesState(tiles);
                return state;
            }
            return null;
        }
    }
}
