using System;
using System.IO;
using System.Runtime.Serialization;
using Interfaces;

namespace Brock_AssignmentTwo
{
    public class Level : ILevel, IFiler, IFileable
    {
        public int _width;
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

        public Level()
        {
            levelsMade = 0;
            xPlayerValue = 0;
            yPlayerValue = 0;
            totalNumOfGoals = 0;
            playerCount = 0;
        }

        public void AddBishop(int gridX, int gridY)                                             //Feature 2 Add Bishop
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

        public void AddEmpty(int gridX, int gridY)                                              //Feature 3 Add Empty
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

        public void AddKing(int gridX, int gridY)                                               //Feature 4 Add King
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

        public void AddKnight(int gridX, int gridY)                                             //Feature 11 Add Knight
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

        public void AddPlayerOnBishop(int gridX, int gridY)                                     //Feature 5 Add Player On Bishop
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnBishop;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnEmpty(int gridX, int gridY)                                      //Feature 6 Add Player On Empty
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnEmpty;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnKing(int gridX, int gridY)                                       //Feature 7 Add Player On King
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnKing;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnKnight(int gridX, int gridY)                                     //Feature 8 Add Player On Knight
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnKnight;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddPlayerOnRook(int gridX, int gridY)                                       //Feature 9 Add Player On Rook
        {
            if (gridX >= 0 && gridX < _height && gridY >= 0 && gridY < _width)
            {
                _level[gridX, gridY] = Part.PlayerOnRook;
                xPlayerValue = gridX;
                yPlayerValue = gridY;
                playerCount++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void AddRook(int gridX, int gridY)                                               //Feature 10 Add Rook
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
        
        public void SaveMe()                                                                    //Feature 18 Save Level
        {
            saved_height = GetLevelHeight();
            saved_width = GetLevelWidth();
            using var sw = new StreamWriter(@"C:\Users\bww0048\source\repos\Brock_A2_Sem2_2022\Brock_A2_Sem2_2022\outputText.txt");
            for (int x = 0; x < saved_width; x++)
                {
                for (int y = 0; y < saved_height; y++)
                {
                    sw.Write(_level[y, x] + " ");
                }
                sw.Write("\n");
            }

            //sw.Flush();
            //sw.Close();
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

        public void LoadMe()                                                                    //Feature 19 Load Level
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\bww0048\source\repos\Brock_A2_Sem2_2022\Brock_A2_Sem2_2022\outputText.txt");
            LoadMeFromString(text);
        }

        public int GetPlayerX()                                                                 //Feature 17 Return Player X Location
        {

            return (xPlayerValue);
        }

        public int GetPlayerY()                                                                 //Feature 14 Return Player Y Location
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

/*[DataContract(IsReference = true)]

        [DataMember()]
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        [DataMember()]
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }*/
    }
}
