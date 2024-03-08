using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.Logic
{
    public class LearnerService 
    {
        public bool IsFailoverModeEnabled { get; set; }
        public int FailoverFailedRequestsTriggerCount { get; set; }
        public LearnerService(
            bool isFailoverModeEnabled,
            int failoverFailedRequestsTriggerCount) 
        {
            IsFailoverModeEnabled = isFailoverModeEnabled;
            FailoverFailedRequestsTriggerCount = failoverFailedRequestsTriggerCount;
        }
        public Learner GetLearner(int learnerId, bool isLearnerArchived)
        {
            Learner learner = null;
            if(isLearnerArchived)
            {
                ArchivedLearnerReadServiceDecorator archivedLearnerReadServiceDecorator = new ArchivedLearnerReadServiceDecorator(null);
                learner = archivedLearnerReadServiceDecorator.GetLearner(learnerId);
            }
            else
            {
                FailoverLearnerReadServiceDecorator failoverLearnerReadServiceDecorator = new FailoverLearnerReadServiceDecorator(new LearnerReadService(), IsFailoverModeEnabled, FailoverFailedRequestsTriggerCount);
                learner = failoverLearnerReadServiceDecorator.GetLearner(learnerId);
            }
            return learner;
        }
    }
}
