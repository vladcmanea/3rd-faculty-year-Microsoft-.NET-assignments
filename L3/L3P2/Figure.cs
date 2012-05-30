using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace L3P22
{
    class Figure: Paintable, Intersectable
    {
        protected Point position;
        protected Pen pen;

        public Point Position
        {
           get 
           { 
               return position; 
           }
           set 
           { 
               position = value; 
           }
        }

        public Pen Pen
        {
            get
            {
                return pen;
            }
            set
            {
                pen = value;
            }
        }

        public Figure(Point position, Pen pen)
        {
            this.position = position;
            this.pen = pen;
        }

        public virtual void paint(Graphics e)
        {

        }

        public virtual bool intersects(Point p)
        {
            return false;
        }
    }
}
