using SPTest.DAC;
using SPTest.Dlg;
using SPTest.VO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPTest
{
    public partial class MainBoard : Form
    {

        private List<BoardVO> originalList = new List<BoardVO>();
        private BoardDAC dac = new BoardDAC();

        public MainBoard()
        {
            InitializeComponent();
        }

        private void LoginCheck()
        {
            if (UserSession.IsLoggedIn)
            {
                회원가입ToolStripMenuItem.Visible = false;
                로그인ToolStripMenuItem.Visible = false;
                로그아웃ToolStripMenuItem.Visible = true;
            }
            else
            {
                회원가입ToolStripMenuItem.Visible = true;
                로그인ToolStripMenuItem.Visible = true;
                로그아웃ToolStripMenuItem.Visible = false;
            }
        }
        private void MainBoard_Load(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void RefreshBoardList()
        {
            LoginCheck();

            int savedRowIndex = -1;
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                savedRowIndex = dataGridView1.CurrentRow.Index;
            }

            // DataSet
            DataSet ds = dac.SelectAllBoards();
            DataTable dt = ds.Tables[0];

            originalList = dt.AsEnumerable().Select(row => new BoardVO
            {
                Id = Convert.ToInt32(row["id"]),
                Title = row["title"].ToString(),
                Name = row["name"].ToString(),
                ReadCount = Convert.ToInt32(row["readCount"])
            })
            .ToList();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = originalList;

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

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (originalList == null)
                return;

            string keyword = searchTextBox.Text;
            string searchType = searchComboBox.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(keyword))
            {
                dataGridView1.DataSource = originalList;
                return;
            }

            List<BoardVO> filteredList = originalList
                                         .Where(b =>
                                                (searchType == "제목" && b.Title.Contains(keyword) == true) ||
                                                (searchType == "작성자" && b.Name.Contains(keyword) == true) ||
                                                (searchType == "내용" && b.Content.Contains(keyword) == true)
                                         )
                                         .ToList();

            dataGridView1.DataSource = filteredList;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

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
                    detailForm.Show();
                    RefreshBoardList();

                }
            }
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
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
                MessageBox.Show("해당 공지사항을 삭제할 권한이 없습니다.", "권한없음");
                return;
            }

            if (!int.TryParse(idStr, out int id))
                return;

            DialogResult confirmResult = MessageBox.Show($"[{title}] 게시글을 정말 삭제하시겠습니까?",
                                                         "삭제 확인",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            PasswordCheckDlg pwdForm = new PasswordCheckDlg();

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

        private void 추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                MessageBox.Show("로그인을 먼저 해주세요.", "권한 없음");
                return;
            }
            else
            {
                WriteBoardDlg writeForm = new WriteBoardDlg();
                if (writeForm.ShowDialog() != DialogResult.Cancel)
                {
                    RefreshBoardList();
                }
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 회원가입ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterDlg regiDlg = new RegisterDlg();
            regiDlg.ShowDialog();
        }

        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginDlg loginForm = new LoginDlg();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                RefreshBoardList();
            }
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSession.Logout();
            RefreshBoardList();
        }

        private void excelExtractButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("내보낼 데이터가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV 파일 (*.csv)|*.csv|모든 파일 (*.*)|*.*";
                saveFileDialog.Title = "CSV로 내보내기";
                saveFileDialog.FileName = "게시글목록_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.Unicode))
                        {
                            string header = "";
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                header += EscapeCsvField(dataGridView1.Columns[i].HeaderText) + '\t';
                            }
                            sw.WriteLine(header.TrimEnd('\t'));

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    string line = "";
                                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                    {
                                        object cellValue = row.Cells[i].Value;
                                        string strValue = cellValue != null ? cellValue.ToString() : "";

                                        line += EscapeCsvField(strValue) + "\t";
                                    }
                                    sw.WriteLine(line.TrimEnd('\t'));
                                }
                            }
                        }
                        MessageBox.Show("CSV 파일 저장 완료!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("파일 저장 중 오류가 발생했습니다: " + ex.Message, "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field))
                return "";
            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
            {
                field = field.Replace("\"", "\"\"");
                return "\"" + field + "\"";
            }
            return field;
        }
    }
}
