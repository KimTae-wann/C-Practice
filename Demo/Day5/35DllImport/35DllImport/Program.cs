using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms; // 참조 추가

using System.Runtime.InteropServices;

namespace _35DllImport
{
    class Program
    {
        //int MessageBox(HWND hWnd, LPCTSTR lpText, LPCTSTR lpCaption, UINT uType);
        // method
        [DllImport("user32.dll", EntryPoint = "MessageBox")] // C/C++ 함수이름 = 시작주소(EntryPoint)
        public static extern int APIMessageBox(int h, string text, string caption, uint type);
        static void Main(string[] args)
        {
            MessageBox.Show("Hello");
            APIMessageBox(0, "Good Morning", "Hello", 0); // Win32 API 호출
        }
    }
}
