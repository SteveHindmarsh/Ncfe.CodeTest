using Ncfe.CodeTest.DataAccess;
using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.Experimental
{
    /// <summary>
    /// Retrieves a Learner from the 'usual' Repository
    /// </summary>
    public class LearnerReadService : ILearnerReadService
    {
        ILearnerDataAccess _DataAccess;
        public LearnerReadService(ILearnerDataAccess dataAccess)
        {
            _DataAccess = dataAccess;
        }
        public Learner GetLearner(int learnerId)
        {
            return _DataAccess.LoadLearner(learnerId);
        }
    }
}
