using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace _13Collections
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //System.Collections.ArrayList al = new System.Collections.ArrayList();
            /*ArrayList al = new ArrayList();
            al.Add(10); // int to Object : boxing 
            al.Add(20);
            al.Add(3.14); // double to Object : boxing
            al.Add("Hello"); // Object가 Obejct로 바뀌는건 boxing이 아니다.
            foreach(object obj in al)
                listBox1.Items.Add(obj);*/
            
            List<int> al = new List<int>();
            al.Add(10); // int to Object : boxing 
            al.Add(20);
            al.Add(30);
            al.Insert(1, 99);
            al.Remove(20); // 값으로 지움
            al[0] = 11; // 인덱서 zero-based Indexer

            foreach(int i in al)
                listBox1.Items.Add(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //Hashtable t = new Hashtable(); // HashCode로 정렬되서 들어간다.
            //Dictionary<int, string> t = new Dictionary<int, string>();
            SortedDictionary<int, string> t = new SortedDictionary<int, string>();
            t.Add(1, "Hong");
            t.Add(3, "Kim");
            t.Add(2, "Lee");
            t[4] = "Choo"; // 해당 키가 없으면 추가
            t[1] = "Kang"; // 해당 키가 있으면 수정
            //t.Add(2, "Kang");
           // foreach (DictionaryEntry d in t)
           foreach(KeyValuePair<int, string> d in t)
                listBox1.Items.Add(d.Key + ":" + d.Value);

            if (t.ContainsKey(1))
                listBox1.Items.Add("있다");
            else
                listBox1.Items.Add("없다");

            //Hashtable dic = new Hashtable();
            //dic.Add("a", "apple");
            //dic.Add("b", "bear");
            //dic["c"] = "car";
            //foreach (DictionaryEntry d in dic)
            //    listBox1.Items.Add(d.Key + ";" + d.Value);

            SortedDictionary<string, string> sdic = new SortedDictionary<string, string>();
            sdic.Add("a", "apple");
            sdic.Add("b", "bear");
            sdic["c"] = "car";
            foreach (KeyValuePair<string, string> d in sdic)
                listBox1.Items.Add(d.Key + ";" + d.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            int c = s.Count;
            for (int i = 0; i < c; i++)
                listBox1.Items.Add(s.Pop());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            int c = q.Count;
            for (int i = 0; i < c; i++)
                listBox1.Items.Add(q.Dequeue());
        }
    }
}
