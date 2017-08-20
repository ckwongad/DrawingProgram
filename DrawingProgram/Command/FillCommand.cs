using DrawingProgram.Canvas;
using DrawingProgram.Command.CommandArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Command
{
    public class FillCommand : ICommand
    {
        protected SimpleCanvas _canvas;
        public FillCommandArgs FillCommandArgs { get; set; }

        public FillCommand(SimpleCanvas canvas)
        {
            _canvas = canvas;
        }

        public FillCommand(SimpleCanvas canvas, FillCommandArgs args)
        {
            _canvas = canvas;
            FillCommandArgs = args;
        }

        public void Execute()
        {
            _canvas.Fill(FillCommandArgs);
        }
    }
}
