using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.Logic
{
    public interface ILearnerReadService
    {
        Learner GetLearner(int learnerId);
    }
}
