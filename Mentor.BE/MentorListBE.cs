using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.BE
{
    public class MentorListBE
    {
        //public List<string> _MyList { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public MentorListBE()
        {

        }
        public MentorListBE(string name,string email)
        {
            this.Name = name;
            this.Email = email;

        }
    }
}
