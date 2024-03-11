using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.DataAccess
{
    /// <summary>
    /// Cannot change signature
    /// </summary>
    public class FailoverLearnerDataAccess : IFailoverLearnerDataAccess
    {
        //Removed as there is no current information defining this shared method (which makes testing more difficult) as necessary
        //public static LearnerResponse GetLearnerById(int id)
        //{
        //    // retrieve learner from database
        //    return new LearnerResponse();
        //}
        public Learner GetLearnerById(int id)
        {
            // retrieve learner from database
            return new Learner();
        }
    }
}
