using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json; // Nuget 패키지 추가

namespace _25Serialization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("config.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            Config c = new Config { IP = "127.0.0.1", PortNum = 80, DBServer = "Server1" };
            bf.Serialize(fs, c);
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("config.bin", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            var c = bf.Deserialize(fs) as Config;
            listBox1.Items.Add(c.IP);
            listBox1.Items.Add(c.PortNum);
            listBox1.Items.Add(c.DBServer);
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Config c = new Config { IP = "127.0.0.1", PortNum = 80, DBServer = "Server1" };
            FileStream fs = new FileStream("config.json", FileMode.Create);
            DataContractJsonSerializer js = new DataContractJsonSerializer(c.GetType());
            js.WriteObject(fs, c); // 속성명으로 정렬해서 오름차순으로 들어감 --> 이게 이상한거임
            fs.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("config.json", FileMode.Open);
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Config));
            var c = js.ReadObject(fs) as Config;
            listBox1.Items.Add(c.IP);
            listBox1.Items.Add(c.PortNum);
            listBox1.Items.Add(c.DBServer);
            fs.Close();
        }

        // newtonSoft 라이브러리를 제일 많이 씀 5,6번 중요
        // Nuget패키지 추가
        private void button5_Click(object sender, EventArgs e)
        {
            Config2 c = new Config2 { IP = "127.0.0.1", PortNum = 80, DBServer = "Server1" };
            //object => JSON string
            string s = JsonConvert.SerializeObject(c);
            listBox1.Items.Add(s);
            JsonSerializer js = new JsonSerializer();

            StreamWriter sw = new StreamWriter("config2.json");
            js.Serialize(sw, c);
            sw.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            JsonSerializer js = new JsonSerializer();
            JsonReader r = new JsonTextReader(new StreamReader("config2.json"));
            var c = js.Deserialize<Config2>(r);
            listBox1.Items.Add(c.IP);
            listBox1.Items.Add(c.PortNum);
            listBox1.Items.Add(c.DBServer);
            r.Close();
        }
    }
}
