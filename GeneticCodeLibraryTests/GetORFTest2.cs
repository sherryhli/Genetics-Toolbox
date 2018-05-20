using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticCodeLibrary;

namespace GeneticCodeLibraryTests
{
    [TestClass]
    public class GetORFTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            CodingStrand testInstance = new CodingStrand("ACGT");
            Assert.ThrowsException<Exception>(() => testInstance.GetOpenReadingFrame());

        }
    }
}
