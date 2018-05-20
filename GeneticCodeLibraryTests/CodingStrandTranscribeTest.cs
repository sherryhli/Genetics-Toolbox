using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticCodeLibrary;

namespace GeneticCodeLibraryTests
{
    [TestClass]
    public class CodingStrandTranscribeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CodingStrand testInstance = new CodingStrand("ACTGGATCGTA");
            string testResult = testInstance.Transcribe();
            Assert.AreEqual("ACUGGAUCGUA", testResult, "Expected: ACTGGATCGTA => ACUGGAUCGUA");
        }
    }
}
