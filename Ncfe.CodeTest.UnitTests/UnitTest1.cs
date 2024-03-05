using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Ncfe.CodeTest.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LearnerService learnerService = new LearnerService();
            Learner learner = learnerService.GetLearner(1, true);
            Assert.IsNotNull(learner);
        }
        [TestMethod]
        public void TestMethod2()
        {
            LearnerService learnerService = new LearnerService();
            Learner learner = learnerService.GetLearner(1, false);
            Assert.IsNotNull(learner);
        }
    }
}
