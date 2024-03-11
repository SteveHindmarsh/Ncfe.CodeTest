using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ncfe.CodeTest.Logic;
using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.UnitTests.LearnerTests
{
    [TestClass]
    public class LearnerServiceUnitTests
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void RetrieveLearnerFromArchivedLearnerService(
            int learnerId)
        {
            Learner learner;
            IArchivedDataService archivedDataService = new ArchivedDataService();
            learner = archivedDataService.GetArchivedLearner(learnerId);

            Assert.IsTrue(learner.Id == learnerId);
        }
        [TestMethod]
        [DataRow(0)]
        [DataRow(5)]
        public void RetrieveNullFromArchivedLearnerService(
            int learnerId)
        {
            Learner learner;
            IArchivedDataService archivedDataService = new ArchivedDataService();
            learner = archivedDataService.GetArchivedLearner(learnerId);

            Assert.IsNull(learner);
        }

        [TestMethod]
        [DataRow(1, true, 0, 0)]
        [DataRow(1, true, 0, 1)]
        public void LearnerServiceFailoverRepositoryIsTriggeredAndReturnsNull(
            int learnerId,
            bool isFailoverModeEnabled,
            int failoverFailedRequestsActualCount,
            int failoverFailedRequestsTriggerCount)
        {
            Learner learner;
            LearnerService learnerService = new LearnerService(
                isFailoverModeEnabled,
                failoverFailedRequestsTriggerCount,
                new FailoverRepository(failoverFailedRequestsActualCount),
                new FailoverLearnerDataAccess(),
                new LearnerDataAccess());

            learner = learnerService.GetLearner(learnerId);

            Assert.IsNull(learner);
        }

        [TestMethod]
        [DataRow(2, true, 0, 0)]
        [DataRow(2, true, 0, 1)]
        public void LearnerServiceFailoverRepositoryIsTriggered(
            int learnerId,
            bool isFailoverModeEnabled,
            int failoverFailedRequestsActualCount,
            int failoverFailedRequestsTriggerCount)
        {
            Learner learner;
            LearnerService learnerService = new LearnerService(
                isFailoverModeEnabled,
                failoverFailedRequestsTriggerCount,
                new FailoverRepository(failoverFailedRequestsActualCount),
                new FailoverLearnerDataAccess(),
                new LearnerDataAccess());

            learner = learnerService.GetLearner(learnerId);

            Assert.IsTrue(learner.Id == learnerId);
        }

        [TestMethod]
        [DataRow(1, false, 1, 2)]
        [DataRow(1, true, 1, 1)]
        public void LearnerServiceFailoverRepositoryIsNotTriggeredAndReturnsNull(
            int learnerId,
            bool isFailoverModeEnabled,
            int failoverFailedRequestsActualCount,
            int failoverFailedRequestsTriggerCount)
        {
            Learner learner;
            LearnerService learnerService = new LearnerService(
                isFailoverModeEnabled,
                failoverFailedRequestsTriggerCount,
                new FailoverRepository(failoverFailedRequestsActualCount),
                new FailoverLearnerDataAccess(),
                new LearnerDataAccess());

            learner = learnerService.GetLearner(learnerId);

            Assert.IsNull(learner);
        }

        [TestMethod]
        [DataRow(2, false, 1, 2)]
        [DataRow(2, true, 1, 2)]
        public void LearnerServiceFailoverRepositoryIsNotTriggered(
            int learnerId,
            bool isFailoverModeEnabled,
            int failoverFailedRequestsActualCount,
            int failoverFailedRequestsTriggerCount)
        {
            Learner learner;
            LearnerService learnerService = new LearnerService(
                isFailoverModeEnabled,
                failoverFailedRequestsTriggerCount,
                new FailoverRepository(failoverFailedRequestsActualCount),
                new FailoverLearnerDataAccess(),
                new LearnerDataAccess());

            learner = learnerService.GetLearner(learnerId);

            Assert.IsNotNull(learner);
            Assert.IsTrue(learner.Id == learnerId);
        }
    }
}
