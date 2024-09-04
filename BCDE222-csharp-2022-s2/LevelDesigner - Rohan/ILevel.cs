using System;

namespace LevelDesign
{
    interface ILevel
    {
        void NameLevel(string name);
        void DisplayBoard();
        void UpdateBoard(int NewWidth, int NewHeight);
        void ResetBoard();
        void AddKing(int gridX, int gridY);
        void RemovePiece(int gridX, int gridY);
        void AddQueen(int gridX, int gridY);
        void AddBishop(int gridX, int gridY);
        void AddKnight(int gridX, int gridY);
        void AddRook(int gridX, int gridY);
        void AddPawn(int gridX, int gridY);
        void AddEmpty(int gridX, int gridY);
        bool CheckValid();

    }
}
