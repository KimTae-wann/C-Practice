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
            // string.Empty --> object 생성하지 않아 문자열 초기화 시에는 string.Empty 사용
            var fileContent = string.Empty;
            var filePath = string.Empty;

            // OS FileSystem Resource 의도적으로 해제
            // using 을 사용하면 예외 흐름으로 빠져도 정상적으로 Dispose해줌
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    // OS FileSystem Resource 의도적으로 해제
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        textBox1.Text = fileContent;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("파일이 비었거나 불러와 주세요");
                return;
            }

            listBox2.Items.Clear();

            // StringSPlitOptions.RemoveEmptyEntries --> 반환 값에 빈 문자열이 포함 된 배열 요소를 포함하지 않음
            string[] words = textBox1.Text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts.Add(word, 1);
                }
            }

            foreach (KeyValuePair<string, int> kvp in wordCounts)
            {
                listBox2.Items.Add(kvp.Key + "\t" + kvp.Value);
            }
        }
    }
}