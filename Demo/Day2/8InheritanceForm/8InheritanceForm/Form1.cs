using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8InheritanceForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // this.Dispose <-- Form.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "MyForm";

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show("정말로 종료?", "Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
                base.OnFormClosing(e);
            else
                e.Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                if (c is TextBox)
                    c.BackColor = Color.Yellow;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBox t = new TextBox();
            t.Text = "Hello";
            t.Left = 200;
            t.Top = 200;
            this.Controls.Add(t);
        }
    }
}
