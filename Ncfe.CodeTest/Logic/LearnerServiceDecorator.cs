using Ncfe.CodeTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest.Logic
{
    public abstract class LearnerServiceDecorator : ILearnerService
    {
        protected ILearnerService _LearnerService;
        public LearnerServiceDecorator(ILearnerService learnerService)
        {
            this._LearnerService = learnerService;
        }
        public virtual Learner GetLearner(int learnerId)//, bool isLearnerArchived)
        {
            return _LearnerService.GetLearner(learnerId);//, isLearnerArchived);
        }
    }
}
