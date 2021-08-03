using Mentor.BE;
using Mentor.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.DAL
{
    public class JobListDAL

    {
        public AddJobBE GetJobBE(int JobID)
        {
            AddJobBE updJob = new AddJobBE();
            string conString = DataUtil.connectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(StoredProcedure.Names.SP_GET_MarketJob.ToString(), con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@MarketJobsId", JobID);
            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {

                    updJob.JobID = Convert.ToInt32(read["MarketJobsId"].ToString());
                    updJob.MemberId = Convert.ToInt32(read["MemberId_fk"].ToString());
                    updJob.MemberCareerLevel = Convert.ToInt32(read["MemberCareerLevelId_fk"].ToString());
                    updJob.MemberDomain = Convert.ToInt32(read["MemberDomainId_fk"].ToString());
                    updJob.Category = Convert.ToInt32(read["CategoryId_fk"].ToString());
                    updJob.SubCategory = Convert.ToInt32(read["SubCategoryId_fk"].ToString());
                    updJob.Title = read["Title"].ToString();
                    updJob.Company = read["Company"].ToString();
                    updJob.ComEmail = read["CompanyEmail"].ToString();
                    updJob.City = read["City"].ToString();
                    updJob.RequiredExperience = Convert.ToInt32(read["RequiredExperienceId_fk"].ToString());
                    updJob.JobKPIS = read["Job_KPIS"].ToString();
                    updJob.AppClosingDate = read["ApplicationClosingDate"].ToString();
                    updJob.IsPublic = Convert.ToInt32(read["IsPublic"]);
                }
            }

            else
            {
                Console.WriteLine("No rows found");
            }
            con.Close();
            return updJob;


        }

        public List<MyJobList> myJobLists(int memID)
        {

            List<MyJobList> jobLists = new List<MyJobList>();
            string conString = DataUtil.connectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(StoredProcedure.Names.SP_GET_MarketJobs.ToString(), con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@MentorId", memID);
            


            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    MyJobList jobList = new MyJobList();
                    jobList.MemberId = memID;
                    jobList.MarketJobID = Convert.ToInt32(read["MarketJobsId"]);
                    //jobList.MarketJobID = Convert.ToInt32(read["MarketJobsId"]);
                    jobList.MemberCareerLevelId = Convert.ToInt32(read["MemberCareerLevelId_fk"]);
                    jobList.MemberCareerLevelName = read["MemberCareerLevel"].ToString();
                    jobList.MemberDomainId = Convert.ToInt32(read["MemberDomainId_fk"]);
                    jobList.MemberDomainName = read["MemberDomainName"].ToString(); ;
                    jobList.CategoryID = Convert.ToInt32(read["CategoryId_fk"]);
                    jobList.CategoryName = read["CategoryName"].ToString();
                    jobList.SubCategoryId = Convert.ToInt32(read["SubCategoryId_fk"]);
                    jobList.SubCategoryName = read["SubCategoryName"].ToString();
                    jobList.Company = read["Company"].ToString();
                    jobList.Title = read["Title"].ToString();
                    jobList.AppClosingDate = read["ApplicationClosingDate"].ToString();
                    jobLists.Add(jobList);
                }
            }

            else
            {
                Console.WriteLine("No rows found");
            }
            con.Close();
            return jobLists;

        }
        public List<MyJobList> joblistbyID (int memID , int menteeid)
        {

            List<MyJobList> jobLists = new List<MyJobList>();
            string conString = DataUtil.connectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(StoredProcedure.Names.SP_GET_MarketJobstest.ToString(), con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@MentorId", memID);
            cmd.Parameters.AddWithValue("@MenteeId", menteeid);


            SqlDataReader read = cmd.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    MyJobList jobList = new MyJobList();
                    jobList.MemberId = memID;
                    jobList.MarketJobID = Convert.ToInt32(read["MarketJobsId"]);
                    //jobList.MarketJobID = Convert.ToInt32(read["MarketJobsId"]);
                    jobList.MemberCareerLevelId = Convert.ToInt32(read["MemberCareerLevelId_fk"]);
                    jobList.MemberCareerLevelName = read["MemberCareerLevel"].ToString();
                    jobList.MemberDomainId = Convert.ToInt32(read["MemberDomainId_fk"]);
                    jobList.MemberDomainName = read["MemberDomainName"].ToString(); ;
                    jobList.CategoryID = Convert.ToInt32(read["CategoryId_fk"]);
                    jobList.CategoryName = read["CategoryName"].ToString();
                    jobList.SubCategoryId = Convert.ToInt32(read["SubCategoryId_fk"]);
                    jobList.SubCategoryName = read["SubCategoryName"].ToString();
                    jobList.Company = read["Company"].ToString();
                    jobList.Title = read["Title"].ToString();
                    jobList.AppClosingDate = read["ApplicationClosingDate"].ToString();
                    jobLists.Add(jobList);
                }
            }

            else
            {
                Console.WriteLine("No rows found");
            }
            con.Close();
            return jobLists;

        }

        //Update Job
        public void UpdateJob(int Mem_ID, int Job_ID)
        {

            string conString = DataUtil.connectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(StoredProcedure.Names.SP_MarketJobs_Insert_Update_Delete.ToString(), con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MarketJobsId", Job_ID);
            cmd.Parameters.AddWithValue("@MemberId", Mem_ID);
            //var ResponseId = cmd.Parameters.Add("@ResponseId", SqlDbType.Int);
            //ResponseId.Direction = ParameterDirection.ReturnValue;
            //var Response = cmd.Parameters.Add("@Response", SqlDbType.VarChar);
            //Response.Direction = ParameterDirection.ReturnValue;

            try
            {
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception exp)
            {
                con.Close();
                throw exp;
            }
            //finally
            //{
            //    con.Close();
            //}
        }
        //Delete Job
        public void Deletejob(int Mem_ID, int Job_ID)
        {

            string conString = DataUtil.connectionString;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(StoredProcedure.Names.SP_MarketJobs_Insert_Update_Delete.ToString(), con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@MarketJobsId", Job_ID);
            cmd.Parameters.AddWithValue("@MemberId", Mem_ID);

            //var ResponseId = cmd.Parameters.Add("@ResponseId", SqlDbType.Int);
            //ResponseId.Direction = ParameterDirection.ReturnValue;
            //var Response = cmd.Parameters.Add("@Response", SqlDbType.VarChar);
            //Response.Direction = ParameterDirection.ReturnValue;

            try
            {
                con.Open();
                //SqlDataReader read = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception exp)
            {
                con.Close();
                throw exp;
            }


            finally
            {
                con.Close();
            }
        }
    }




}
