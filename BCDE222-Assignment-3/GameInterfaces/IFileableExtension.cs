using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInterfaces
{
    public interface IFileableExtension : IFileable
    {
        // Property declaration:
        public string Name
        {
            get; set;
        }

        public void SetPieceAt(Part part, int row, int column);
    }
}

