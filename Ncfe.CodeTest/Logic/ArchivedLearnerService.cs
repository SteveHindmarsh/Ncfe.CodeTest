using Ncfe.CodeTest.DataAccess;
using Ncfe.CodeTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest.Logic
{
    public class ArchivedLearnerService : LearnerServiceDecorator
    {
        public ArchivedLearnerService(ILearnerService learnerService) : base(learnerService) { }

        public override Learner GetLearner(int learnerId)
        {
            //return new Learner($"ArchiveLearner({base.GetLearner(learnerId, isLearnerArchived).Id})");

            Learner archivedLearner = null;

            //if (isLearnerArchived)
            //{
                ArchivedDataService archivedDataService = new ArchivedDataService();
                archivedLearner = archivedDataService.GetArchivedLearner(learnerId);

                return archivedLearner;
            //}
            //else
            //{
            //    FailoverRepository failoverRespository = new FailoverRepository();
            //    List<FailoverEntry> failoverEntries = failoverRespository.GetFailOverEntries();

            //    int failedRequests = 0;

            //    foreach (FailoverEntry failoverEntry in failoverEntries)
            //    {
            //        if (failoverEntry.DateTime > DateTime.Now.AddMinutes(-10))
            //        {
            //            failedRequests++;
            //        }
            //    }

            //    LearnerResponse learnerResponse = null;
            //    Learner learner = null;

            //    if (failedRequests > FailoverFailedRequestsTriggerCount && IsFailoverModeEnabled)
            //    {
            //        learnerResponse = FailoverLearnerDataAccess.GetLearnerById(learnerId);
            //    }
            //    else
            //    {
            //        LearnerDataAccess dataAccess = new LearnerDataAccess();
            //        learnerResponse = dataAccess.LoadLearner(learnerId);
            //    }

            //    if (learnerResponse.IsArchived)
            //    {
            //        ArchivedDataService archivedDataService = new ArchivedDataService();
            //        learner = archivedDataService.GetArchivedLearner(learnerId);
            //    }
            //    else
            //    {
            //        learner = learnerResponse.Learner;
            //    }

            //    return learner;
            //}
        }
    }
}
