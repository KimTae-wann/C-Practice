using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseMyButton1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void myButton11_MyClick(object sender, _20MyButton1.MyEventArgs e)
        {
            //label1.Text = "Hello " + e.Message;

            label1.Text = "Hello," + myButton11.TextBoxText;
        }

        private void myButton11_Load(object sender, EventArgs e)
        {
            myButton11.TextBoxText = "EveryOne!";
        }
    }
}
