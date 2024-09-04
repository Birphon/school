using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using GameInterfaces;
using LevelDesigner;

namespace Game
{
    public class Game : IGame
    {

        private int moveCount;
        private Part activePart;
        private int targetX;
        private int targetY;
        private string textOutput;
        private Direction currentDirection;
        protected int playerX = 0;
        protected int playerY = 0;
        protected int xMoveDistance;
        protected int yMoveDistance;
        protected int bottomBoarder;
        protected int rightBoarder;
        protected int topBoarder = 0;
        protected int leftBoarder = 0;
        List<int> playerXMovement = new List<int>();
        List<int> playerYMovement = new List<int>();
        List<Part> playerPartHistory = new List<Part>();

        public Game()
        {
            moveCount = 0;
            playerX = 0;
            playerY = 0;
        }

        // Feature 10
        public int[,] getPlayerLocation()
        {
            return new int[,] { {playerY},{playerX} };
        }

        // Feature 15
        public int GetMoveCount()               
        {
            return moveCount;
        }

        // Feature 11
        public bool IsFinished()
        {
            if (playerX == rightBoarder && playerY == bottomBoarder)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void changePosition()
        {
            playerY = playerY + yMoveDistance;
            playerX = playerX + xMoveDistance;
        }

        private void recordMyMoves()
        {
            playerXMovement.Add(xMoveDistance);
            playerYMovement.Add(yMoveDistance);
        }

        private void recordMove()
        {
            changePosition();
            recordMyMoves();
        }

        // Feature 9
        private void writeRecorder()
        {
            string path = @"C:\Temp\C#\ChessMazeGame\saves"; try
            {
                if (Directory.Exists(path))
                {
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                di.Delete();
                Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            string playerData = string.Format(
                "Current Y Pos: ", playerY.ToString(), 
                "Current X Pos: ", playerX.ToString()
                );
            string[] lines = { playerData };
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "Player Log")))
            {
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
        }

        private void moveUp()
        {
            if (playerY == topBoarder)
            {
                //incorrect move do nothing
            }
            else
            {
                recordMove();
            }
        }

        private void moveUpRight()
        {
            if (playerY == topBoarder || playerX == leftBoarder || (0 - yMoveDistance == 0 + xMoveDistance))
            {
                //incorrect move do nothing
            }
            else
            {
                recordMove();
            }
        }

        private void moveRight()
        {
            if (playerX == rightBoarder)
            {
                //incorrect move do nothing
            }
            else
            {
                recordMove();
            }
        }

        private void moveDownRight()
        {
            if (playerY == bottomBoarder || playerX == rightBoarder || (0 - yMoveDistance == 0 - xMoveDistance))
            {
                //incorrect move do nothing
            }
            else
            {
                recordMove();
            }
        }

        private void moveDown()
        {
            if (playerY == bottomBoarder)
            {
                //incorrect move do nothing
            }
            else
            {
                recordMove();
            }
        }

        private void moveDownLeft()
        {
            if (playerY == bottomBoarder || playerX == leftBoarder || (0 + yMoveDistance == 0 - xMoveDistance))
            {
                //incorrect move do nothing
            }
            else
            {
                recordMove();
            }
        }

        private void moveLeft()
        {
            if (playerX == leftBoarder)
            {
                //incorrect move do nothing
            }
            else
            {
                recordMove();
            }
        }

        private void moveUpLeft()
        {
            if (playerY == topBoarder || playerX == leftBoarder || (0 + yMoveDistance == 0 + xMoveDistance))
            {
                //incorrect move do nothing
            }
            else
            {
                recordMove();
            }
        }

        // Feature 6 (Switch Case)
        // Feature 7 (Switch Case)
        public void Move(Direction moveDirection)
        {
            if (IsFinished() == true)
            {
                textOutput = "game finished congrates";
            }
            else
            {
                currentDirection = moveDirection;
                calculateMoveDistance();
                playerPartHistory.Add(getActivePart());
                switch (getActivePart())
                {
                    case Part.PlayerOnKing:
                        moveKing();
                        break;
                    case Part.PlayerOnBishop:
                        moveBishop();
                        break;
                    case Part.PlayerOnRook:
                        moveRook();
                        break;
                    case Part.PlayerOnKnight:
                        moveKnight();
                        break;
                    case Part.PlayerOnQueen:
                        moveQueen();
                        break;
                    case Part.PlayerOnEmpty:
                        Console.WriteLine("Can not move here");
                        Undo();
                        break;
                }
            }
        }

        private void calculateMoveDistance()
        {
            xMoveDistance = targetX - playerX;
            yMoveDistance = targetY - playerY;
        }

        // Feature 3
        private void moveKing()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    if (playerY == topBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        playerY--;
                        playerXMovement.Add(0);
                        playerYMovement.Add(-1);
                    }
                    break;

                case Direction.UpLeft:
                    if (playerY == topBoarder || playerX == leftBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        playerY--;
                        playerX--;
                        playerXMovement.Add(-1);
                        playerYMovement.Add(-1);
                    }
                    break;
                case Direction.UpRight:
                    if (playerY == topBoarder || playerX == rightBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        playerY--;
                        playerX++;
                        playerXMovement.Add(1);
                        playerYMovement.Add(-1);
                    }
                    break;
                case Direction.Left:
                    if (playerX == leftBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        playerX--;
                        playerXMovement.Add(-1);
                        playerYMovement.Add(0);
                    }
                    break;
                case Direction.Right:
                    if (playerX == rightBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        playerX++;
                        playerXMovement.Add(1);
                        playerYMovement.Add(0);
                    }
                    break;

                case Direction.Down:
                    if (playerY == bottomBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        playerY++;
                        playerXMovement.Add(0);
                        playerYMovement.Add(1);
                    }
                    break;
                case Direction.DownLeft:
                    if (playerY == bottomBoarder || playerX == rightBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        playerY++;
                        playerX++;
                        playerXMovement.Add(-1);
                        playerYMovement.Add(1);
                    }
                    break;
                case Direction.DownRight:
                    if (playerY == bottomBoarder || playerX == rightBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        playerY++;
                        playerX++;
                        playerXMovement.Add(1);
                        playerYMovement.Add(1);
                    }
                    break;
            }
        }

