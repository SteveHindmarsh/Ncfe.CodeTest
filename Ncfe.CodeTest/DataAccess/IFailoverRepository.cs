using System.Collections.Generic;

namespace Ncfe.CodeTest.DataAccess
{
    public interface IFailoverRepository
    {
        List<FailoverEntry> GetFailOverEntries();
    }
}
