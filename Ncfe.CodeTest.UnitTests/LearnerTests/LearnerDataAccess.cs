using Ncfe.CodeTest.DataAccess;
using Ncfe.CodeTest.Model;
using System.Linq;

namespace Ncfe.CodeTest.UnitTests.LearnerTests
{
    public class LearnerDataAccess : ILearnerDataAccess
    {
        public Learner LoadLearner(int learnerId)
        {
            return TestData.GetEvenLearners().SingleOrDefault(x => x.Id==learnerId);
        }
    }
}
