using LevelDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandler_Jared
{
    public interface IFileable
    {
        Part WhatsAt(int row, int column);
        int GetColumnCount();
        int GetRowCount();
    }
}
