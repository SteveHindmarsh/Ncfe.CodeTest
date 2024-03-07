using Ncfe.CodeTest.DataAccess;
using Ncfe.CodeTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest.Logic
{
    public class LearnerService : ILearnerService
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

        public virtual Learner GetLearner(int learnerId)
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

            LearnerResponse learnerResponse = null;
            //Learner learner = null;

            if (failedRequests > FailoverFailedRequestsTriggerCount && IsFailoverModeEnabled)
            {
                learnerResponse = FailoverLearnerDataAccess.GetLearnerById(learnerId);
            }
            else
            {
                LearnerDataAccess dataAccess = new LearnerDataAccess();
                learnerResponse = dataAccess.LoadLearner(learnerId);
            }

            //if (learnerResponse.IsArchived)
            //{
            //    //Why get it from the archive when the archive already got it from the LearnerDataAccess.
            //    ArchivedDataService archivedDataService = new ArchivedDataService();
            //    learner = archivedDataService.GetArchivedLearner(learnerId);
            //}
            //else
            //{
            //    learner = learnerResponse.Learner;
            //}

            //return learner;

            return learnerResponse?.Learner;
        }
    }
}
