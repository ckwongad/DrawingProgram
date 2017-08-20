using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingProgram.Printer;

namespace DrawingProgramTest
{
    [TestClass]
    public class StringPrinterTest
    {
        StringPrinter printer;

        [TestInitialize]
        public void SetupStringPrinter()
        {
            printer = new StringPrinter();
        }

        [TestMethod]
        public void WriteSuccess()
        {
            printer.Write('a');
            printer.Write('b');
            printer.Write('c');

            Assert.AreEqual<string>("abc", printer.ToString());
        }

        [TestMethod]
        public void WriteLineSuccess()
        {
            printer.Write('a');
            printer.Write('b');
            printer.Write('c');
            printer.NextLine();
            printer.Write('d');
            printer.NextLine();

            Assert.AreEqual<string>("abc\r\nd\r\n", printer.ToString());
        }
    }
}
