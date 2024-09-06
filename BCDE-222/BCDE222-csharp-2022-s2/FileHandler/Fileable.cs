using LevelDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace FileHandler_Jared
{
    public class Fileable : IFileable
    {
        private readonly Level _level;

        public Fileable(Level level)
        {
            _level = level;
        }

        public int GetColumnCount()
        {
            return _level.GetLevelWidth();
        }

        public int GetRowCount()
        {
            return _level.GetLevelHeight();
        }

        Part IFileable.WhatsAt(int row, int column)
        {
            return _level.GetPartAtIndex(row, column);
        }
    }
}
