using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingProgram.CommandParser;

namespace DrawingProgramTest
{
    [TestClass]
    public class CommandParserTest
    {
        [TestMethod]
        public void InvalidCommandTypeReturnsNotSuccess()
        {
            var res = CommandParser.ParseCommand("Y");
            Assert.AreEqual<bool>(false, res.Success);
            Assert.AreEqual<string>(CommadParserErrorMsg.InvalidCommandType, res.ErrorMsg);
        }
    }
}
