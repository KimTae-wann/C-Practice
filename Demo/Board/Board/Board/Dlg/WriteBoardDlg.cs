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
    public partial class WriteBoardDlg : Form
    {
        // 로그인 되지 않은 경우 Board.cs에서 걸러짐
        // 추가할 때 로그인 된 사용자의 정보 추가
        public WriteBoardDlg()
        {
            InitializeComponent();
            nameTextBox.Text = UserSession.CurrentUser.Name;
            emailTextBox.Text = UserSession.CurrentUser.Email;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text.Trim();
            string writer = nameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string content = contentTextBox.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(writer) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("비밀번호, 제목, 작성자, 내용은 필수 입력 항목입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 게시글 인스턴스 생성
            BoardVO newPost = new BoardVO()
            {
                Title = title,
                Name = writer,
                Email = email,
                Password = password,
                Content = content
            };

            // 추가
            BoardDAC dac = new BoardDAC();
            bool isSuccess = dac.Insert(newPost);

            // 추가 후처리
            if (isSuccess)
            {
                MessageBox.Show("새 게시글이 성공적으로 등록되었습니다.", "등록 성공");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("등록에 실패했습니다.");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
