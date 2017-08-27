using DrawingProgram.Command.CommandArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Canvas
{
    public interface ICanvas
    {
        void CreateCanvas(int[] args);
        void DrawLine(int[] args);
        void DrawRectangle(int[] args);
        void Fill(FillCommandArgs fillCommandArgs);
        void Print();
    }
}
