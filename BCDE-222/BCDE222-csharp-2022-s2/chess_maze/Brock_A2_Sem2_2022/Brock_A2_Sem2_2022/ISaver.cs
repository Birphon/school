namespace Brock_A2_Sem2_2022
{
    public interface ISaver
    {
        void Save(string filename, IFileable callMeBackforDetails);
    }
}
