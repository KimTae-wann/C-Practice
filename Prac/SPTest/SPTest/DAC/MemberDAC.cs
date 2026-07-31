using SPTest.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTest.DAC
{
    class MemberDAC
    {
        private readonly string connStr;

        public MemberDAC()
        {
            connStr = ConfigurationManager.ConnectionStrings["SPTest"].ConnectionString;
        }

        public bool Register(string userId, string password, string name, string email)
        {
            using (SqlConnection con = new SqlConnection(connStr))

            using (SqlCommand cmd = new SqlCommand("dbo.RegisterMember", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);

                con.Open();
                object resultObj = cmd.ExecuteScalar();
                if (resultObj != null && int.TryParse(resultObj.ToString(), out int result))
                {
                    return result == 1;
                }

                return false;
            }
        }

        public MemberVO Login(string userId, string password)
        {
            using (SqlConnection con = new SqlConnection(connStr))

            using (SqlCommand cmd = new SqlCommand("dbo.Login", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@password", password);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MemberVO
                        {
                            UserId = reader["userId"].ToString(),
                            Name = reader["name"].ToString(),
                            Email = reader["email"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
}
