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
        private int boardID;
        // 타이머
        private Timer myTimer;
        public UpdateBoardDlg()
        {
            InitializeComponent();
            InitializeMyTimer();
        }
        public UpdateBoardDlg(string id, string title, string writer, string email, string readCount, string content, string date)
        {
            InitializeComponent();
            InitializeMyTimer();

            boardID = int.Parse(id);
            titleTextBox.Text = title;
            nameTextBox.Text = writer;
            emailTextBox.Text = email;
            inputReadCountLabel.Text = readCount;
            contentTextBox.Text = content;
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

        private void UpdateBoardDlg_Load(object sender, EventArgs e)
        {

        }

        // 수정
        private void updateButton_Click(object sender, EventArgs e)
        {

            // 로그인된 사용자가 없으면 수정기능 권한 없음
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("로그인하지 않은 사용자는 수정권한이 없습니다.", "권한 없음");
                return;
            }
            else
            {
                // 현재 로그인된 사용자가 작성한 게시글이 아니라면 권한 없음 모달 띄움
                if (!(UserSession.CurrentUser.Name.Equals(nameTextBox.Text) &&
                    UserSession.CurrentUser.Email.Equals(emailTextBox.Text)))
                {
                    MessageBox.Show("해당 글을 수정할 권한이 없습니다.", "권한 없음");
                    return;
                }
            }

            string password = passwordTextBox.Text.Trim();
            string updatedTitle = titleTextBox.Text.Trim();
            string updatedContent = contentTextBox.Text.Trim();

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(updatedTitle))
            {
                MessageBox.Show("비밀번호와 제목은 필수 입력 항목입니다.", "주의");
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

            // 로그인된 사용자가 작성한 글인 경우 게시글 인스턴스 생성
            BoardVO updatePost = new BoardVO()
            {
                Id = this.boardID,
                Title = updatedTitle,
                Content = updatedContent,
                Password = password
            };

            // 수정
            BoardDAC dac = new BoardDAC();
            bool isSuccess = dac.Update(updatePost);

            // 수정 후처리
            if (isSuccess)
            {
                MessageBox.Show("게시글이 성공적으로 수정되었습니다.", "등록 성공");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("비밀번호가 올바르지 않거나 수정 권한이 없습니다.", "인증 실패");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
