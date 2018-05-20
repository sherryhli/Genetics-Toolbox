using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticCodeLibrary;

namespace GeneticCodeLibraryTests
{
    [TestClass]
    public class CodingStrandComplementaryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CodingStrand testInstance = new CodingStrand("GAGATGCCTACTGACTAGT");
            string testResult = testInstance.Complementary();
            Assert.AreEqual(@"5'-ACTAGTCAGTAGGCATCTC-3'", testResult, @"Expected: GAGATGCCTACTGACTAGT => 5'-ACTAGTCAGTAGGCATCTC-3'");
            
        }
    }
}
