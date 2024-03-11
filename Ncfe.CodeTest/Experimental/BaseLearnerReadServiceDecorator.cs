using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.Experimental
{
    public abstract class BaseLearnerReadServiceDecorator
    {
        private ILearnerReadService _LearnerReadService;
        public BaseLearnerReadServiceDecorator(ILearnerReadService learnerReadService)
        {
            this._LearnerReadService = learnerReadService;
        }
        public virtual Learner GetLearner(int learnerId)
        {
            return _LearnerReadService.GetLearner(learnerId);
        }
    }
}
