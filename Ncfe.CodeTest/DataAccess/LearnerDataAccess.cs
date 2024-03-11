using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.DataAccess
{
    /// <summary>
    /// Cannot change signature
    /// </summary>
    public class LearnerDataAccess : ILearnerDataAccess
    {
        public Learner LoadLearner(int learnerId)
        {
            // rettrieve learner from 3rd party webservice
            return new Learner();
        }
    }
}
