using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Inheritance
{
    abstract class Polygon
    {
        protected int x;
        protected int y;

        public Polygon()
        {
            x = 0;
            y = 0;
        }

        public Polygon(int a, int b)
        {
            x = a;
            y = b;
        }

        public virtual void Draw()
        {
            Console.WriteLine($"x={x} y={y}");
        }
        public abstract double GetArea();
    }
}
