using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Board
{
    public partial class registerDlg : Form
    {
        private MemberDAC memberDac = new MemberDAC();
        public registerDlg()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string userId = userIDTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string name = nameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();

            if (string.IsNullOrEmpty(userIDTextBox.Text) ||
                string.IsNullOrEmpty(passwordTextBox.Text) ||
                string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("아이디, 비밀번호, 이름은 필수 입력 항목입니다");
                return;
            }

            // ID
            if (!Regex.IsMatch(userId, @"^[a-zA-Z0-9]{4,12}$"))
            {
                MessageBox.Show("아이디는 영문 및 숫자 조합 4~12자로 입력하세요.", "형식 오류");
                userIDTextBox.Focus();
                return;
            }

            // 비밀번호
            if (!Regex.IsMatch(password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$"))
            {
                MessageBox.Show("비밀번호는 최소 8자 이상, 영문 대문자 1자, 소문자 1자를 필수로 입력하세요.", "형식 오류");
                passwordTextBox.Focus();
                return;
            }

            // 이메일
            if (!Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                MessageBox.Show("올바른 이메일 형식이 아닙니다.", "형식 오류");
                emailTextBox.Focus();
                return;
            }

            bool isSuccess = memberDac.Register(userId, password, name, email);

            if (isSuccess)
            {
                MessageBox.Show("회원가입이 정상적으로 완료되었습니다!", "성공");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("이미 존재하는 아이디입니다.", "중복 오류");
                userIDTextBox.Focus();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
