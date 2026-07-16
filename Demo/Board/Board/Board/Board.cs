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

        private void RefreshBoardList()
        {
            if (UserSession.CurrentUser != null)
            {
                로그인ToolStripMenuItem.Visible = false;
                로그아웃ToolStripMenuItem.Visible = true;
            }
            else
            {
                로그인ToolStripMenuItem.Visible = true;
                로그아웃ToolStripMenuItem.Visible = false;
            }
            int savedRowIndex = -1;
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                savedRowIndex = dataGridView1.CurrentRow.Index;
            }

            DataSet ds = dac.SelectAllBoards();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];

            if (savedRowIndex >= 0 && savedRowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.ClearSelection();

                dataGridView1.CurrentCell = dataGridView1.Rows[savedRowIndex].Cells[0];
                dataGridView1.Rows[savedRowIndex].Selected = true;
            }

        }

        private void 보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshBoardList();
        }

        private void 추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser == null)
            {
                MessageBox.Show("로그인을 먼저 해주세요.", "권한 없음");
                return;
            }
            else
            {
                WriteBoardDlg writeForm = new WriteBoardDlg();

                writeForm.ShowDialog();
                RefreshBoardList();
            }
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser == null)
            {
                MessageBox.Show("로그인을 먼저 해주세요.", "권한 없음");
                return;
            }

            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("삭제할 행을 선택해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var selectedRow = dataGridView1.CurrentRow;
            string idStr = selectedRow.Cells["id"].Value?.ToString() ?? "";
            string title = selectedRow.Cells["title"].Value?.ToString() ?? "";
            
            bool isMine = dac.SelfCheck(idStr);
            if (!isMine)
            {
                MessageBox.Show("해당 공지사항을 삭제할 권한이 없습니다", "권한없음");
                return;
            }

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
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 회원가입ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registerDlg dlg = new registerDlg();
            dlg.ShowDialog();
        }

        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginDlg dlg = new loginDlg();
            dlg.ShowDialog();
            RefreshBoardList();
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{UserSession.CurrentUser.Name}님 로그아웃합니다.");
            UserSession.Logout();
            RefreshBoardList();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
