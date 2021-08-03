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
    public class DropDownPopulate
    {
        string conString = DataUtil.connectionString;

        public List<SelectedList> GetCareerLevelList()
        {
            List<SelectedList> levels = new List<SelectedList>();

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(StoredProcedure.Names.SP_GET_MemberCareerLevel.ToString(), con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();
            levels.Add(new SelectedList
            {
                Value = "0",
                Text = "Select Career Level"
            });
            while (read.Read())
            {
                levels.Add(new SelectedList
                {
                    Value = read["MemberCareerLevelId"].ToString(),
                    Text = read["MemberCareerLevel"].ToString()
                });
            }
            con.Close();
            return levels;
        }

       
       
        public List<SelectedListDomain> GetDomainList()
        {
            List<SelectedListDomain> domain = new List<SelectedListDomain>();

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(StoredProcedure.Names.SP_GET_MemberDomain.ToString(), con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                domain.Add(new SelectedListDomain
                {
                    Value = "0",
                    Text = "Select Domain",
                    CareerLevelId = 0
                });
                while (read.Read())
                {
                    domain.Add(new SelectedListDomain
                    {
                        Value = read["MemberDomainId"].ToString(),
                        Text = read["MemberDomainName"].ToString(),
                        CareerLevelId = Convert.ToInt32(read["MembercareerlevelId_FK"])
                    });
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            con.Close();
            return domain;
        }

       

        public List<SelectedList> GetCareerLevelForMenteeList()
        {
            List<SelectedList> levels = new List<SelectedList>();

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(StoredProcedure.Names.SP_GET_MemberCareerLevel.ToString(), con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                levels.Add(new SelectedList
                {
                    Value = read["MemberCareerLevelId"].ToString(),
                    Text = read["MemberCareerLevel"].ToString()
                });
            }
            con.Close();
            return levels;
        }
    }
}
