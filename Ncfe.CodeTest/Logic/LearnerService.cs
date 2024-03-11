using Ncfe.CodeTest.DataAccess;
using Ncfe.CodeTest.Model;
using System;
using System.Linq;

namespace Ncfe.CodeTest.Logic
{
    public class LearnerService : ILearnerService
    {
        public bool IsFailoverModeEnabled { get; set; }
        public int FailoverFailedRequestsTriggerCount { get; set; }

        private IFailoverRepository _FailoverRepository { get; set; }
        private IFailoverLearnerDataAccess _FailoverLearnerDataAccess { get; set; }//TODO: Refactor method name to give same interface
        private ILearnerDataAccess _LearnerDataAccess { get; set; }//TODO: Refactor method name to give same interface

        public LearnerService(
            bool isFailoverModeEnabled,
            int failoverFailedRequestsTriggerCount,
            IFailoverRepository failoverRepository,
            IFailoverLearnerDataAccess failoverLearnerDataAccess,
            ILearnerDataAccess learnerDataAccess
            )
        {
            IsFailoverModeEnabled = isFailoverModeEnabled;
            FailoverFailedRequestsTriggerCount = failoverFailedRequestsTriggerCount;
            _FailoverRepository = failoverRepository;
            _FailoverLearnerDataAccess = failoverLearnerDataAccess;
            _LearnerDataAccess = learnerDataAccess;
        }
        public Learner GetLearner(int learnerId)
        {
            var totalCount = _FailoverRepository.GetFailOverEntries().Count();
            var failedRequestsCount = _FailoverRepository.GetFailOverEntries().Count(failoverEntry => failoverEntry.DateTime > DateTime.Now.AddMinutes(-10));

            Learner learner = null;

            if (IsFailoverModeEnabled && failedRequestsCount > FailoverFailedRequestsTriggerCount)
                learner = _FailoverLearnerDataAccess.GetLearnerById(learnerId);
            else
                learner = _LearnerDataAccess.LoadLearner(learnerId);

            return learner;
        }
    }
}
