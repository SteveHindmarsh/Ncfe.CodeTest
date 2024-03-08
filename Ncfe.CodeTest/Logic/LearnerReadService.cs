using Ncfe.CodeTest.DataAccess;
using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.Logic
{
    /// <summary>
    /// Retrieves a Learner from the 'usual' Repository
    /// </summary>
    public class LearnerReadService : ILearnerReadService
    {
        public LearnerReadService() {}
        public Learner GetLearner(int learnerId)
        {
            LearnerDataAccess dataAccess = new LearnerDataAccess();
            LearnerResponse learnerResponse = dataAccess.LoadLearner(learnerId);

            return learnerResponse?.Learner;
        }
    }
}
