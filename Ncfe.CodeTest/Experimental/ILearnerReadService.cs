using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.Experimental
{
    public interface ILearnerReadService
    {
        Learner GetLearner(int learnerId);
    }
}
