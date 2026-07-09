using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _30DB
{
    public partial class Form1 : Form
    {
        private DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // DataSet : Connection-DataAdapter-DataSet
            SqlConnection con = new SqlConnection();
            // Window
            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=Test;integrated security=true";
            // Mixed
            //con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=Test;user id=sa;password=1234";


            SqlDataAdapter adapter = new SqlDataAdapter("select * from member", con);
            //SqlCommand command = new SqlCommand("select * from member", con);
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //adapter.SelectCommand = command;


            ds = new DataSet();
            adapter.Fill(ds, "Mem"); // DataSet이 생성됨-select문을 실행해서
            // 바인딩
            dataGridView1.DataSource = ds.Tables[0];
            listBox1.DisplayMember = "UserID";
            listBox1.DataSource = ds.Tables[0];
            // 위에서 바인딩 해서 얻어올 수 있음
            listBox1.DataSource = ds.Tables["Mem"];

            listBox2.Items.Clear();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                listBox2.Items.Add(r[1] + "\t" + r["Name"]);
            }
            label1.Text = ds.Tables[0].Rows.Count.ToString();

            // 현재 데이터를 xml로 저장 
            ds.WriteXml("mem.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DataReader : Connection-Command-DataReader
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=Test;integrated security=true";

            SqlCommand command = new SqlCommand("select * from member", con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader(); // Reader 생성
            listBox2.Items.Clear();
            while (reader.Read())
            {
                listBox2.Items.Add(reader[1] + "\t" + reader["Name"]);
            }
            con.Close();

            SqlCommand command2 = new SqlCommand("select count(*) from member", con);
            con.Open();
            int count = (int)command2.ExecuteScalar();
            label1.Text = count.ToString();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source=(localdb)\MSSQLLocalDB;initial catalog=Test;integrated security=true";
                //SqlCommand command = new SqlCommand("delete from member where id=@id", con);
                SqlCommand command = new SqlCommand("uspDeleteByID", con);
                command.CommandType = CommandType.StoredProcedure;

                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                command.Parameters.AddWithValue("@id", id);

                con.Open();
                int n = command.ExecuteNonQuery();
                con.Close();

                // 다시 조회
                button1.PerformClick();
            }
            else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ds != null)
            {
                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "UserID"; // order 
                dv.RowFilter = "UserId LIKE 'u%'"; // where
                dataGridView1.DataSource = dv;
            }
            else
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Member mem = new Member();
            DataSet ds = mem.GetMembers();

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.ConnectionStrings;
            if (section != null)
            {
                if (!section.SectionInformation.IsProtected && !section.ElementInformation.IsLocked)
                {
                    section.SectionInformation.ProtectSection(
                         "DataProtectionConfigurationProvider");
                    section.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSection section = config.ConnectionStrings;
            if (section != null)
            {
                if (section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.UnprotectSection();
                    section.SectionInformation.ForceDeclaration(true);
                    section.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
        }

        // TODO : Insert
        private void button8_Click(object sender, EventArgs e)
        {

        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Member mem = new Member();
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                string userId = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string password = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string email = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                int r = mem.Update(id, userId, password, name, email);
                button5.PerformClick();
            }
        }

    }
}
