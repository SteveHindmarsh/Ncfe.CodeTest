using Ncfe.CodeTest.Model;

namespace Ncfe.CodeTest.Logic
{
    /// <summary>
    /// Cannot change signature
    /// </summary>
    public interface IArchivedDataService
    {
        Learner GetArchivedLearner(int learnerId);
    }
}
