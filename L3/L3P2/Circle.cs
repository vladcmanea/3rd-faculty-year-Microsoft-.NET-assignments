using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace L3P22
{
    class Circle: Figure
    {
        private Int32 radius;
        private Random r;
        private int v;

        public Circle(Point position, Int32 radius, Pen pen):base(position, pen)
        {
            this.radius = radius;
            r = new Random();
            v = r.Next(2);
        }

        public override void paint(Graphics dc)
        {
            if (v > 0)
            {
                dc.DrawEllipse(pen, position.X - radius, position.Y - radius, 2 * radius, 2 * radius);
            }
            else
            {
                dc.FillEllipse(pen.Brush, position.X - radius, position.Y - radius, 2 * radius, 2 * radius);
            }
        }

        public override bool intersects(Point p)
        {
            return (Math.Pow(radius, 2) >= Math.Pow(p.X - position.X, 2) + Math.Pow(p.Y - position.Y, 2));
        }
    }
}
