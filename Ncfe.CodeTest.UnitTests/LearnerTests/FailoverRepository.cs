using Ncfe.CodeTest.DataAccess;
using System;
using System.Collections.Generic;

namespace Ncfe.CodeTest.UnitTests.LearnerTests
{
    public class FailoverRepository: IFailoverRepository
    {
        private int _FailoverEntryCount;
        private List<FailoverEntry> _FailoverEntryList;
        public FailoverRepository(int failoverEntryCount)
        {
            _FailoverEntryCount = failoverEntryCount;
            _FailoverEntryList = new List<FailoverEntry>();
            for (int i = 0; i < _FailoverEntryCount; i++)
            {
                _FailoverEntryList.Add(new FailoverEntry() { DateTime = DateTime.Now});//TODO: Perhaps need way of setting varying dates
            }
        }
        public List<FailoverEntry> GetFailOverEntries()
        {
            return _FailoverEntryList;
        }
    }
}
