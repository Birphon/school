using LevelDesigner;

namespace LevelDesigner
{
    public interface ILevel
    {
        void CreateLevel(int width, int height);
        int GetLevelWidth();
        int GetLevelHeight();
		void AddEmpty(int row, int column);
		void AddKing(int row, int column);
		void AddRook(int row, int column);
		void AddBishop(int row, int column);
		void AddKnight(int row, int column);
		void AddPlayerOnEmpty(int row, int column);
		void AddPlayerOnKing(int row, int column);
		void AddPlayerOnRook(int row, int column);
		void AddPlayerOnBishop(int row, int column);
		void AddPlayerOnKnight(int row, int column);
        Part GetPartAtIndex(int row, int column);
        void SaveMe();
        bool CheckValid();
    }
}
