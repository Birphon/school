using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileHandler_Jared
{
    public class Filer : IFiler
    {
        private Saver _saver;
        private Loader _loader;

        public Filer(Saver saver, Loader loader)
        {
            _saver = saver;
            _loader = loader;
        }

        public string Load(string filename)
        {
            return _loader.Load(filename);
        }

        public void Save(string filename, IFileable callMeBackforDetails)
        {
            _saver.Save(filename, callMeBackforDetails);
        }
    }
}
