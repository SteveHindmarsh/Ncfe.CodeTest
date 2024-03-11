using Ncfe.CodeTest.Model;
using System.Collections.Generic;

namespace Ncfe.CodeTest.UnitTests.LearnerTests
{
    internal class TestData 
    {
        public static List<Learner> GetConsectutiveLearners()
        {
            List<Learner> learners = new List<Learner>();
            learners.Add(new Learner() { Id = 1 });
            learners.Add(new Learner() { Id = 2 });
            learners.Add(new Learner() { Id = 3 });
            learners.Add(new Learner() { Id = 4 });
            return learners;
        }
        public static List<Learner> GetOddLearners()
        {
            List<Learner> learners = new List<Learner>();
            learners.Add(new Learner() { Id = 1 });
            learners.Add(new Learner() { Id = 3 });
            return learners;
        }
        public static List<Learner> GetEvenLearners()
        {
            List<Learner> learners = new List<Learner>();
            learners.Add(new Learner() { Id = 2 });
            learners.Add(new Learner() { Id = 4 });
            return learners;
        }
    }
}
