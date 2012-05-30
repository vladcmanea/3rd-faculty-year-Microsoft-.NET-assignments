using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Drawing.Drawing2D;

namespace L3P22
{
    public partial class Form2 : Form
    {
        private List<Figure> figures = new List<Figure>();
        private Form1 parent;
        private Point mouse = new Point(-1, -1);
        private List<Int32> dragIndexes = new List<Int32>();
        private List<Point> dragPositions = new List<Point>();

        private Random r = new Random(1);

        public Form2(Form1 parent)
            : base()
        {
            InitializeComponent();
            this.parent = parent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            foreach (Figure figure in figures)
            {
                figure.paint(dc);
            }
            base.OnPaint(e);
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    List<Figure> oks = new List<Figure>();
                    for (int i = 0; i < figures.Count; ++i)
                    {
                        if (!figures[i].intersects(new Point(e.X, e.Y)))
                        {
                            oks.Add(figures[i]);
                        }
                    }
                    if (oks.Count < figures.Count)
                    {
                        if (MessageBox.Show("Are you sure you want to delete " + 
                            (figures.Count - oks.Count) + " item(s)?", "Delete Items", MessageBoxButtons.YesNo) == 
                            DialogResult.Yes)
                        {
                            figures = oks;
                            this.Refresh();
                        }
                    }
                }
                else
                {
                    if (Control.ModifierKeys != Keys.Control)
                    {
                        parent.b.Items.Clear();
                        for (int i = 0; i < figures.Count; ++i)
                        {
                            if (figures[i].intersects(new Point(e.X, e.Y)))
                            {
                                // informatii despre figura, brush and pen
                                parent.b.Items.Add(figures[i].Pen.ToString() + " " 
                                    + figures[i].Pen.Brush.ToString() + " at pos " + 
                                    figures[i].Position.ToString());   


                            }
                        }
                    }
                }
                if (Control.ModifierKeys == Keys.Control)
                {
                    mouse = new Point(e.X, e.Y);
                    dragIndexes.Clear();
                    dragPositions.Clear();
                    for (int i = 0; i < figures.Count; ++i)
                    {
                        if (figures[i].intersects(mouse))
                        {
                            dragIndexes.Add(i);
                            dragPositions.Add(figures[i].Position);
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                int red = r.Next(256);
                int grn = r.Next(256);
                int blu = r.Next(256);
                if (parent.g.SelectedItem != null)
                {
                    if (parent.g.SelectedItem.Equals("Rectangle"))
                    {
                        int w = r.Next(300) + 30;
                        int h = r.Next(300) + 30;
                        int g = r.Next(5) + 1;
                        bool ok = false;
                        for (int k = 0; k < figures.Count && ok == false; ++k)
                            if (figures[k].intersects(new Point(e.X, e.Y)))
                                ok = true;
                        if (ok == false)
                            figures.Add(new Rectangle(new Point(e.X, e.Y), new Point(w, h), new Pen(Color.FromArgb(red, grn, blu), g)));
                    }
                    else if (parent.g.SelectedItem.Equals("Circle"))
                    {
                        int d = r.Next(300) + 30;
                        int g = r.Next(5) + 1;
                        bool ok = false;
                        for (int k = 0; k < figures.Count && ok == false; ++k)
                            if (figures[k].intersects(new Point(e.X, e.Y)))
                                ok = true;
                        if (ok == false)
                            figures.Add(new Circle(new Point(e.X, e.Y), d, new Pen(Color.FromArgb(red, grn, blu), g)));
                    }
                }
                this.Refresh();
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    mouse = new Point(-1, -1);
                    dragIndexes.Clear();
                    dragPositions.Clear();
                    this.Refresh();
                }
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    for (int j = 0; j < dragIndexes.Count; ++j)
                    {
                        figures[dragIndexes[j]].Position = new Point(dragPositions[j].X + e.X - mouse.X, dragPositions[j].Y + e.Y - mouse.Y);
                    }
                    this.Refresh();
                }
            }
        }
    }
}
