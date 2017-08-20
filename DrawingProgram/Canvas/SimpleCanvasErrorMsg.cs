using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Canvas
{
    public static class SimpleCanvasErrorMsg
    {
        public static readonly string CanvasNotCreated = "Canvas has not been created. You need to create a canvas first.";
        public static readonly string NotVerticalOrHorizontal = "Only vertival or horizontal line is supported now. "
            + "Therefore, either x1 should equal x2 or y1 should equal y2";

        public static string InvalidCreateCanvasArg(int arg)
        {
            return String.Format("Positive integer is expected. Instead {0} is provided", arg);
        }

        public static string XCoordinateOutOfCanvas(int max, int actual)
        {
            return String.Format("X coordainate out of bound. It should be between 1 and {0}", max);
        }

        public static string YCoordinateOutOfCanvas(int max, int actual)
        {
            return String.Format("Y coordainate out of bound. It should be between 1 and {0}", max);
        }
    }
}
