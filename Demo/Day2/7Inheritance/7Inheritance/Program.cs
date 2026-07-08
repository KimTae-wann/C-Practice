using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Polygon p = new Polygon();
            //p.Draw();
            Polygon p;
            Rect r = new Rect(10, 10, 100, 100);
            r.Draw(); // 상속받아서 사용
            // r.x --> 접근제어 
            
            //r = (Rect)p; // 다운캐스팅 // InvalidCastException
            //if (p is Rect) // is-kind-of
                //r = (Rect)p;

            //r = p as Rect; // r 는 null 이 됨

            // virtual, override 키워드 없을 때
            //p = r; // 업캐스팅
            // p = (Polygon) r;
            p.Draw(); // Rect.Draw() 가 아닌 Polygon.Draw() 호출
            // Static Binding (Compile-time Binding): 타입정보(Polygon)

            // virtual, override 키워드 있을 때
            // Dynamic Binding (Run-time Binding): 추가적인 정보필요 
            // virtual 키워드를 사용해서 동적바인딩 해줌
            p.Draw();

            Circle c = new Circle(10, 10, 5);
            p = c;
            p.Draw();
            Console.WriteLine($"면적: {p.GetArea()}");

            Polygon[] arr = new Polygon[2];
            arr[0] = r;
            arr[1] = c;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Draw();
                Console.WriteLine($"면적: {arr[i].GetArea()}");
            }
        }
    }
}
