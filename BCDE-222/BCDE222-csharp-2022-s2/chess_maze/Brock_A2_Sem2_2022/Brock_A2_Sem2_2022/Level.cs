using System;
using System.Collections.Generic;
using System.Text;

namespace Brock_A2_Sem2_2022
{
    class Level : ILevel
    {
        public int _width;
        public Part[,] _level;
        public int _height;
        public int _levelNumber;

        public int levelsMade = 0;
        public int gridX;
        public int gridY;
        public int xPlayerValue = 0;
        public int yPlayerValue = 0;



        public void AddBishop(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.Bishop;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddEmpty(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.Empty;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddKing(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.King;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddKnight(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.Knight;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnBishop(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnBishop;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnEmpty(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnEmpty;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnKing(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnKing;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnKnight(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnKnight;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnRook(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnRook;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddRook(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.Rook;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool CheckValid()
        {
            throw new NotImplementedException();
        }

        public void CreateLevel(int width, int height)
        {
            _height = height;
            _width = width;
            _level = new Part[_height, _width];
            levelsMade++;
            _levelNumber = levelsMade;

            for (int x = 0; x < _height; x++)
            {
                for (int y = 0; y < _width; y++)
                {
                    _level[x, y] = Part.Empty;
                }
            }
        }

        public int GetLevelHeight()
        {
            throw new NotImplementedException();
        }

        public int GetLevelWidth()
        {
            throw new NotImplementedException();
        }

        public Part GetPartAtIndex(int gridX, int gridY)
        {
            try
            {
                return ((Part)_level[gridX, gridY]);
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        public int GetPlayerLocation()
        {

            return (int xPlayerValue, int yPlayerValue);
    }
}
