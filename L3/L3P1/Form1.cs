using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace L3P1ok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            String s = ((TextBox)sender).Text;
            txt2.Text = txt3.Text = "";
            for (int i = 0; i < s.Length; ++i)
            {
                if (Char.IsLetter(s[i]))
                {
                    txt2.Text += s[i];
                }
                else if (Char.IsDigit(s[i]))
                {
                    txt3.Text += s[i];
                }
            }
            lb.Items.Clear();
            StackTrace stackTrace = new StackTrace();
            StackFrame[] stackFrames = stackTrace.GetFrames();
            foreach (StackFrame stackFrame in stackFrames)
            {
                lb.Items.Add(stackFrame.GetMethod().Name);
            }
        }
    }
}
