using Ncfe.CodeTest.DataAccess;
using Ncfe.CodeTest.Model;
using System.Linq;

namespace Ncfe.CodeTest.UnitTests.LearnerTests
{
    public class FailoverLearnerDataAccess : IFailoverLearnerDataAccess
    {
        public Learner GetLearnerById(int id)
        {
            return TestData.GetOddLearners().SingleOrDefault(x => x.Id==id);
        }
    }
}
