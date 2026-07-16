using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Board
{
    public partial class loginDlg : Form
    {
        private MemberDAC memberDac = new MemberDAC();
        public loginDlg()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userId = userIDTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(userId) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("아이디, 비밀번호를 모두 입력해주세요.");
            }

            if (userIDTextBox.Text.Length > 20)
            {
                MessageBox.Show("잘못된 입력값입니다. 아이디를 다시 입력해주세요. (최대 20자)", "주의");
                return;
            }
            if (passwordTextBox.Text.Length > 50)
            {
                MessageBox.Show("잘못된 입력값입니다. 비밀번호를 다시 입력해주세요. (최대 50자)", "주의");
                return;
            }
            // 로그인 시도
            MemberVO loginUser = memberDac.Login(userId, password);

            // 해당 유저가 있으면
            if (loginUser != null)
            {
                // UserSession 정적 클래스에 정보 삽입
                UserSession.CurrentUser = loginUser;

                MessageBox.Show($"{loginUser.Name}님, 환영합니다!", "로그인 성공");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("존재하지 않는 아이디 또는 비밀번호입니다.", "로그인 실패");
                userIDTextBox.Focus();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
