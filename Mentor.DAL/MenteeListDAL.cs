using Mentor.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor.DAL
{
    public class MenteeListDAL
    {
        string conString = DataUtil.connectionString;
        public List<MenteeListBE> getMenteeList = new List<MenteeListBE>();

        public List<MenteeListBE> Menteelist(int id)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(StoredProcedure.Names.SP_GET_MenteeList.ToString(), con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MemberId", id);
            con.Open();
            SqlDataReader sqr = cmd.ExecuteReader();

            //con.Open();
            //string query = $"select * from Member";


            //SqlCommand sqlCom = new SqlCommand(query, con);
            //SqlDataReader sqr = sqlCom.ExecuteReader();

            while (sqr.Read())
            {
                //string perHourRate = sqr.GetValue(0).ToString();
                string name = sqr.GetValue(1).ToString();
                string perHourRate = sqr.GetValue(2).ToString();
                string phoneNum = sqr.GetValue(3).ToString();  
                string catName = sqr.GetValue(5).ToString();
                string subCatName = sqr.GetValue(6).ToString();
                getMenteeList.Add(new MenteeListBE(name, perHourRate,phoneNum,catName,subCatName));
            }

            con.Close();
            return getMenteeList;

        }

        public static implicit operator List<object>(MenteeListDAL v)
        {
            throw new NotImplementedException();
        }
    }
}
