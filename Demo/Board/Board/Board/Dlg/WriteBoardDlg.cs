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
        // 타이머
        private Timer myTimer;
        // 로그인 되지 않은 경우 Board.cs에서 걸러짐
        // 추가할 때 로그인 된 사용자의 정보 추가
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

            // Tick 주기 세팅
            myTimer.Interval = 1000;

            // Tick 발생 하면 델리게이터가 Timer_Tick 메서드 호출
            myTimer.Tick += new EventHandler(Timer_Tick);

            myTimer.Start();
        }

        // 시간 반영
        private void Timer_Tick(object sender, EventArgs e)
        {
            iDateLabel.Text = DateTime.Now.ToString();
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
                MessageBox.Show("등록에 실패했습니다.", "등록 실패");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
