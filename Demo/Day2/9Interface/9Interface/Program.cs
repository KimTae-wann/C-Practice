using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Interface
{
    interface IPolygon
    {
        void Draw();
        double GetArea();
        // public double GetArea(); --> public 안됨
        //int x; --> Field 선언 안됨
        //double GetArea(){return x;} --> Body 구현 안됨
    }

    interface ITest
    {
        void Draw();                                                                               
    }

    class Rect //: IPolygon, ITest // base 클래스를 항상 먼저 적어야 한다.
    {
        public int Width { get; set; }
        public int Height { get; set; }

        // 명시적으로 구현 (Explicit)
        /*void IPolygon.Draw()
        {
            
        }

        double IPolygon.GetArea()
        {
            
        }*/

        // 암시적으로 구현 (Implicit)
        /*public void Draw() // IPolygon ? ITest? --> 이럴 때 명시적으로 사용해주어야 한다.
        {
            
        }

        public double GetArea()
        {
        }*/


    }
    class Program
    {
        static void Main(string[] args)
        {
            //IPolygon p = new IPolygon();
            //Rect r = new Rect(10, 10); // 매개변수 2개짜리 생성자가 필요
            Rect r = new Rect { Width = 10, Height = 10 }; // 객체 초기화 문법
            // Rect r = new Rect();
            // r.Width = 10;
            // r.Height = 10;

            //r.Draw(); // 암시적으로 구현한 것 호출
            ((IPolygon)r).Draw(); // 명시적으로 구현한 것 호출

        }
    }
}
