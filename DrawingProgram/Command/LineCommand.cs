using DrawingProgram.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Command
{
    public class LineCommand : ICommand
    {
        protected ICanvas _canvas;
        public int[] Args { get; set; }

        public LineCommand(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public LineCommand(ICanvas canvas, int[] args)
        {
            _canvas = canvas;
            Args = args;
        }

        public void Execute()
        {
            _canvas.DrawLine(Args);
        }
    }
}
