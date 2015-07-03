using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MYFAN.BusinessObjects
{
    public class MyFanCommon
    {
        public enum eMemberType
        {
            Normal,
            Business,
            Professional
        }

        public enum eBasicMemberType
        {
            Employed,
            JobSeeker,
            Student,
            Other
        }

        public enum eBusinessTypePage
        {
            Local,
            Institute,
            Brand,
            Community
        }

        public enum eProfessionalType
        {
            Artist,
            Skilled,
            Celebrities
        }

        public enum eParentCategory
        { 
            Category1 = 1,
            Category2 = 2
        }
    }
}