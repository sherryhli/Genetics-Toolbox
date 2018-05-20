using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticCodeLibrary;

namespace GeneticCodeLibraryTests
{
    [TestClass]
    public class GetORFTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CodingStrand testInstance = new CodingStrand("GAGATGCCTACTGACTAGT");
            string testResult = testInstance.GetOpenReadingFrame();
            Assert.AreEqual("GAG|ATGCCTACTGACTAG|T", testResult, "Expected: GAGATGCCTACTGACTAGT => GAG|ATGCCTACTGACTAG|T");
        }
    }
}
