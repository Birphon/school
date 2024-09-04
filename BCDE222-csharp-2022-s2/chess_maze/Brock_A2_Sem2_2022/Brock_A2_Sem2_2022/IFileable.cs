namespace Brock_A2_Sem2_2022
{
    public interface IFileable
    {
        Part WhatsAt(int row, int column);
        int GetColumnCount();
        int GetRowCount();
    }
}
