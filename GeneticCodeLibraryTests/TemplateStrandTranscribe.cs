using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticCodeLibrary;

namespace GeneticCodeLibraryTests
{
    [TestClass]
    public class TemplateStrandTranscribe
    {
        [TestMethod]
        public void TestMethod1()
        {
            TemplateStrand testInstance = new TemplateStrand("ACTGCATGGTA");
            string testResult = testInstance.Transcribe();
            Assert.AreEqual("UGACGUACCAU", testResult, "Expected: ACTGCATGGTA => UGACGUACCAU");
        }
    }
}
