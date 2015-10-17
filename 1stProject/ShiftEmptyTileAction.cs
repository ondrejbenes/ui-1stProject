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
        public enum ShiftDirection { LEFT, RIGHT, UP, DOWN}

        public override abstract AbstractState execute(Node node);

        protected bool CanShift(ShiftDirection direction, int EmptyTileRowCoord, int EmptyTileColumnCoord)
        {
            switch(direction)
            {
                case ShiftDirection.LEFT:
                    return EmptyTileColumnCoord > 0;
                case ShiftDirection.RIGHT:
                    return EmptyTileColumnCoord < TilesState.columns - 1;
                case ShiftDirection.UP:
                    return EmptyTileRowCoord > 0;
                case ShiftDirection.DOWN:
                    return EmptyTileRowCoord < TilesState.rows - 1;
                default: throw new ArgumentException("Unknown direction");
            }
        }
        
    }

    class ShiftEmptyTileLeftAction : ShiftEmptyTileAction
    {
        public override AbstractState execute(Node node)
        {
            if (!(node.State is TilesState))
                throw new InvalidCastException();
            TilesState state = node.State as TilesState;
            int[,] tiles = state.GetTiles();
            int rowCoord = state.EmptyTileRowCoord;
            int colCoord = state.EmptyTileColumnCoord;
            if (CanShift(ShiftDirection.LEFT, rowCoord, colCoord))
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
        public override AbstractState execute(Node node)
        {
            if (!(node.State is TilesState))
                throw new InvalidCastException();
            TilesState state = node.State as TilesState;
            int[,] tiles = state.GetTiles();
            int rowCoord = state.EmptyTileRowCoord;
            int colCoord = state.EmptyTileColumnCoord;
            if (CanShift(ShiftDirection.RIGHT, rowCoord, colCoord))
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
        public override AbstractState execute(Node node)
        {
            if (!(node.State is TilesState))
                throw new InvalidCastException();
            TilesState state = node.State as TilesState;
            int[,] tiles = state.GetTiles();
            int rowCoord = state.EmptyTileRowCoord;
            int colCoord = state.EmptyTileColumnCoord;
            if (CanShift(ShiftDirection.UP, rowCoord, colCoord))
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
        public override AbstractState execute(Node node)
        {
            if (!(node.State is TilesState))
                throw new InvalidCastException();
            TilesState state = node.State as TilesState;
            int[,] tiles = state.GetTiles();
            int rowCoord = state.EmptyTileRowCoord;
            int colCoord = state.EmptyTileColumnCoord;
            if (CanShift(ShiftDirection.DOWN, rowCoord, colCoord))
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
