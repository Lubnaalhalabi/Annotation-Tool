using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DataManager
{
    public interface IDataManager
    {
        public IEnumerable<string> Process(string path);
    }
}