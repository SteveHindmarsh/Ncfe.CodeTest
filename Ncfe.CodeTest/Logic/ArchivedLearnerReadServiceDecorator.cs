using Ncfe.CodeTest.DataAccess;
using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.Logic
{
    /// <summary>
    /// Retrieves a Learner from the Archive Repository
    /// </summary>
    public class ArchivedLearnerReadServiceDecorator : BaseLearnerReadServiceDecorator
    {
        public ArchivedLearnerReadServiceDecorator(ILearnerReadService learnerReadService) : base(learnerReadService) { }

        public override Learner GetLearner(int learnerId)
        {
            ArchivedDataService archivedDataService = new ArchivedDataService();
            Learner archivedLearner = archivedDataService.GetArchivedLearner(learnerId);

            return archivedLearner;
        }
    }
}
