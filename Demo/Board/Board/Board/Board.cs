using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Board
{
    public partial class Board : Form
    {
        private DataSet ds;
        public Board()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=NETBoard;integrated security=true";

            SqlDataAdapter adapter = new SqlDataAdapter("select * from board", con);

            ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.DataSource = ds.Tables[0];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            var row = dataGridView1.Rows[e.RowIndex];
            string id = row.Cells["id"].Value?.ToString() ?? " ";

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=NETBoard;integrated security=true";
            SqlDataAdapter adapter = new SqlDataAdapter($"select * from board where id = {id}", con);

            ds = new DataSet();
            adapter.Fill(ds);

            DataRow dr = ds.Tables[0].Rows[0];
            string title = dr["title"]?.ToString() ?? "";
            string writer = dr["name"]?.ToString() ?? " ";
            string email = dr["email"]?.ToString() ?? "";
            string readCount = dr["readCount"]?.ToString() ?? "";
            string content = dr["content"]?.ToString() ?? "";
            string date = dr["iDate"]?.ToString() ?? "";

            UpdateBoardDlg detailForm = new UpdateBoardDlg(id, title, writer, email, readCount, content, date);
            detailForm.ShowDialog();
        }
    }
}
