using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17Delegate
{
    public partial class Form1 : Form
    {
        private List<Rectangle> list = new List<Rectangle>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Text = "x=" + e.X + " y=" + e.Y;

            Graphics g = this.CreateGraphics();
            Rectangle r = new Rectangle(e.X, e.Y, 100, 100);
            g.DrawRectangle(Pens.Blue, r);
            // Resize 시 그림이 사라짐
            list.Add(r);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var r in list)
                e.Graphics.DrawRectangle(Pens.Red, r);
        }
    }
}
