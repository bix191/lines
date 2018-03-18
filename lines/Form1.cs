using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lines
{
    public partial class Form1 : Form
    {
        private bool doDrawFlag = false;
        Pen[] pen1;
        public Form1()
        {
            InitializeComponent();
            Single lineWidth = 1;
            pen1 = new Pen[8];
            pen1[0] = new Pen(Color.Black, lineWidth);
            pen1[1] = new Pen(Color.Blue, lineWidth);
            pen1[2] = new Pen(Color.Red, lineWidth);
            pen1[3] = new Pen(Color.Violet, lineWidth);
            pen1[4] = new Pen(Color.Green, lineWidth);
            pen1[5] = new Pen(Color.Cyan, lineWidth);
            pen1[6] = new Pen(Color.Yellow, lineWidth);
            pen1[7] = new Pen(Color.White, lineWidth);
            clearPanel();
            comboBox1.SelectedIndex = 0;
        }
        private void clearPanel()
        {
            Graphics g = panel1.CreateGraphics();
            int w = panel1.Size.Width;
            int h = panel1.Size.Height;
            g.FillRectangle(new SolidBrush(Color.Gray) , 0,0,w,h);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            doDrawFlag = true;
            try
            {
                button1.Enabled = false;
                button2.Enabled = true;
                Graphics g = panel1.CreateGraphics();
                int w = panel1.Size.Width;
                int h = panel1.Size.Height;
                Point p1 = new Point(r.Next(w), r.Next(h));
                while (doDrawFlag)
                {
                    g = panel1.CreateGraphics();
                    w = panel1.Size.Width;
                    h = panel1.Size.Height;
                    Point p2 = new Point(r.Next(w), r.Next(h));
                    g.DrawLine(pen1[r.Next(8)], p1, p2);
                    Application.DoEvents();
                    p1 = p2;
                }
            } catch (System.ObjectDisposedException)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;
            doDrawFlag = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Single lineWidth = Single.Parse(numericUpDown1.Value.ToString());
            pen1[0].Width = lineWidth;
            pen1[1].Width = lineWidth;
            pen1[2].Width = lineWidth;
            pen1[3].Width = lineWidth;
            pen1[4].Width = lineWidth;
            pen1[5].Width = lineWidth;
            pen1[6].Width = lineWidth;
            pen1[7].Width = lineWidth;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            clearPanel();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DashStyle[] ds =
            {
                DashStyle.Solid,
                DashStyle.Dot,
                DashStyle.DashDot,
                DashStyle.DashDotDot
            };
            for (int penIdx = 0; penIdx < pen1.Length; penIdx++)
            {
                pen1[penIdx].DashStyle = ds[comboBox1.SelectedIndex];
            }

        }
    }
}
