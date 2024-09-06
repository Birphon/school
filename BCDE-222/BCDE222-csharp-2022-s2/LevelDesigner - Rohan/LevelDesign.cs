using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace LevelDesign
{
    public class Board : ILevel
    {
        /*  Attributes  */
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = "Level " + value;
            }
        }

        public int BoardWidth { get; set; } = 3;
        public int BoardHeight { get; set; } = 3;


        public Piece[,] layout { get; set; } = new Piece[3, 3];

        

        

        /*  Methods */

        public void NameLevel(string LevelName)
        {
            this.Name = LevelName;
        }

        public void DisplayBoard()
        {
            
            int counter = 0;
            foreach (Piece item in this.layout)
            {

                counter++;

                if (item != null)
                {
                    Console.Write(item.CurrentPiece + " ");
                }
            
                if (counter == this.BoardWidth)
                {
                    Console.WriteLine("\n");
                    counter = 0;
                }
            }
        }

        //update the board's width and copy over the peices
        public void UpdateBoard(int NewWidth, int NewHeight)
        {
            Piece[,] OldLayout = this.layout;
            this.layout = null;
            Piece[,] NewLayout = new Piece[NewWidth, NewHeight];

            for (int x = 0; x < NewWidth; x++)
            {
                for (int y = 0; y < NewHeight; y++)
                {
                    try
                    {
                        NewLayout[x, y] = OldLayout[x, y];
                    }
                    catch
                    {
                        break;
                    }
                }
            }

            this.layout = NewLayout;
            this.BoardWidth = NewWidth;
            this.BoardHeight = NewHeight;
        }

        //reset the board to default
        public void ResetBoard()
        {
            this.layout = null;
            this.BoardHeight = 0;
            this.BoardWidth = 0;
            this.Name = "";
        }
        //Adding King instance of Piece to square
        public void AddKing(int gridX, int gridY)
        {
            if (this.layout[gridX, gridY] != null)
            {
                Console.WriteLine("This Square Already has a Piece on it");
            }
            else
            {
                this.layout[gridX, gridY] = new Piece();
                this.layout[gridX, gridY].CurrentPiece = Piece.Options.King;
            }
        }

        //Adding Queen instance of Piece to square
        public void AddQueen(int gridX, int gridY)
        {

            if (this.layout[gridX, gridY] != null)
            {
                Console.WriteLine("This Square Already has a Piece on it");
            }
            else
            {
                this.layout[gridX, gridY] = new Piece();
                this.layout[gridX, gridY].CurrentPiece = Piece.Options.Queen;
            }
        }

        //Adding Bishop instance of Piece to square
        public void AddBishop(int gridX, int gridY)
        {
            if (this.layout[gridX, gridY] != null)
            {
                Console.WriteLine("This Square Already has a Piece on it");
            }
            else
            {
                this.layout[gridX, gridY] = new Piece();
                this.layout[gridX, gridY].CurrentPiece = Piece.Options.Bishop;
            }
        }

        //Adding Knight instance of Piece to square
        public void AddKnight(int gridX, int gridY)
        {
            if (this.layout[gridX, gridY] != null)
            {
                Console.WriteLine("This Square Already has a Piece on it");
            }
            else
            {
                this.layout[gridX, gridY] = new Piece();
                this.layout[gridX, gridY].CurrentPiece = Piece.Options.Knight;
            }
        }

        //Adding Rook instance of Piece to square
        public void AddRook(int gridX, int gridY)
        {
            if (this.layout[gridX, gridY] != null)
            {
                Console.WriteLine("This Square Already has a Piece on it");
            }
            else
            {
                this.layout[gridX, gridY] = new Piece();
                this.layout[gridX, gridY].CurrentPiece = Piece.Options.Rook;
            }
        }

        //Adding Pawn instance of Piece to square
        public void AddPawn(int gridX, int gridY)
        {
            if (this.layout[gridX, gridY] != null)
            {
                Console.WriteLine("This Square Already has a Piece on it");
            }
            else
            {
                this.layout[gridX, gridY] = new Piece();
                this.layout[gridX, gridY].CurrentPiece = Piece.Options.Pawn;
            }
        }

        //Adding empty instance of Piece to square
        public void AddEmpty(int gridX, int gridY)
        {
            if (this.layout[gridX, gridY] != null)
            {
                Console.WriteLine("This Square Already has a Piece on it");
            }
            else
            {
                this.layout[gridX, gridY] = new Piece();
                this.layout[gridX, gridY].CurrentPiece = Piece.Options.Empty;
            }
        }

        //Delete instance of Piece on square
        public void RemovePiece(int gridX, int gridY)
        {
            if (this.layout[gridX, gridY] == null)
            {
                Console.WriteLine("This square is already empty");
            }
            else
            {
                this.layout[gridX, gridY] = null;
            }
        }

        //Returns the piece at a specified location
        public void GetPieceAt(int gridX, int gridY)
        {
            if (this.layout[gridX, gridY] == null)
            {
                Console.WriteLine("This square is Empty");
            }
            else
            {
                Console.WriteLine(this.layout[gridX, gridY].CurrentPiece);
            }
        }

        //Check if board is valid.
        //Square 0,0 MUST not be null.
        public bool CheckValid()
        {
            if (this.layout[0, 0] == null)
            {
                Console.WriteLine("Space [0,0] needs to have a piece on it");
                return false;
            }
            else if (this.layout[0, 0].CurrentPiece == Piece.Options.Empty)
            {
                Console.WriteLine("Space [0,0] needs to have a piece on it");
                return false;
            }
            else
            {
                Console.WriteLine("All good to go!");
                return true;
            }
        }

        public int GetBoardHeight()
        {
            return this.BoardHeight;
        }

        public int GetBoardWidth()
        {
            return this.BoardWidth;
        }

        public void SetEmpty()
        {
            for (int i = 0; i < this.BoardWidth; i++)
            {
                for (int j = 0; j < this.BoardHeight; j++)
                {
                    this.layout[i, j] = new Piece();
                }
            }
        }
    }

    public class Piece : Board
    {

        /*  Attributes  */

        public Options CurrentPiece { get; set; }

        public enum Options
        {
            Empty = 0,
            King,
            Queen,
            Bishop,
            Knight,
            Rook,
            Pawn
         
        }
    }
}
