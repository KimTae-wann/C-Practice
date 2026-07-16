using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using System.Configuration;

namespace Board
{
    class MemberDAC
    {
        private SqlConnection con = new SqlConnection();
        public MemberDAC()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MyBoard"].ConnectionString;
        }

        public bool Register(string userId, string password, string name, string email)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MYBoard"].ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.RegisterMember", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int result = Convert.ToInt32(ds.Tables[0].Rows[0]["Result"]);

                    return result == 1;
                }
                return false;
            }
        }

        public MemberVO Login(string userId, string password)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MYBoard"].ConnectionString))
            using (SqlCommand command = new SqlCommand("dbo.Login", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@password", password);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();

                adapter.Fill(ds);
                
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    return new MemberVO()
                    {
                        UserId = dr["userId"].ToString(),
                        Name = dr["name"].ToString(),
                        Email = dr["email"].ToString()
                    };
                }
                return null;
            }
        }
    }
}
