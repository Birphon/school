namespace FileHandler_Jared
{
    public interface ISaver
    {
        void Save(string filename, IFileable callMeBackforDetails);
    }
}
