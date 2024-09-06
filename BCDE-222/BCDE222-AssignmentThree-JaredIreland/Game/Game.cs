using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Refactoring_Assignment_Two;

namespace Game
{
    public class Game : IGame
    {

        private int moveCount;
        private int goalsLeft;
        private Part activePart;
        private int playerX = 0;
        private int playerY = 0;
        private int targetX;
        private int targetY;
        private int xMoveDistance;
        private int yMoveDistance;
        private int topBoarder = 0;
        private int leftBoarder = 0;
        private int bottomBoarder;
        private int rightBoarder;
        private string textOutput;
        private int[] getPlayerLocation;
        private Direction currentDirection;
        List<int> playerXMovement = new List<int>();
        List<int> playerYMovement = new List<int>();
        List<Part> playerPartHistory = new List<Part>();

        private int saved_height;
        private int saved_width;

        public Game()
        {
            moveCount = 0;
            goalsLeft = 1;
            playerX = 0;
            playerY = 0;
        }

        public int getPlayerX()
        {
            return playerX;
        }

        public int getPlayerY()
        {
            return playerY;
        }

        public int GetMoveCount()
        {
            return moveCount;
        }

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
        public void Move(Direction moveDirection)
        {
            if (IsFinished() == true)
            {
                textOutput = "The Game is Finished! You have won! Congrates!!";
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
                    case Part.PlayerOneQueen:
                        moveQueen();
                        break;
                }
            }
        }

        private void calculateMoveDistance()
        {
            xMoveDistance = targetX - playerX;
            yMoveDistance = targetY - playerY;
        }

        private void changePosition()
        {
            playerY = playerY + yMoveDistance;
            playerX = playerX + xMoveDistance;
        }

        protected void moveRecord()
        {
            changePosition();
            recordMyMoves();
        }

        protected void moveUp()
        {
            if (playerY == topBoarder)
            {
                Console.WriteLine("Can not do this!");
            }
            else
            {
                moveRecord();       
            }
        }

        protected void moveUpRight()
        {
            if (playerY == topBoarder || playerX == leftBoarder || (0 - yMoveDistance == 0 + xMoveDistance))
            {
                Console.WriteLine("Can not do this!");
            }
            else
            {
                moveRecord();
            }
        }

        protected void moveRight()
        {
            if (playerX == rightBoarder)
            {
                Console.WriteLine("Can not do this!");
            }
            else
            {
                moveRecord();
            }
        }
        protected void moveDownRight()
        {
            if (playerY == bottomBoarder || playerX == rightBoarder || (0 - yMoveDistance == 0 - xMoveDistance))
            {
                Console.WriteLine("Can not do this!");
            }
            else
            {
                moveRecord();
            }
        }

        protected void moveDown()
        {
            if (playerY == bottomBoarder)
            {
                Console.WriteLine("Can not do this!");
            }
            else
            {
                moveRecord();
            }
        }

        protected void moveUpLeft()
        {
            if (playerY == topBoarder || playerX == leftBoarder || (0 + yMoveDistance == 0 + xMoveDistance))
            {
                Console.WriteLine("Can not do this!");
            }
            else
            {
                moveRecord();
            }
        }

        protected void moveLeft()
        {
            if (playerX == leftBoarder)
            {
                Console.WriteLine("Can not do this!");
            }
            else
            {
                moveRecord();
            }
        }

        protected void moveDownLeft()
        {
            if (playerY == bottomBoarder || playerX == leftBoarder || (0 + yMoveDistance == 0 - xMoveDistance))
            {
                Console.WriteLine("Can not do this!");
            }
            else
            {
                moveRecord();
            }
        }


        private void moveKing()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    if (playerY == topBoarder)
                    {
                        Console.WriteLine("Can not do this!");
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
                        Console.WriteLine("Can not do this!");
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
                        Console.WriteLine("Can not do this!");
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
                        Console.WriteLine("Can not do this!");
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
                        Console.WriteLine("Can not do this!");
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
                        Console.WriteLine("Can not do this!");
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
                        Console.WriteLine("Can not do this!");
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
                        Console.WriteLine("Can not do this!");
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

        private void moveKnight()
        {
            switch (xMoveDistance, yMoveDistance)
            {
                // left 2 up 1
                case (-2, -1):                                 
                    if ((playerY - 1) == topBoarder || (playerX - 2) == leftBoarder)
                    {
                        Console.WriteLine("Can not do this!");
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
                // left 1 up 2
                case (-1, -2):                                 
                    if ((playerY - 2) == topBoarder || (playerX - 1) == leftBoarder)
                    {
                        Console.WriteLine("Can not do this!");
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
                // right 1 up 2 
                case (1, -2):                                  
                    if ((playerY - 2) == topBoarder || (playerX + 1) == rightBoarder)
                    {
                        Console.WriteLine("Can not do this!");
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
                // right 2 up 1 
                case (2, -1):                                 
                    if ((playerY - 1) == topBoarder || (playerX + 2) == rightBoarder)
                    {
                        Console.WriteLine("Can not do this!");
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
                // right 2 down 1
                case (2, 1):                                
                    if ((playerY + 1) == bottomBoarder || (playerX + 2) == rightBoarder)
                    {
                        Console.WriteLine("Can not do this!");
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
                // right 1 down 2
                case (1, 2):                                
                    if ((playerY - 2) == bottomBoarder || (playerX + 1) == rightBoarder)
                    {
                        Console.WriteLine("Can not do this!");
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
                // left 1 down 2
                case (-1, 2):                                
                    if ((playerY + 2) == bottomBoarder || (playerX - 1) == leftBoarder)
                    {
                        Console.WriteLine("Can not do this!");
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
                // left 2 down 1
                case (-2, 1):                                
                    if ((playerY + 1) == bottomBoarder || (playerX - 2) == leftBoarder)
                    {
                        Console.WriteLine("Can not do this!");
                    }
                    else
                    {
                        changePosition();
                        recordMyMoves();
                    }
                    break;
            }
        }

        private void moveRook()
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    moveUp();
                    break;
                case Direction.Right:
                    moveRight();
                    break;
                case Direction.Down:
                    moveDown();
                    break;
                case Direction.Left:
                    moveLeft();
                    break;
            }
        }

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

        public void Restart()
        {
            for (int a = 0; a < moveCount; a++)
            {
                Undo();
            }
        }

        private void recordMyMoves()
        {
            playerXMovement.Add(xMoveDistance);
            playerYMovement.Add(yMoveDistance);
            moveCount++;
        }

        public string returnTextOuput()
        {
            return textOutput;
        }

        public void Load(string newLevel)
        {
            throw new NotImplementedException();
        }
    }
}
