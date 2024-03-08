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
        [DataRow(1)]
        [DataRow(1)]
        //TODO...more data
        public void RetrieveLearnerFromStandardRepository(
            int learnerId)
        {
            Learner learner;
            LearnerReadService learnerReadService = new LearnerReadService();
            learner = learnerReadService.GetLearner(learnerId);
            Assert.IsNotNull(learner);
        }

        [TestMethod]
        [DataRow(1, true, 1)]
        [DataRow(1, false, 100)]
        //TODO...more data
        public void RetrieveLearnerFromFailoverRepository(
            int learnerId,
            bool isFailoverModeEnabled,
            int failoverFailedRequestsTriggerCount)
        {
            Learner learner;
            FailoverLearnerReadServiceDecorator failoverLearnerReadServiceDecorator = new FailoverLearnerReadServiceDecorator(new LearnerReadService(), isFailoverModeEnabled, failoverFailedRequestsTriggerCount);
            learner = failoverLearnerReadServiceDecorator.GetLearner(learnerId);
            Assert.IsNotNull(learner);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(1)]
        //TODO...more data
        public void RetrieveLearnerFromArchiveRepository(
            int learnerId)
        {
            Learner learner;
            ArchivedLearnerReadServiceDecorator archivedLearnerReadServiceDecorator = new ArchivedLearnerReadServiceDecorator(null);
            learner = archivedLearnerReadServiceDecorator.GetLearner(learnerId);
            Assert.IsNotNull(learner);
        }

        [TestMethod]
        [DataRow(1, true, 1, true)]
        [DataRow(1, false, 100, false)]
        //TODO...more data
        public void RetrieveLearner(
            int learnerId,
            bool isFailoverModeEnabled,
            int failoverFailedRequestsTriggerCount,
            bool isLearnerArchived)
        {
            Learner learner;
            LearnerService learnerService = new LearnerService(isFailoverModeEnabled,failoverFailedRequestsTriggerCount);
            learner = learnerService.GetLearner(learnerId,isLearnerArchived);
            Assert.IsNotNull(learner);
        }

        //TODO: Lots of other tests...e.g. MOQ's to test Failover collection and other DataAccess repos...
    }
}
