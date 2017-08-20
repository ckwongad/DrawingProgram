using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Printer
{
    public class StringPrinter : IPrinter
    {
        public StringBuilder stringBuilder = new StringBuilder();

        public void Write(char _char)
        {
            stringBuilder.Append(_char);
        }

        public void NextLine()
        {
            stringBuilder.Append(Environment.NewLine);
        }

        public override string ToString()
        {
            return stringBuilder.ToString();
        }
    }
}
