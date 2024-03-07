using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace Ncfe.CodeTest.UnitTests
{
    [TestClass]
    public class LearnerServiceUnitTests
    {
        [TestMethod]
        [DataRow(true, 100, true)]
        [DataRow(false, 100, true)]
        public void RetrieveLearner(
            bool isFailoverModeEnabled,
            int failoverFailedRequestsTriggerCount,
            bool isArchived)
        {
            LearnerService learnerService = new LearnerService(isFailoverModeEnabled, failoverFailedRequestsTriggerCount);
            Learner learner = learnerService.GetLearner(1, isArchived);
            Assert.IsNotNull(learner);
        }
    }
}
