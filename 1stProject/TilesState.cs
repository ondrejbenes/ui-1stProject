using System;
using Barin;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stProject
{
    class TilesState : AbstractState
    {
        public const int rows = 3;
        public const int columns = 3;

        public String Hash { get; private set; }
        public int EmptyTileRowCoord { get; set; }
        public int EmptyTileColumnCoord { get; set; }

        private int[,] tiles = new int[rows, columns];
        
        public TilesState(int[,] tiles)
        {
            this.tiles = tiles;
            this.Hash = "";
            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Hash += tiles[i, j];
                    if(tiles[i,j] == 0)
                    {
                        EmptyTileRowCoord = i;
                        EmptyTileColumnCoord = j;
                    }
                }
            }
        }

        public int[,] GetTiles()
        {
            int[,] copy = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    copy[i,j] = tiles[i, j];
                }
            }
            return copy;
        }

        public override string ToString()
        {
            String retString = "\n";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    retString += tiles[i, j] + " ";
                }
                retString += "\n";
            }

            return retString;
        }

        public override bool Equals(object obj)
        {
            if(obj is TilesState)
                if (this.Hash.Equals((obj as TilesState).Hash))
                    return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Int32.Parse(Hash);
        }

        public override int CompareTo(object obj)
        {
            if(obj is TilesState)
            {
                return Hash.CompareTo((obj as TilesState).Hash);
            }
            throw new ArgumentException("Cannot compare");
        }
    }
}
