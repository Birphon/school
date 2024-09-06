namespace chess_maze
{
    public interface ISaver
    {
        void Save(string filename, IFileable callMeBackforDetails);
    }
}
