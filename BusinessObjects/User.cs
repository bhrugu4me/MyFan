using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYFAN.BusinessObjects
{
    public class User
    {
        public long PK_User_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int UserEmpType { get; set; }
        public string Education { get; set; }
        public string Occupation { get; set; }
        public string MaritalStatus { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string Area { get; set; }
        public string OtherLocation { get; set; }
        public int IsOther { get; set; }
        public string ZipCode { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Fax { get; set; }
        public int IsVerified { get; set; }
        public DateTime Created_On { get; set; }
        public string Created_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string Updated_By { get; set; }
        public UserLogin UserLogin { get; set; }
        public UserType UserType { get; set; }
    }
}
