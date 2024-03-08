using Ncfe.CodeTest.DataAccess;
using Ncfe.CodeTest.Model;
using System;
using System.Collections.Generic;

namespace Ncfe.CodeTest.Logic
{
    /// <summary>
    /// Retrieves a Learner from the Failover Repository if active otherwise obtains the Learner from my wrappers implementation.
    /// </summary>
    public class FailoverLearnerReadServiceDecorator : BaseLearnerReadServiceDecorator
    {
        public bool IsFailoverModeEnabled { get; set; }
        public int FailoverFailedRequestsTriggerCount { get; set; }
        public FailoverLearnerReadServiceDecorator(
            ILearnerReadService learnerReadService,
            bool isFailoverModeEnabled,
            int failoverFailedRequestsTriggerCount)
            : base(learnerReadService)
        {
            IsFailoverModeEnabled = isFailoverModeEnabled;
            FailoverFailedRequestsTriggerCount = failoverFailedRequestsTriggerCount;
        }

        public override Learner GetLearner(int learnerId)
        {
            FailoverRepository failoverRespository = new FailoverRepository();
            List<FailoverEntry> failoverEntries = failoverRespository.GetFailOverEntries();

            int failedRequests = 0;

            foreach (FailoverEntry failoverEntry in failoverEntries)
            {
                if (failoverEntry.DateTime > DateTime.Now.AddMinutes(-10))
                {
                    failedRequests++;
                }
            }

            Learner learner = null;

            if (failedRequests > FailoverFailedRequestsTriggerCount && IsFailoverModeEnabled)
            {
                LearnerResponse learnerResponse = FailoverLearnerDataAccess.GetLearnerById(learnerId);
                learner = learnerResponse?.Learner;
            }
            else
            {
                learner = base.GetLearner(learnerId);
            }

            //This section of code, which retrieved an archived Learner if it was indicated as existing in the archive
            //on the LearnerResponse.IsArchived property, is intentionaly removed as the client already knows whether it
            //wants the archived version or not so the decision to obtain it should not also be made here, should it?
            //Question is there a difference between a usual or archived repo Learner?

            return learner;
        }
    }
}
