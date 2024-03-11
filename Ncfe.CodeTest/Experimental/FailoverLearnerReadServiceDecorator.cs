using Ncfe.CodeTest.DataAccess;
using Ncfe.CodeTest.Model;
using System;
using System.Linq;

namespace Ncfe.CodeTest.Experimental
{
    /// <summary>
    /// Retrieves a Learner from the Failover Repository if active otherwise obtains the Learner from my wrappers implementation.
    /// </summary>
    public class FailoverLearnerReadServiceDecorator : BaseLearnerReadServiceDecorator
    {
        public bool IsFailoverModeEnabled { get; set; }
        public int FailoverFailedRequestsTriggerCount { get; set; }

        private IFailoverRepository _FailoverRepository { get; set; }
        private IFailoverLearnerDataAccess _FailoverLearnerDataAccess { get; set; }//TODO: Refactor method name to give same interface
        private ILearnerDataAccess _LearnerDataAccess { get; set; }//TODO: Refactor method name to give same interface

        public FailoverLearnerReadServiceDecorator(
            ILearnerReadService learnerReadService,
            bool isFailoverModeEnabled,
            int failoverFailedRequestsTriggerCount, 
            IFailoverRepository failoverRepository,
            IFailoverLearnerDataAccess failoverLearnerDataAccess,
            ILearnerDataAccess learnerDataAccess)
            : base(learnerReadService)
        {
            IsFailoverModeEnabled = isFailoverModeEnabled;
            FailoverFailedRequestsTriggerCount = failoverFailedRequestsTriggerCount;
            _FailoverRepository = failoverRepository;
            _FailoverLearnerDataAccess = failoverLearnerDataAccess;
            _LearnerDataAccess = learnerDataAccess;
        }

        public override Learner GetLearner(int learnerId)
        {
            var failedRequestsCount = _FailoverRepository.GetFailOverEntries().Count(failoverEntry => failoverEntry.DateTime > DateTime.Now.AddMinutes(-10));

            Learner learner = null;

            if (IsFailoverModeEnabled && failedRequestsCount > FailoverFailedRequestsTriggerCount)
                learner = _FailoverLearnerDataAccess.GetLearnerById(learnerId);
            else
                learner = _LearnerDataAccess.LoadLearner(learnerId);


            //This section of code, which retrieved an archived Learner if it was indicated as existing in the archive
            //on the LearnerResponse.IsArchived property, is intentionaly removed as the client already knows whether it
            //wants the archived version or not so the decision to obtain it should not also be made here, should it?
            //Question is there a difference between a usual or archived repo Learner?

            return learner;
        }
    }
}
