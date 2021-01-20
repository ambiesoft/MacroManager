using Ambiesoft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestMacroManager
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMacroManager()
        {
            Dictionary<string, string> macros = new Dictionary<string, string>();
            macros.Add("video", "movie.mp4");
            macros.Add("fps", 60.ToString());
            MacroManager macroManager = new MacroManager(macros);

            string input = "aaa ${video} fps=${fps}";
            string ret = macroManager.Deploy(input);
            Assert.AreEqual(ret, "aaa movie.mp4 fps=60");
        }
    }
}
