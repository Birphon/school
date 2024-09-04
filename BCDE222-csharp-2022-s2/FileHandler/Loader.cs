using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace FileHandler_Jared
{
    public class Loader : ILoader
    {
        public Level Level { get; private set; }

        public string Load(string fileName)
        {
            fileName = $"{fileName}.xml";
            var deserializer = new XmlSerializer(typeof(Level));
            TextReader reader = new StreamReader(fileName);
            var level = deserializer.Deserialize(reader);
            Level = (Level)level;


            // Turns the level into a String
            // Not sure what I fully need here
            // TBH a lot of this code is Temp Code - Would be nice to see a working Level Code
            return Level.LevelData.Select();
        }
    }
}
