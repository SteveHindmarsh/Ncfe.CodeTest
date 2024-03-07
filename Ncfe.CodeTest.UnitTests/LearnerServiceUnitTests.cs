using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ncfe.CodeTest.Logic;
using Ncfe.CodeTest.Model;
using System;
using System.Configuration;

namespace Ncfe.CodeTest.UnitTests
{
    [TestClass]
    public class LearnerServiceUnitTests
    {
        [TestMethod]
        [DataRow(1,true,100)]
        [DataRow(1,false,100)]
        public void RetrieveLearner(
            int learnerId,
            bool isFailoverModeEnabled,
            int failoverFailedRequestsTriggerCount)
        {
            Learner learner;

            LearnerService learnerService = new LearnerService(isFailoverModeEnabled, failoverFailedRequestsTriggerCount);
            learner = learnerService.GetLearner(learnerId);
            Assert.IsNull(learner);

            ArchivedLearnerService archivedLearnerService = new ArchivedLearnerService(learnerService);
            learner = archivedLearnerService.GetLearner(learnerId);
            Assert.IsNotNull(learner);
        }

    }
}
