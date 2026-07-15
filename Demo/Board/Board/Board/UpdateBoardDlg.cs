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
        public UpdateBoardDlg()
        {
            InitializeComponent();
        }
        public UpdateBoardDlg(string id, string title, string writer, string email, string readCount, string content, string date)
        {
            InitializeComponent();

            boardID = int.Parse(id);
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
            string password = passwordTextBox.Text.Trim();
            string updatedTitle = titleTextBox.Text.Trim();
            string updatedContent = contentTextBox.Text.Trim();

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(updatedTitle))
            {
                MessageBox.Show("비밀번호와 제목은 필수 입력 항목입니다.", "알림");
                return;
            }

            BoardVO updatePost = new BoardVO()
            {
                Id = this.boardID,
                Title = updatedTitle,
                Content = updatedContent,
                Password = password
            };

            BoardDAC dac = new BoardDAC();
            bool isSuccess = dac.Update(updatePost);

            if (isSuccess)
            {
                MessageBox.Show("게시글이 성공적으로 수정되었습니다.", "성공");
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
