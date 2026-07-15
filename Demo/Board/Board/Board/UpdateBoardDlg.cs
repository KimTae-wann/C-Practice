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
    public partial class UpdateBoardDlg : Form
    {
        public UpdateBoardDlg()
        {
            InitializeComponent();
        }
        public UpdateBoardDlg(string id, string title, string writer, string email, string readCount, string content, string date)
        {
            InitializeComponent();

            idLabel.Text = id;
            titleTextBox.Text = title;
            nameTextBox.Text = writer;
            emailTextBox.Text = email;
            inputReadCountLabel.Text = readCount;
            contentTextBox.Text = content;
            iDateLabel.Text = date;
        }

        private void UpdateBoardDlg_Load(object sender, EventArgs e)
        {
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string password = passwordTextBox.Text;

            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=NETBoard;integrated security=true";

            SqlDataAdapter adapter = new SqlDataAdapter("update ");

        }

        private void closeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
