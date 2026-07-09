using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using System.Configuration;

namespace _30DB
{
    //DAC(Data Access Component) : DB 연결 전담
    class Member
    {
        private SqlConnection con = new SqlConnection();
        public Member()
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MyCS"].ConnectionString;
        }

        public DataSet GetMembers()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("uspSelectAll", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }


        // TODO 
        public int Insert (string userId, string password, string name, string email)
        {
            con.Open();
            SqlCommand command = new SqlCommand
                ("INSERT INTO MEMBER (USERID, PASSWORD, NAME, EMAIL) VALUES (@p1, @p2, @p3, @p4)", con);
            command.Parameters.AddWithValue("@p1", userId);
            command.Parameters.AddWithValue("@p2", password);
            command.Parameters.AddWithValue("@p3", name);
            command.Parameters.AddWithValue("@p4", email);

            int r = command.ExecuteNonQuery();
            con.Close();

            return r;
        }
         
        public int Update(int id, string userId, string password, string name, string email)
        {
            con.Open();
            SqlCommand command = new SqlCommand
                ("UPDATE MEMBER SET USERID = @p1, PASSWORD = @p2, NAME = @p3, EMAIL=@p4 WHERE ID = @p5", con);

            command.Parameters.AddWithValue("@p1", userId);
            command.Parameters.AddWithValue("@p2", password);
            command.Parameters.AddWithValue("@p3", name);
            command.Parameters.AddWithValue("@p4", email);
            command.Parameters.AddWithValue("@p5", id);

            int r = command.ExecuteNonQuery();
            con.Close();
            return r;
        }
    }
}
