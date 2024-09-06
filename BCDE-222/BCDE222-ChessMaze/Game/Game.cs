using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game
{
    public class Game : IGame
    {

        public static Board newBoard = new Board(8);
        public Stopwatch timer = new Stopwatch();

        public void Start()
        {
            newBoard.SetStartGame();
            timer.Start();
            Load();
            Cell currentCell = newBoard.playerCell;
            newBoard.NextLegalMove(currentCell, currentCell.Piece);
        }

        public int[,] GetPlayerCell()
        {
            int[,] playerCell = new int[,] { { newBoard.playerCell.Row, newBoard.playerCell.Col } };
            return playerCell;
        }

        public int[,] GetPrevCell()
        {
            int[,] prevCell = new int[,] { { newBoard.prevCell.Row, newBoard.prevCell.Col } };
            return prevCell;
        }

        public int[,] GetFinalCell()
        {
            int[,] finalCell = new int[,] { { newBoard.finalCell.Row, newBoard.finalCell.Col } };
            return finalCell;
        }

        public void InputNextMove()
        {
            Console.WriteLine("Enter next Row");
            int nextRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter next Column");
            int nextCol = int.Parse(Console.ReadLine());

            Move(nextRow, nextCol);
        }

        public int[,] Move(int nextRow, int nextCol)
        {
            Cell nextCell = newBoard.SetNextMove(nextRow, nextCol);

            newBoard.NextLegalMove(nextCell, nextCell.Piece);

            GetMoveCount();
            Console.WriteLine("");

            return GetPlayerCell();
        }

        public void SetNextMove()
        {

            if (!IsFinished())
            {
                Console.WriteLine("Press: R = Restart, U = Undo, Any other key = continue");
                string nextAction = Console.ReadLine();
                if (nextAction == "R" || nextAction == "r")
                {
                    Restart();
                }
                else if (nextAction == "U" || nextAction == "u")
                {
                    Undo();
                }
                else
                {
                    InputNextMove();
                }
            }
            else
            {
                End();
                Console.WriteLine(GetTime());
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }

        public string GetTime()
        {
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string timeString = "Time taken: " + timeTaken.ToString(@"m\:ss");
            return timeString;
        }

        public void Load()
        {
            newBoard.SetCurrentCell(0, 0);

            newBoard.prevCell = newBoard.mazeGrid[0, 0];
            newBoard.SetFinalCell(2, 2);
            newBoard.SetOccupiedPiece(0, 0, (Part)'R');
            newBoard.SetOccupiedPiece(0, 2, (Part)'N');
            newBoard.SetOccupiedPiece(1, 2, (Part)'Q');
            newBoard.SetOccupiedPiece(2, 2, (Part)'K');
            newBoard.SetOccupiedPiece(2, 0, (Part)'B');
            newBoard.SetOccupiedPiece(2, 1, (Part)'B');
        }

        public void AddPiece(int row, int col, Part piece)
        {
            newBoard.SetOccupiedPiece(row, col, piece);
        }

        public int GetMoveCount()
        {
            Console.WriteLine("Move Count: " + newBoard.MoveCount);
            return newBoard.MoveCount;
        }

        public void Undo()
        {
            Cell prevCell = newBoard.prevCell;

            newBoard.SetCurrentCell(prevCell.Row, prevCell.Col);
            newBoard.NextLegalMove(prevCell, prevCell.Piece);
            newBoard.MinusMoveCount();
            GetMoveCount();
        }

        public void Restart()
        {
            Start();
        }

        public bool IsFinished()
        {
            if (newBoard.playerCell == newBoard.finalCell)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string End()
        {
            return "Congrats, You Win!";
        }
    }
}
