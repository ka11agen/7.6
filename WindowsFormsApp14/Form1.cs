﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        int[] x = new int[15] { 55, 50, 60, 45, 55, 65, 40, 50, 60, 70, 35, 45, 55, 65, 75 };
        int[] y = new int[15] { 79, 69, 69, 59, 59, 59, 49, 49, 49, 49, 39, 39, 39, 39, 39 };
        int[] _x = new int[15] { 55, 50, 60, 45, 55, 65, 40, 50, 60, 70, 35, 45, 55, 65, 75 };
        int[] _y = new int[15] { 79, 69, 69, 59, 59, 59, 49, 49, 49, 49, 39, 39, 39, 39, 39 };
        int[] x1= new int[15] { 45, 55, 65, 35, 75, 50, 40, 60, 70, 55, 45, 65, 50, 60, 55 };
        int[] y1 = new int[15] { 170, 170, 170, 170, 170, 160, 160, 160, 160, 150, 150, 150, 140, 140, 130 };
        int q = 1;
        int MyTime=0;
        int z = 0;
        int k = 14;
        int c = 0;
        Point[] p = new Point[15];
        Pen pen = new Pen(Color.Black);
        SolidBrush brush= new SolidBrush(Color.Black);
        private Point _direction = Point.Empty;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);

            UpdateStyles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k >= 0) { Refresh(); }
            else
            {
                for (int i=0; i<15; i++)
                {
                    x[i] = _x[i];
                    y[i] = _y[i];  
                }
                z = 0;
                k = 14;
                c = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _direction.Y = 10;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(pen, 0, 0, 120, 180);
            g.DrawLine(pen, 0, 180, 120, 0);
            g.DrawLine(pen, 0, 180, 120, 180);
            g.DrawLine(pen, 0, 0, 120, 0);
            for (int i = 0; i < 15; i++)
            {
                g.FillEllipse(brush, x[i], y[i], 10, 10);
            }
            if (y[z] < y1[c] - 10)
            {
                y[z] += _direction.Y;
            }
            else
            {
                y[z] = y1[c];
                x[z] = x1[c];
                x[k] = _x[0];
                y[k] = _y[0];
                z = k;
                k--;
                c++;
            }
    }

        private void button1_Click(object sender, EventArgs e)
        {
            int R = int.Parse(textBox1.Text);
            int H = int.Parse(textBox2.Text);
            this.pictureBox1.Location = new Point(R, H);
            timer1.Start();
            timer2.Start();
            button2.Focus();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MyTime++;
            label1.Text = MyTime.ToString();

        }



        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (q == 1)
            {
                timer1.Stop();
                timer2.Stop();
                q = 0;
            }
            else
            {
                timer1.Start();
                timer2.Start();
                q = 1;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (q == 1) { q = 0; }
            timer1.Stop();
            timer2.Stop();

        }
    }
}
