using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.BE
{
    public class MenteeListBE
    {
        //public string Id { get; set; }

        public string Name { get; set; }
        public string PerHourRate { get; set; }
        public string PhoneNum { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }

        //public string ProfilePic { get; set; }

        public MenteeListBE(string name,string perHourRate,string phoneNum,string catName,string subCatName)
        {
            this.Name = name;
            this.PerHourRate = perHourRate;
            this.PhoneNum = phoneNum;
            this.CategoryName = catName;
            this.SubCategoryName = subCatName;
        }


    }
}
