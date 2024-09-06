using chess_maze;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization; // Asked a previous C# student and they said this is what they used

namespace FileHandler_Jared
{
    public class Saver : ISaver
    {
        private readonly Level _level;

        public Saver(Level level)
        {
            _level = level;
        }
        public void Save(string filename, IFileable callMeBackforDetails)
        {
            filename = $"{filename}.xml";
            var xmlSerializer = new XmlSerializer(typeof(Level));
            using TextWriter tw = new SteamWriter(filename);
            xmlSerializer.Serialize(tw, _level);
        }
    }
}
