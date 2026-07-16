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
    public partial class PasswordCheckDlg : Form
    {
        public string InputPassword { get; private set; }
        public PasswordCheckDlg()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Length > 20)
            {
                MessageBox.Show("잘못된 입력값입니다. 비밀번호를 다시 입력해주세요. (최대 20자)", "주의");
                return;
            }
            InputPassword = passwordTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
