using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Printer
{
    public interface IPrinter
    {
        void Write(char _char);
        void NextLine();
    }
}
