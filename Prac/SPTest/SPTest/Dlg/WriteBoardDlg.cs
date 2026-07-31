using SPTest.DAC;
using SPTest.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPTest.Dlg
{
    public partial class WriteBoardDlg : Form
    {

        public Timer myTimer;
        public WriteBoardDlg()
        {
            InitializeComponent();
            InitializeMyTimer();
            nameTextBox.Text = UserSession.CurrentUser.Name;
            emailTextBox.Text = UserSession.CurrentUser.Email;
            iDateLabel.Text = DateTime.Now.ToString();
        }

        private void InitializeMyTimer()
        {
            myTimer = new Timer();

            myTimer.Interval = 1000;

            myTimer.Tick += new EventHandler(Timer_Tick);

            myTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            iDateLabel.Text = DateTime.Now.ToString();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text.Trim();
            string name = nameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string content = contentTextBox.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("비밀번호, 제목, 작성자, 내용은 필수 입력 항목입니다.", "주의", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (titleTextBox.Text.Length > 100)
            {
                MessageBox.Show("잘못된 입력값입니다. 제목을 다시 확인해주세요. (최대 100자)", "주의");
                return;
            }
            if (passwordTextBox.Text.Length > 20)
            {
                MessageBox.Show("잘못된 입력값입니다. 비밀번호를 다시 입력해주세요. (최대 20자)", "주의");
                return;
            }

            BoardVO newPost = new BoardVO()
            {
                Title = title,
                Name = name,
                Email = email,
                Password = password,
                Content = content
            };

            BoardDAC dac = new BoardDAC();
            bool isSuccess = dac.Insert(newPost);

            if (isSuccess)
            {
                MessageBox.Show("공지사항을 추가하였습니다.", "성공");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("공지사항 추가에 실패하셨습니다.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
