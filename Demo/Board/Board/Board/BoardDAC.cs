using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class BoardDAC
    {
        private readonly string connStr = @"data source=(localdb)\MSSQLLocalDB;initial catalog=NETBoard;integrated security=true";

        public DataSet SelectAll()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                //SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM board", con);
                SqlCommand cmd = new SqlCommand("dbo.UP_SelectAllBoards", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
        }

        public BoardVO SelectOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                //string query = "SELECT * FROM board WHERE id = @id";
                //SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand("dbo.UP_SelectOneBoard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    return new BoardVO()
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = dr["name"]?.ToString() ?? "",
                        Email = dr["email"]?.ToString() ?? "",
                        Title = dr["title"]?.ToString() ?? "",
                        Content = dr["content"]?.ToString() ?? "",
                        Password = dr["password"]?.ToString() ?? "",
                        IDate = Convert.ToDateTime(dr["iDate"]),
                        ReadCount = Convert.ToInt32(dr["readCount"])
                    };
                }
                return null;
            }
        }

        public bool Insert(BoardVO board)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                //string query = "INSERT INTO board (name, email, title, content, password) VALUES (@name, @email, @title, @content, @password)";
                //SqlCommand cmd = new SqlCommand(query, con);

                SqlCommand cmd = new SqlCommand("dbo.UP_InsertBoard", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", board.Name);
                cmd.Parameters.AddWithValue("@email", board.Email);
                cmd.Parameters.AddWithValue("@title", board.Title);
                cmd.Parameters.AddWithValue("@content", board.Content);
                cmd.Parameters.AddWithValue("@password", board.Password);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(BoardVO board)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                //string query = "UPDATE board SET title = @title, content = @content WHERE id = @id AND password = @password";
                //SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand("dbo.UP_UpdateBoard", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", board.Id);
                cmd.Parameters.AddWithValue("@title", board.Title);
                cmd.Parameters.AddWithValue("@content", board.Content);
                cmd.Parameters.AddWithValue("@password", board.Password);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Delete(int id, string password)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                //string query = "DELETE FROM board WHERE id = @id AND password = @password";
                //SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmd = new SqlCommand("dbo.UP_DeleteBoard", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@password", password);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
