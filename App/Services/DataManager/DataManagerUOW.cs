using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DataManager
{
    public class DataManagerUOW : IDataManagerUOW
    {
        public Text TXT { get; set; }
        public CSV CSV { get; set; }
        public DataManagerUOW() { 
            TXT = new Text();
            CSV = new CSV();
        
        }
      
    }
}
