using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Inheritance
{
    class Rect : Polygon
    {
        private int width;
        private int height;
        
        public Rect()
        {
            width = 0;
            height = 0;
        }
        public Rect(int x, int y, int w, int h) : base (x, y) // 부모 생성자 호출
        {
            width = w;
            height = h;
            /*// 1. Polygon() 생성하고 나서 2. 수정
            this.x = x; // base.x = x;
            this.y = y; // base.y = y;*/
        }

        public void Test()
        {
            x = 10;
        }

        public override void Draw()
        {
            //Console.WriteLine($"x={x} y={y}");
            base.Draw();
            Console.WriteLine($"width={width} height={height}");
        }

        public override double GetArea()
        {
            return width * height;
        }
    }
}
