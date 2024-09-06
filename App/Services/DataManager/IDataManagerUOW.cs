using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DataManager
{
    public interface IDataManagerUOW
    {
        public Text TXT { get; set; }
        public CSV CSV { get; set; }

    }
}
