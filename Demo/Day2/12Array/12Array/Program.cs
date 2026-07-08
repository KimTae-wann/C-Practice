using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12Array
{
    class Employee : IComparable
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            Employee em = obj as Employee;
            if (this.ID > em.ID)
                return 1;
            else if (this.ID == em.ID)
                return 0;
            else
                return -1;
        }

        public override string ToString()
        {
            return ID + ":" + Name;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] em = new Employee[3];
            em[0] = new Employee { ID = 1, Name = "Hong" };
            em[1] = new Employee { ID = 3, Name = "Kim" };
            em[2] = new Employee { ID = 2, Name = "Lee" };

            Array.Sort(em);

            foreach (Employee emp in em)
                Console.WriteLine(emp);



            //int[] a = new int[3] { 1, 2}; --> 개수 명시해준 경우 초기화 개수랑 다르면 에러
            //int[] a = new int[]; --> 크기 지정 안해주면 에러
            int[] a = new int[3] { 1, 2, 3 };
            int[] b = { 1, 2, 3 };

            foreach (int i in a)
            {
                Console.WriteLine(i); // a[0] ...a[a.Length - 1]
            }
            a[0] = 1;
            //a[3] = 1; --> IndexOutOfRange

            int[,] c = new int[2, 3]; //row-2 col-3
            int[,] d = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] e = { { 1, 2, 3 }, { 4, 5, 6 } };

            // System.Array: 속성 Length, Rank(차원 수)
            // Method
            int[] data = { 4, 8, 3, 8, 1 };
            Array.Sort(data); // quick sort
            Array.Reverse(data);
            Array.Clear(data, 2, 3); // index 2부터 3개 2 ~ 4
            Array.Resize(ref data, 10);

            foreach (int i in data)
                Console.Write(i + " ");
            Console.WriteLine();

            int[] copy = data; // Shallow Copy
            int[] clone = (int[])data.Clone(); // Deep Copy
            copy[0] = 99;
            clone[1] = 11;

            foreach (int i in copy)
                Console.Write(i + " ");
            Console.WriteLine();

            foreach (int i in clone)
                Console.Write(i + " ");
            Console.WriteLine();

        }
    }
}
