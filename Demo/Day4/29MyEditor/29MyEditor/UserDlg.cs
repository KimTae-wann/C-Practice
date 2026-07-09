using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _29MyEditor
{
    public partial class UserDlg : Form
    {
        // property 속성
        public string Message
        { 
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public UserDlg()
        {
            InitializeComponent();
        }
    }
}
