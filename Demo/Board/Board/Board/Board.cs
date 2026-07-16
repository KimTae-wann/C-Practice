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

        private void LoginCheck()
        {
            // 로그인 된 경우 --> 로그아웃 Visible
            if (UserSession.IsLoggedIn)
            {
                회원가입ToolStripMenuItem.Visible = false;
                로그인ToolStripMenuItem.Visible = false;
                로그아웃ToolStripMenuItem.Visible = true;
            }
            // 로그인 안 된 경우 --> 로그인 Visible
            else
            {
                회원가입ToolStripMenuItem.Visible = true;
                로그인ToolStripMenuItem.Visible = true;
                로그아웃ToolStripMenuItem.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void RefreshBoardList()
        {
            LoginCheck();

            // 마지막 select 된 currentRow 정보 저장 
            int savedRowIndex = -1;
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                savedRowIndex = dataGridView1.CurrentRow.Index;
            }

            // DataSet
            DataSet ds = dac.SelectAllBoards();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];

            // 마지막 select 된 컬럼이 있다면 해당 컬럼을 select 하고 focus
            if (savedRowIndex >= 0 && savedRowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.ClearSelection();

                dataGridView1.CurrentCell = dataGridView1.Rows[savedRowIndex].Cells[0];
                dataGridView1.Rows[savedRowIndex].Selected = true;
            }

        }

        // 회원가입
        private void 회원가입ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registerDlg dlg = new registerDlg();
            dlg.ShowDialog();
        }

        // 로그인
        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginDlg dlg = new loginDlg();
            dlg.ShowDialog();
            RefreshBoardList();
        }

        // 로그아웃
        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{UserSession.CurrentUser.Name}님 로그아웃합니다.");
            UserSession.Logout();
            RefreshBoardList();
        }

        private void 보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshBoardList();
        }

        // 수정
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 유효하지 않은 행 클릭한 경우
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];
            string idStr = row.Cells["id"].Value?.ToString() ?? "";

            if (int.TryParse(idStr, out int id))
            {
                // 게시글 하나 골라서
                BoardVO board = dac.SelectOne(id);

                if (board != null)
                {
                    // 모달띄워서 처리
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


        // 삭제
        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 로그인된 사용자가 없으면 삭제기능 권한 없음
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("로그인을 먼저 해주세요.", "권한 없음");
                return;
            }

            // 선택된 행이 없는 경우
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("삭제할 행을 선택해 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.CurrentRow;
            string idStr = selectedRow.Cells["id"].Value?.ToString() ?? "";
            string title = selectedRow.Cells["title"].Value?.ToString() ?? "";

            // 본인이 작성한 글인지 확인
            bool isMine = dac.SelfCheck(idStr);
            if (!isMine)
            {
                MessageBox.Show("해당 공지사항을 삭제할 권한이 없습니다", "권한없음");
                return;
            }

            // idStr을 int Type으로 바꿀 수 있으면 id에 담아두고 true 반환
            if (!int.TryParse(idStr, out int id)) return;

            // 삭제 확인
            DialogResult confirmResult = MessageBox.Show($"[{title}] 게시글을 정말 삭제하시겠습니까?",
                                                         "삭제 확인",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            // 해당 글의 비밀번호 확인
            PasswordCheckDlg pwdForm = new PasswordCheckDlg();

            if (pwdForm.ShowDialog() == DialogResult.OK)
            {
                string inputPassword = pwdForm.InputPassword;

                if (string.IsNullOrEmpty(inputPassword))
                {
                    MessageBox.Show("비밀번호를 입력해야 삭제가 가능합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 삭제
                bool isDeleted = dac.Delete(id, inputPassword);

                // 삭제 후처리
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
        // 추가
        private void 추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 로그인된 사용자가 없으면 추가기능 권한 없음
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("로그인을 먼저 해주세요.", "권한 없음");
                return;
            }
            // 로그인된 사용자면 글 쓰기 모달 띄움
            else
            {
                WriteBoardDlg writeForm = new WriteBoardDlg();

                writeForm.ShowDialog();
                RefreshBoardList();
            }
        }
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
