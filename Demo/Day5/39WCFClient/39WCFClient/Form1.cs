using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.ServiceModel;

namespace _39WCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.HelloServiceClient proxy = new ServiceReference1.HelloServiceClient();
            MessageBox.Show(proxy.Hello(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ServiceMetadata를 사용해서 서비스 참조추가로 proxy를 생성
            ServiceReference1.HelloServiceClient proxy = new ServiceReference1.HelloServiceClient();
            DataSet ds = proxy.GetMembers();
            dataGridView1.DataSource = ds.Tables[0];
        }

        // 참조추가 : _39WCFService.dll(IHelloService) 참조추가
        private void button3_Click(object sender, EventArgs e)
        {
            // Code로 proxy 생성
            BasicHttpBinding b = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress("http://localhost:8080/HelloService");
            _39WCFService.IHelloService proxy = ChannelFactory<_39WCFService.IHelloService>.CreateChannel(b, address);

            DataSet ds = proxy.GetMembers();
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