        // Feature 2
        private void moveKnight()
        {
            switch (xMoveDistance, yMoveDistance)
            {
                case (-2, -1):
                    if ((playerY - 1) == topBoarder || (playerX - 2) == leftBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        recordMove();
                    }
                    break;

                case (-1, -2):
                    if ((playerY - 2) == topBoarder || (playerX - 1) == leftBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        recordMove();
                    }
                    break;
                case (1, -2):
                    if ((playerY - 2) == topBoarder || (playerX + 1) == rightBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        recordMove();
                    }
                    break;
                case (2, -1): 
                    if ((playerY - 1) == topBoarder || (playerX + 2) == rightBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        recordMove();
                    }
                    break;
                case (2, 1):
                    if ((playerY + 1) == bottomBoarder || (playerX + 2) == rightBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        recordMove();
                    }
                    break;

                case (1, 2):
                    if ((playerY - 2) == bottomBoarder || (playerX + 1) == rightBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
                case (-1, 2):
                    if ((playerY + 2) == bottomBoarder || (playerX - 1) == leftBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
                case (-2, 1):
                    if ((playerY + 1) == bottomBoarder || (playerX - 2) == leftBoarder)
                    {
                        //incorrect move do nothing
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
            }
        }

        // Feature 1
        private void moveRook()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    moveUp();
                    break;
                case Direction.Left:
                    moveLeft();
                    break;
                case Direction.Right:
                    moveRight();
                    break;
                case Direction.Down:
                    moveDown();
                    break;
            }
        }

        // Feature 4
        private void moveBishop()
        {
            switch (currentDirection)
            {
                case Direction.UpRight:
                    moveUpRight();
                    break;
                case Direction.DownRight:
                    moveDownRight();
                    break;
                case Direction.DownLeft:
                    moveDownLeft();
                    break;
                case Direction.UpLeft:
                    moveUpLeft();
                    break;
            }
        }

        // Feature 5
        private void moveQueen()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    moveUp();
                    break;
                case Direction.UpRight:
                    moveUpRight();
                    break;
                case Direction.Right:
                    moveRight();
                    break;
                case Direction.DownRight:
                    moveDownRight();
                    break;
                case Direction.Down:
                    moveDown();
                    break;
                case Direction.DownLeft:
                    moveDownLeft();
                    break;
                case Direction.Left:
                    moveLeft();
                    break;
                case Direction.UpLeft:
                    moveUpLeft();
                    break;
            }
        }

        private Part getActivePart()
        {
            return activePart;
        }

        // Feature 16
        public void Undo()
        {
            moveCount--;
            playerX = playerX - playerXMovement.Last();
            playerXMovement.RemoveAt(playerXMovement.Count - 1);
            playerY = playerY - playerYMovement.Last();
            playerYMovement.RemoveAt(playerYMovement.Count - 1);
            activePart = playerPartHistory.Last();
            playerPartHistory.RemoveAt(playerPartHistory.Count - 1);

        }

        // Feature 12
        public void Restart()
        {
            for (int a = 0; a < moveCount; a++)
            {
                Undo();
            }
        }

        public void SaveMe()
        {
            ISaver saver = new Saver();
            saver.Save(_currentLevel.Name, _currentLevel);
        }

        public void Load(string newLevel)
        {
            throw new NotImplementedException();
        }

        public string returnTextOuput()
        {
            return textOutput;
        }
    }
}
