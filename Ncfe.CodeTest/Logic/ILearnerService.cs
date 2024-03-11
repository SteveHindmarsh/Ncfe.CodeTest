using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.Logic
{
    public interface ILearnerService
    {
        Learner GetLearner(int learnerId);
    }
}
