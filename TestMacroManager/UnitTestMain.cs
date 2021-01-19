using NUnit.Framework;
using Ambiesoft;
using System.Collections.Generic;

namespace TestMacroManager
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
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