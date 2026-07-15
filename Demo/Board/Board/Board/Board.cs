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
    public partial class Board : Form
    {
        private BoardDAC dac = new BoardDAC();
        public Board()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshBoardList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];
            string idStr = row.Cells["id"].Value?.ToString() ?? "";

            if (int.TryParse(idStr, out int id))
            {
                BoardVO board = dac.SelectOne(id);

                if (board != null)
                {
                    UpdateBoardDlg detailForm = new UpdateBoardDlg(
                        board.Id.ToString(),
                        board.Title,
                        board.Name,
                        board.Email,
                        board.ReadCount.ToString(),
                        board.Content,
                        board.IDate.ToString()
                    );

                    detailForm.ShowDialog();
                    RefreshBoardList();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("삭제할 행을 선택해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.CurrentRow;
            string idStr = selectedRow.Cells["id"].Value?.ToString() ?? "";
            string title = selectedRow.Cells["title"].Value?.ToString() ?? "";

            if (!int.TryParse(idStr, out int id)) return;

            DialogResult confirmResult = MessageBox.Show($"[{title}] 게시글을 정말 삭제하시겠습니까?",
                                                         "삭제 확인",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            PasswordCheckForm pwdForm = new PasswordCheckForm();

            if (pwdForm.ShowDialog() == DialogResult.OK)
            {
                string inputPassword = pwdForm.InputPassword;

                if (string.IsNullOrEmpty(inputPassword))
                {
                    MessageBox.Show("비밀번호를 입력해야 삭제가 가능합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isDeleted = dac.Delete(id, inputPassword);

                if (isDeleted)
                {
                    MessageBox.Show("게시글이 성공적으로 삭제되었습니다.", "삭제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshBoardList();
                }
                else
                {
                    MessageBox.Show("비밀번호가 올바르지 않습니다.", "인증 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            WriteBoardDlg writeForm = new WriteBoardDlg();

            writeForm.ShowDialog();
            RefreshBoardList();
        }


        private void RefreshBoardList()
        {
            DataSet ds = dac.SelectAll();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
