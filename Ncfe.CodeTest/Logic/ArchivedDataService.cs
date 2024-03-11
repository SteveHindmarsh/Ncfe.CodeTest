using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.Logic
{
    /// <summary>
    /// Cannot change signature
    /// </summary>
    public class ArchivedDataService: IArchivedDataService
    {
        public Learner GetArchivedLearner(int learnerId)
        {
            // retrieve learner from archive data service
            return new Learner();
        }
    }
}
