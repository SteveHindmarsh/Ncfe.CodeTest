using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest
{
    //public class LearnerService2
    //{
    //    public Learner GetLearner(int learnerId)//, bool isLearnerArchived)
    //    {
    //        //1st, Does the Learner exist in the Archive, if so get it from there and don't even try the 3rd party store.

    //        Learner archivedLearner = null;

    //        if (isLearnerArchived)
    //        {
    //            var archivedDataService = new ArchivedDataService();
    //            archivedLearner = archivedDataService.GetArchivedLearner(learnerId);

    //            return archivedLearner;
    //        }
    //        else
    //        {

    //            var failoverRespository = new FailoverRepository();
    //            var failoverEntries = failoverRespository.GetFailOverEntries();


    //            var failedRequests = 0;

    //            foreach (var failoverEntry in failoverEntries)
    //            {
    //                if (failoverEntry.DateTime > DateTime.Now.AddMinutes(-10))
    //                {
    //                    failedRequests++;
    //                }
    //            }

    //            LearnerResponse learnerResponse = null;
    //            Learner learner = null;

    //            if (failedRequests > 100 && (ConfigurationManager.AppSettings["IsFailoverModeEnabled"] == "true" || ConfigurationManager.AppSettings["IsFailoverModeEnabled"] == "True"))
    //            {
    //                learnerResponse = FailoverLearnerDataAccess.GetLearnerById(learnerId);
    //            }
    //            else
    //            {
    //                var dataAccess = new LearnerDataAccess();
    //                learnerResponse = dataAccess.LoadLearner(learnerId);


    //            }

    //            if (learnerResponse.IsArchived)
    //            {
    //                var archivedDataService = new ArchivedDataService();
    //                learner = archivedDataService.GetArchivedLearner(learnerId);
    //            }
    //            else
    //            {
    //                learner = learnerResponse.Learner;
    //            }


    //            return learner;
    //        }
    //    }

    //}

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

            //Option 1 the design is good so refactor what we have
            Learner archivedLearner = null;

            if (isLearnerArchived)
            {
                ArchivedDataService archivedDataService = new ArchivedDataService();
                archivedLearner = archivedDataService.GetArchivedLearner(learnerId);

                return archivedLearner;
            }
            else
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
                Learner learner = null;

                if (failedRequests > FailoverFailedRequestsTriggerCount && IsFailoverModeEnabled)
                {
                    learnerResponse = FailoverLearnerDataAccess.GetLearnerById(learnerId);
                }
                else
                {
                    LearnerDataAccess dataAccess = new LearnerDataAccess();
                    learnerResponse = dataAccess.LoadLearner(learnerId);
                }

                if (learnerResponse.IsArchived)
                {
                    ArchivedDataService archivedDataService = new ArchivedDataService();
                    learner = archivedDataService.GetArchivedLearner(learnerId);
                }
                else
                {
                    learner = learnerResponse.Learner;
                }


                return learner;
            }
        }

    }
}
