namespace chess_maze
{
    public interface IFileable
    {
        Part WhatsAt(int row, int column);
        int GetColumnCount();
        int GetRowCount();
    }
}
