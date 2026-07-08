using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Inheritance
{
    class Circle : Polygon
    {
        private int radius;
        public Circle()
        {
            radius = 0;
        }

        public Circle(int x, int y, int r) : base(x, y)
        {
            radius = r;
        }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"radius={radius}");
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        } namespace 
    }
}
