using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace d3hw1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // 처음 창이 열릴 때 보여줄 폴더
                openFileDialog.InitialDirectory = "C:\\";
                // 파일 탐색기 우측 하단 확장자 필터
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                // 필터 중 2번째인 'All files (*.*)'를 기본으로 선택
                openFileDialog.FilterIndex = 2;
                // 창을 닫기 전, 사용자가 마지막으로 열었던 폴더 위치를 기억해둠
                openFileDialog.RestoreDirectory = true;


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 파일 경로 가져옴
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    // StreamReader로 텍스트 파일 읽음
                    using (StreamReader reader = new StreamReader(fileStream))
                    {

                        while ((fileContent = reader.ReadLine()) != null)
                        {
                            listBox1.Items.Add(fileContent);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("파일을 먼저 불러와 주세요");
                return;
            }

            listBox2.Items.Clear();

            foreach (var item in listBox1.Items)
            {
                string line = item.ToString();

                string[] words = line.Split(' ');
                
                foreach (var word in words)
                {
                    foreach (DictionaryEntry d in wordCounts)
                    {

                    }
                }
            }
        }
    }
}
