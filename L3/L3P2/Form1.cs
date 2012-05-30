using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace L3P22
{
    public partial class Form1 : Form
    {
        private Form2 form;
        public ComboBox g;
        public ListBox b;
  
        public Form1()
        {
            InitializeComponent();
            g = cb;
            g.Items.Add("Circle");
            g.Items.Add("Rectangle");
            g.SelectedItem = "Rectangle";
            b = ls;
            form = new Form2(this);
            form.Width = 600;
            form.Height = 400;
            form.Show();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            form.Refresh();
            base.OnPaint(e);
        }
    }
}
