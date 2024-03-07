using Ncfe.CodeTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ncfe.CodeTest.Logic
{
    public interface ILearnerService
    {
        Learner GetLearner(int learnerId);
    }
}
