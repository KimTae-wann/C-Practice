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

namespace _26Dialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK) // Modal
            {
                StreamReader r = new StreamReader(dlg.FileName);
                textBox1.Text = r.ReadToEnd();
                while (!r.EndOfStream)
                    listBox1.Items.Add(r.ReadLine());
                r.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.Font = textBox1.Font;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = dlg.Font;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = textBox1.ForeColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = dlg.Color;
            }
        }
    }
}
