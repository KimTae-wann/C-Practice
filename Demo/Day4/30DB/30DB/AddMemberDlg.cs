using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _30DB
{
    public partial class AddMemberDlg : Form
    {
        public AddMemberDlg()
        {
            InitializeComponent();
        }

        // 추가
        private void button1_Click(object sender, EventArgs e)
        {
            Member mem = new Member();

            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("아이디, 비밀번호, 이름은 필수 입력 항목입니다");
                return;
            }

            string userId = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
            string name = textBox3.Text.ToString();
            string email = textBox4.Text.ToString();

            int r = mem.Insert(userId, password, name, email);

            MessageBox.Show($"userId = {userId}\n" +
                            $"password = {password}\n" +
                            $"name = {name}\n" + 
                            $"email = {email}");

            this.DialogResult = DialogResult.OK;
        }

        // 취소
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
