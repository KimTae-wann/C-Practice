using SPTest.DAC;
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

namespace SPTest.Dlg
{
    public partial class RegisterDlg : Form
    {
        private MemberDAC memberDAC = new MemberDAC();
        public RegisterDlg()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string userId = userIDTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string name = nameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();

            if (string.IsNullOrEmpty(userId) || 
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(name))
            {
                MessageBox.Show("아이디, 비밀번호, 이름은 필수 입력 항목입니다.");
                return;
            }

            // Validation Check
            // ID
            if (!Regex.IsMatch(userId, @"^[a-zA-Z0-9]{4,12}$"))
            {
                MessageBox.Show("아이디는 대소문자 영문 및 숫자 조합 4~12자로 입력하세요.", "형식 오류");
                userIDTextBox.Focus();
                return;
            }

            // 비밀번호
            if (!Regex.IsMatch(password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,20}$"))
            {
                MessageBox.Show("비밀번호는 대소문자 영문 및 숫자 조합 8~20자로 입력하세요.", "형식 오류");
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

            // 회원가입
            // 아이디 중복 여부 체크
            bool isSuccess = memberDAC.Register(userId, password, name, email);

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
            this.Close();
        }
    }
}
