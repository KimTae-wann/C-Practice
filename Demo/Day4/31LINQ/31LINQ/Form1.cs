using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _31LINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] a = { 4, 8, 7, 3, 2, 6 };
            //짝수만 내림차순으로
            /*Array.Sort(a);
            Array.Reverse(a);
            foreach (int i in a)
            {
                if (i % 2 == 0)
                    listBox1.Items.Add(i);
            }*/

            var r = from i in a
                    where i % 2 == 0
                    orderby i descending
                    select i;
            foreach (var i in r)
                listBox1.Items.Add(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] str = { "Kim", "Park", "Hong", "Lee" };
            // 문자열이 4글자 이상인 것만 대문자로 바꿔서 오름차순으로

            var r = from i in str
                    where i.Length >= 4
                    orderby i ascending
                    select i.ToUpper();

            foreach (var i in r)
                listBox1.Items.Add(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] str = { "Kim", "Park", "Hong", "Lee", "pae"};
            //P로 p시작한 문자열 보여주기
            var r = from i in str
                    where i.ToUpper().StartsWith("P")
                    select i;

            foreach (var i in r)
                listBox1.Items.Add(i);

        }
    }
}
