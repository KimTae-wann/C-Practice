using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16Exception
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(textBox1.Text);
                int y = Convert.ToInt32(textBox2.Text);

                if (y < 1 || y > 10)
                {
                    throw new ArgumentOutOfRangeException("1하고 10사이의 값을 입력해주세요");
                }

                int r = x / y;
                label1.Text = r.ToString();
            }
            catch (DivideByZeroException ex)
            {
                label1.Text = "DBZ";
            }
            catch (Exception ex) 
            // 중요한점은 에러를 DBZ 가 뒤로가면 컴파일 타임에 잡아주는데, 커스텀에러는 컴파일타임에 안잡아준다.
            {
                label1.Text = ex.Message + "\n" + ex.StackTrace;
            }
            finally // 보통 리소스 해제를 함 fp 닫거나 db연결 해제 등등..
            {
                MessageBox.Show("GoodJob");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 왼쪽 솔루션 탐색기의 Properties --> 빌드 --> 고급 --> 산술 오버플로 확인 누르면
            // 해당 프로젝트의 모든 연산 결과에 대해 오버플로 확인을 한다.
            int n = int.MaxValue;
            n++;
            label1.Text = n.ToString();
        }
    }
}
