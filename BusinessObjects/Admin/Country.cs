using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.BusinessObjects
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public DateTime Created_On { get; set; }
        public string Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string Updated_By { get; set; }
    }
}
