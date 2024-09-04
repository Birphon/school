using System;
using System.IO;
using Interfaces;

namespace Refactoring_Assignment_Two
{
    public class Level : ILevel, IFiler, IFileable
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

        private string saved_level;
        private int saved_height;
        private int saved_width;
        private Part placingPart;
        private Boolean playerStatus = false;

        public Level()
        {
            levelsMade = 0;
            xPlayerValue = 0;
            yPlayerValue = 0;
            totalNumOfGoals = 0;
            playerCount = 0;
    }

        public void BoarderChecker(int gridX, int gridY)
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = placingPart;
                if (playerStatus == true)
                {
                    xPlayerValue = gridX;
                    yPlayerValue = gridY;
                    playerCount++;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            playerStatus = false;
        }

        public void AddBishop(int gridX, int gridY)                                             //Feature 2 Add Bishop
        {
            placingPart = Part.Bishop;
            BoarderChecker(gridX, gridY);
        }

        public void AddEmpty(int gridX, int gridY)                                              //Feature 3 Add Empty
        {
            placingPart = Part.Empty;
            BoarderChecker(gridX, gridY);
        }

        public void AddKing(int gridX, int gridY)                                               //Feature 4 Add King
        {
            placingPart = Part.King;
            BoarderChecker(gridX, gridY);
        }

        public void AddKnight(int gridX, int gridY)                                             //Feature 11 Add Knight
        {
            placingPart = Part.Knight;
            BoarderChecker(gridX, gridY);
        }

        public void AddPlayerOnBishop(int gridX, int gridY)                                     //Feature 5 Add Player On Bishop
        {
            playerStatus = true;
            placingPart = Part.PlayerOnBishop;
            BoarderChecker(gridX, gridY);
        }

        public void AddPlayerOnEmpty(int gridX, int gridY)                                      //Feature 6 Add Player On Empty
        {
            playerStatus = true;
            placingPart = Part.PlayerOnEmpty;
            BoarderChecker(gridX, gridY);
        }

        public void AddPlayerOnKing(int gridX, int gridY)                                       //Feature 7 Add Player On King
        {
            playerStatus = true;
            placingPart = Part.PlayerOnKing;
            BoarderChecker(gridX, gridY);
        }

        public void AddPlayerOnKnight(int gridX, int gridY)                                     //Feature 8 Add Player On Knight
        {
            playerStatus = true;
            placingPart = Part.PlayerOnKnight;
            BoarderChecker(gridX, gridY);
        }

        public void AddPlayerOnRook(int gridX, int gridY)                                       //Feature 9 Add Player On Rook
        {
            playerStatus = true;
            placingPart = Part.PlayerOnRook;
            BoarderChecker(gridX, gridY);
        }

        public void AddRook(int gridX, int gridY)                                               //Feature 10 Add Rook
        {
            placingPart = Part.Rook;
            BoarderChecker(gridX, gridY);
        }

        public bool CheckValid()                                                                //Feature 15 Level is Valid
        {
            if (totalNumOfGoals > 0)
            {
                if (playerCount == 1)
                {
                    levelValidSatement = "Level is valid";
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
            goalX = GetLevelWidth();
            goalY = GetLevelHeight();
            totalNumOfGoals++;
        }

        public int GetLevelHeight()                                                             //Feature 13 Get Level Height
        {
            _height = _level.GetLength(0);
            return _height;
        }

        public int GetLevelWidth()                                                              //Feature 12 Get Level Width
        {
            _width = _level.GetLength(1);
            return _width;
        }

        public Part GetPartAtIndex(int gridX, int gridY)                                        //Feature 16 Return Current Piece
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
            saved_height = GetLevelHeight();
            saved_width = GetLevelWidth();
            using var sw = new StreamWriter(@"C:\Temp\C#\BCDE222-AssignmentThree-JaredIreland\Saves\outputText.txt");
            for (int x = 0; x < saved_width; x++)
                {
                for (int y = 0; y < saved_height; y++)
                {
                    sw.Write(_level[y, x] + " ");
                }
                sw.Write("\n");
            }
        }

        public void LoadMeFromString(string text)
        {
            string[] lvlLoader1 = text.Split(' ');
            int lvlIndex = 0;
            int lvlWidth = saved_width;
            int lvlHeight = saved_height;
            CreateLevel(lvlWidth, lvlHeight);
            for (int y = 0; y < lvlHeight; y++)
            {
                for (int x = 0; x < lvlWidth; x++)
                {
                    Part lvlLoader2 = (Part)Enum.Parse(typeof(Part), lvlLoader1[lvlIndex], true);
                    Console.WriteLine(lvlLoader2);
                    _level[x, y] = lvlLoader2;
                    lvlIndex++;
                }
            }
        }

        public void LoadMe()
        {
            string text = System.IO.File.ReadAllText(@"C:\Temp\C#\BCDE222-AssignmentThree-JaredIreland\Saves\outputText.txt");
            LoadMeFromString(text);
        }

        public int GetPlayerX()
        {

            return (xPlayerValue);
        }

        public int GetPlayerY()
        {

            return (yPlayerValue);
        }

        public void Save(string filename, IFileable callMeBackforDetails)
        {
            throw new NotImplementedException();
        }

        public string Load(string filename)
        {
            throw new NotImplementedException();
        }

        public Part WhatsAt(int row, int column)
        {
            return GetPartAtIndex(row, column);
        }

        public int GetColumnCount()
        {
            return GetLevelWidth();
        }

        public int GetRowCount()
        {
            return GetLevelWidth();
        }
    }
}