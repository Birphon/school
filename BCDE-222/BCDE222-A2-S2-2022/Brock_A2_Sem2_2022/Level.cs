using System;

namespace LevelDesigner
{
    public class Level : ILevel, IFileable 
    {
        private int _width;
        private Part[,] _level;
        private int _height;
        private string levelValidSatement;

        private int levelsMade;

        private int goalX;
        private int goalY;
        private int totalNumOfGoals;


        private int xPlayerValue;
        private int yPlayerValue;
        private int playerCount;


        public Level()
        {
            levelsMade = 0;
            xPlayerValue = 0;
            yPlayerValue = 0;
            totalNumOfGoals = 0;
            playerCount = 0;
    }

        public void AddBishop(int row, int column)                                             //Feature 2 Add Bishop
        {
            if (row >= 0 && row < _height && column >= 0 && column < _width)
            {
                _level[row, column] = Part.Bishop;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddEmpty(int row, int column)                                              //Feature 3 Add Empty
        {
            if (row >= 0 && row < _height && column >= 0 && column < _width)
            {
                _level[row, column] = Part.Empty;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddKing(int row, int column)                                               //Feature 4 Add King
        {
            if (row >= 0 && row < _height && column >= 0 && column < _width)
            {
                _level[row, column] = Part.King;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddKnight(int row, int column)                                             //Feature 11 Add Knight
        {
            if (row >= 0 && row < _height && column >= 0 && column < _width)
            {
                _level[row, column] = Part.Knight;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnBishop(int row, int column)                                     //Feature 5 Add Player On Bishop
        {
            if (row >= 0 && row < _height && column >= 0 && column < _width)
            {
                _level[row, column] = Part.PlayerOnBishop;
                xPlayerValue = row;
                yPlayerValue = column;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnEmpty(int row, int column)                                      //Feature 6 Add Player On Empty
        {
            if (row >= 0 && row < _height && column >= 0 && column < _width)
            {
                _level[row, column] = Part.PlayerOnEmpty;
                xPlayerValue = row;
                yPlayerValue = column;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnKing(int row, int column)                                       //Feature 7 Add Player On King
        {
            if (row >= 0 && row < _height && column >= 0 && column < _width)
            {
                _level[row, column] = Part.PlayerOnKing;
                xPlayerValue = row;
                yPlayerValue = column;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnKnight(int row, int column)                                     //Feature 8 Add Player On Knight
        {
            if (row >= 0 && row < _height && column >= 0 && column < _width)
            {
                _level[row, column] = Part.PlayerOnKnight;
                xPlayerValue = row;
                yPlayerValue = column;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnRook(int row, int column)                                       //Feature 9 Add Player On Rook
        {
            if (row >= 0 && row < _height && column >= 0 && column < _width)
            {
                _level[row, column] = Part.PlayerOnRook;
                xPlayerValue = row;
                yPlayerValue = column;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddRook(int row, int column)                                               //Feature 10 Add Rook
        {
            if (row >= 0 && row < _height && column >= 0 && column < _width)
            {
                _level[row, column] = Part.Rook;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool CheckValid()                                                                //Feature 15 Level is Valid
        {
            if (totalNumOfGoals > 0)
            {
                if (playerCount == 1)
                {
                    levelValidSatement = "Level is valid";
                    //Console.WriteLine(levelValidSatement);
                    return true;
                }
                else if (playerCount > 1)
                {
                    levelValidSatement = "Level has too many players";
                    return false;
                }
                else
                {
                    levelValidSatement = "Level doesn't have any players";
                    return false;
                }
            }
            else
            {
                if (playerCount == 1)
                {
                    levelValidSatement = "Level doesn't have any Goals";
                }

                else if (playerCount > 1)
                {
                    levelValidSatement = "Level has too many players and no goals";
                }
                else
                {
                    levelValidSatement = "Level doesn't have any Goals or players";
                }
                return false;
            }
        }

        public void CreateLevel(int width, int height)                                          //Feature 1 Create Level
        {
            _height = height;
            _width = width;
            _level = new Part[_height, _width];
            levelsMade++;

            for (int x = 0; x < _height; x++)
            {
                for (int y = 0; y < _width; y++)
                {
                    _level[x, y] = Part.Empty;
                }
            }
            goalX = GetRowCount();
            goalY = GetColumnCount();
            totalNumOfGoals++;
        }



        public void SaveMe()                                                                    //Feature 18 Save Level
        {
            throw new NotImplementedException();
        }

        public void LoadMe()                                                                    //Feature 19 Load Level
        {
            throw new NotImplementedException();
        }

        public int GetPlayerX()                                                                 //Feature 17 Return Player X Location
        {

            return (xPlayerValue);
        }

        public int GetPlayerY()                                                                 //Feature 14 Return Player Y Location
        {

            return (yPlayerValue);
        }

        public Part WhatsAt(int row, int column)
        {
            try
            {
                return ((Part)_level[row, column]);
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public int GetColumnCount()
        {
            _height = _level.GetLength(0);
            return _height;
        }

        public int GetRowCount()
        {
            _width = _level.GetLength(1);
            return _width;
        }
    }
}
