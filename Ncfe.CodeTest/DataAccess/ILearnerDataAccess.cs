using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.DataAccess
{
    /// <summary>
    /// Cannot change signature
    /// LearnerDataAccess cannot implement IGetLearnerResponse as its method name is LoadLearner! Would want to change this to simply code by getting rid of ILearnerDataAccess
    /// </summary>
    public interface ILearnerDataAccess
    {
        Learner LoadLearner(int learnerId);
    }
}
