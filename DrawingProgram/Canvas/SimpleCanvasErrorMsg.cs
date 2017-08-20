using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Canvas
{
    public static class SimpleCanvasErrorMsg
    {
        public static readonly string EmptyInput = "input is empty";

        public static string InvalidCreateCanvasArg(int arg)
        {
            return String.Format("Positive integer is expected. Instead {0} is provided", arg);
        }
    }
}
