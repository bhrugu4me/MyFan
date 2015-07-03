using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.BusinessObjects
{
    public class State
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public Country Country { get; set; }
        public DateTime Created_On { get; set; }
        public string Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string Updated_By { get; set; }
    }
}
