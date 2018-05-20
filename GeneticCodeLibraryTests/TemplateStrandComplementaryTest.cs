using System;
using GeneticCodeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeneticCodeLibraryTests
{
    [TestClass]
    public class TemplateStrandComplementaryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TemplateStrand testInstance = new TemplateStrand("ACTGGTCAGTA"); 
            string testResult = testInstance.Complementary();
            // TGACCAGTCAT
            Assert.AreEqual(@"5'-TGACCAGTCAT-3'", testResult, @"Expected: ACTGGTCAGTA => 5'-TGACCAGTCAT-3'");
        }
    }
}
