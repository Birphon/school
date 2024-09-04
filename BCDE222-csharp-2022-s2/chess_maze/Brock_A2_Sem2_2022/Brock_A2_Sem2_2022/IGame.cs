namespace Brock_A2_Sem2_2022
{
    public interface IGame
    {
        void Move(Direction moveDirection);
        int GetMoveCount();
        void Undo();
        void Restart();
        bool IsFinished();
        void Load(string newLevel);
    }
}
