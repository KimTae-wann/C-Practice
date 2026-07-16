using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class BoardDAC
    {
        // App.Config의 connectionStrings를 저장하기 위함
        private readonly string connStr;

        public BoardDAC()
        {
            // "MyBoard"에 해당하는 로컬 DB Server의 경로를 가져와서 저장
            connStr = ConfigurationManager.ConnectionStrings["MyBoard"].ConnectionString;
        }
        public DataSet SelectAllBoards()
        {
            // SqlConnection 으로 DB Server와 연경
            using (SqlConnection con = new SqlConnection(connStr))
            // dbo.SelectAllBoards 저장 프로시저를 사용해 DB로 보냄
            using (SqlCommand cmd = new SqlCommand("dbo.SelectAllBoards", con))
            {
                // 타입 명시
                cmd.CommandType = CommandType.StoredProcedure;

                // DB와 DataSet 사이에서 데이터를 채워주는 SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // 로컬 메모리
                DataSet ds = new DataSet();
                // adapter가 로컬 메모리에 query결과 채워줌
                adapter.Fill(ds);
                return ds;
            }
        }

        public BoardVO SelectOne(int id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("dbo.SelectOneBoard", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                // 여러개 골라진 경우
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // 첫 번째 행만 반환
                    DataRow dr = ds.Tables[0].Rows[0];
                    return new BoardVO()
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = dr["name"]?.ToString() ?? "",
                        Email = dr["email"]?.ToString() ?? "",
                        Title = dr["title"]?.ToString() ?? "",
                        Content = dr["content"]?.ToString() ?? "",
                        Password = dr["password"]?.ToString() ?? "",
                        ReadCount = Convert.ToInt32(dr["readCount"])
                    };
                }
                return null;
            }
        }

        public bool Insert(BoardVO board)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("dbo.InsertBoard", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", board.Name);
                cmd.Parameters.AddWithValue("@email", board.Email);
                cmd.Parameters.AddWithValue("@title", board.Title);
                cmd.Parameters.AddWithValue("@content", board.Content);
                cmd.Parameters.AddWithValue("@password", board.Password);
                cmd.Parameters.AddWithValue("@iDate", DateTime.Now);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool Update(BoardVO board)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("dbo.UpdateBoard", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", board.Id);
                cmd.Parameters.AddWithValue("@title", board.Title);
                cmd.Parameters.AddWithValue("@content", board.Content);
                cmd.Parameters.AddWithValue("@password", board.Password);
                cmd.Parameters.AddWithValue("@iDate", DateTime.Now);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Delete(int id, string password)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("dbo.DeleteBoard", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@password", password);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // 본인이 작성한 글인지 체크
        public bool SelfCheck(string id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("dbo.SelfCheck", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                // 선택한 글의 작성자를 가져옴
                string userId = cmd.ExecuteScalar().ToString();
                // 선택한 글의 작성자와 현재 로그인 된 사용자의 id가 같은 경우
                if (UserSession.CurrentUser.UserId.Equals(userId))
                {
                    return true;
                }
                return false;
            }
        }
    }
}