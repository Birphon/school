using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelDesign
{
    
    class Program
    {

        static void Main(string[] args)
        {

            Board board1 = new Board();
            //board1.layout = new Piece[3, 3];

            //board1.SetEmpty();
            board1.DisplayBoard();


            
            
            board1.AddKing(0, 0);
            board1.AddBishop(1, 0);
            board1.AddQueen(2, 2);

            board1.layout[0, 1] = new Piece();
            board1.DisplayBoard();


            board1.UpdateBoard(2, 2);

            board1.AddRook(0, 1);
            Console.WriteLine("\n");
            board1.DisplayBoard();
            //board1.CheckValid();
            board1.NameLevel("1");
            Console.WriteLine(board1.Name);
            Console.WriteLine(board1.layout[0,0].CurrentPiece.GetType());
            Console.WriteLine(Piece.Options.King.GetType());
            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }
    }
}

