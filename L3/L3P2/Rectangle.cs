using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace L3P22
{
    class Rectangle : Figure
    {
        private Point dimensions;
        private Random r;
        private int v;

        public Rectangle(Point position, Point dimensions, Pen pen):base(position, pen)
        {
            this.dimensions = dimensions;
            r = new Random();
            v = r.Next(2);
        }

        public override void paint(Graphics dc)
        {
            if (v > 0)
            {
                dc.DrawRectangle(pen, position.X, position.Y, dimensions.X, dimensions.Y);
            }
            else
            {
                dc.FillRectangle(pen.Brush, position.X, position.Y, dimensions.X, dimensions.Y);
            }
        }

        public override bool intersects(Point p)
        {
            return (position.X <= p.X && p.X <= position.X + dimensions.X && 
                position.Y <= p.Y && p.Y <= position.Y + dimensions.Y);
        }
    }
}
