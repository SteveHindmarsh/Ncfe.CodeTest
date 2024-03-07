namespace Ncfe.CodeTest
{
    /// <summary>
    /// Cannot change signature
    /// </summary>
    public class FailoverLearnerDataAccess
    {
        public static LearnerResponse GetLearnerById(int id)
        {
            // retrieve learner from database
            return new LearnerResponse();
        }
    }
}
