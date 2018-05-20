using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticCodeLibrary;

namespace GeneticCodeLibraryTests
{
    [TestClass]
    public class RnaStrandTranslateTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            RnaStrand testInstance = new RnaStrand("AUGCUAGGCAUCACCUGGUAG");
            string testresult = testInstance.Translate();
            Assert.AreEqual("Met Leu Gly Ile Thr Trp", testresult, "Expected: AUGCUAGGCAUCACCUGGUAG => Met Leu Gly Ile Thr Trp");
        }
    }
}
