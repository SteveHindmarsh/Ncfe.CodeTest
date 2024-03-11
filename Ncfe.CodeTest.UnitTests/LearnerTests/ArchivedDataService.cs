using Ncfe.CodeTest.Logic;
using Ncfe.CodeTest.Model;
using System.Linq;

namespace Ncfe.CodeTest.UnitTests.LearnerTests
{
    public class ArchivedDataService: IArchivedDataService
    {
        public Learner GetArchivedLearner(int learnerId)
        {
            return TestData.GetConsectutiveLearners().SingleOrDefault( x => x.Id==learnerId);
        }
    }
}
