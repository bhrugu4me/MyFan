using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.BusinessObjects
{
    public class UserLogin
    {
        public long PK_User_Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }
        public AuthType AuthType { get; set; }
    }
}
