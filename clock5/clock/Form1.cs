using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 form2;
        DateTime time = new DateTime();
        Color cc;
        int mod;
        int del;
        bool op;
        List<DateTime> target = new List<DateTime>();
        int almost = 0;
        int altha = 255;
        int move = -1;
        DateTime aim;
        TimeSpan cDoun;
        int[] coun = new int[3];

        private void Form1_Load(object sender, EventArgs e)
        {
            form2 = new Form2();

            label3.Location = new Point(label1.Location.X + label1.Width, label1.Location.Y + label1.Height - label3.Height);

            setTarget();
        }

        private void setTarget()
        {
            target.Add(new DateTime(time.Year, time.Month, time.Day, 9, 0, 0));
            target.Add(new DateTime(time.Year, time.Month, time.Day, 10, 0, 0));
            target.Add(new DateTime(time.Year, time.Month, time.Day, 11, 0, 0));
            target.Add(new DateTime(time.Year, time.Month, time.Day, 12, 0, 0));
            target.Add(new DateTime(time.Year, time.Month, time.Day, 14, 0, 0));
            target.Add(new DateTime(time.Year, time.Month, time.Day, 15, 0, 0));
            target.Add(new DateTime(time.Year, time.Month, time.Day, 15, 55, 0));
            target.Add(new DateTime(time.Year, time.Month, time.Day, 17, 0, 0));
        }


        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            reposition();
        }

        private void reposition()
        {
            try
            {
                label1.Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);
                label2.Location = new Point((this.Width - label2.Width) / 2, label2.Location.Y);
                pictureBox1.Location= new Point((this.Width - pictureBox1.Width) / 2, pictureBox1.Location.Y);
                label5.Location = new Point(label4.Location.X + label4.Width / 2 - label5.Width / 2,label4.Location.Y-label5.Height*3/2);
                label4.Location = new Point((this.Width-pictureBox1.Width)/2/2-label4.Width/2+pictureBox1.Location.X+pictureBox1.Width, pictureBox1.Location.Y + pictureBox1.Height - label4.Height-20);
                form2.re = false;
                pictureBox2.Location = pictureBox1.Location;
                pictureBox2.Size = pictureBox1.Size;
            
                if (label1.Visible)
                {
                    label3.Location = new Point(label1.Location.X + label1.Width, label1.Location.Y + label1.Height - label3.Height);
                }
                else
                {
                    label3.Location = new Point(label2.Location.X + label2.Width/2-label3.Width/2, label2.Location.Y + label2.Height);
                }
            }
            catch { }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            form2 = new Form2();
            form2.circleC = cc;
            form2.backC = this.BackColor;
            form2.numberC = label1.ForeColor;
            form2.mode = mod;
            form2.delay = del;
            form2.Show();
        }

        List<DateTime> clas = new List<DateTime>();

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (almost == 0)
            //{
            //    label5.Visible = true;
            //}
            //else
            //{
            //    label5.Visible = false;
            //}
            //for (int a = target.Count - 1; a >= 0; a--) 
            //{
            //    if (DateTime.Compare(time, target[a]) > 0)
            //    {
            //        label5.Text = $"第{a + 1}節";
            //    }
            //}

            if (form2.open)
            {
                if (time.Hour == 0 && time.Minute == 0 && time.Second == 1)
                {
                    target.Clear();
                    setTarget();
                }

                foreach (DateTime d in target)
                {
                    if (d.Hour * 60 * 60 + d.Minute * 60 + d.Second == time.Hour * 60 * 60 + time.Minute * 60 + time.Second + form2.delay + 5 * 60)
                    {
                        almost++;
                    }
                }
                if (almost == 1)
                {
                    label4.Visible = true;
                    label4.ForeColor = form2.numberC;
                    almost++;
                    aim = time;
                    aim=aim.AddMinutes(5);
                    altha = 100;
                }
                if (almost >= 1)
                {
                    label4.ForeColor = Color.FromArgb(label4.ForeColor.R*altha/255+this.BackColor.R*(255-altha)/255, label4.ForeColor.G * altha / 255 + this.BackColor.G * (255 - altha) / 255, label4.ForeColor.B * altha / 255 + this.BackColor.B * (255 - altha) / 255);

                    altha += move;
                    if (altha > 255)
                    {
                        altha = 255;
                        move *= -1;
                    }
                    else if (altha < 0)
                    {
                        altha = 0;
                        move *= -1;
                    }
                    cDoun = aim - time;

                    label4.Text = $"{cDoun.Minutes}:{cDoun.Seconds.ToString("00")}.{cDoun.Milliseconds.ToString("000")}";
                    if (cDoun.Minutes == 0 && cDoun.Seconds == 2)
                    {
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = false;
                    }
                    if (cDoun.Milliseconds<0)
                    {
                        almost = 0;
                        label4.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = true;
                    }
                }
            }

            mod = form2.mode;
            cc = form2.circleC;
            del = form2.delay;
            op = form2.open;

            if (form2.re)
            {
                reposition();
            }
            label1.ForeColor = form2.numberC;
            label2.ForeColor = form2.numberC;
            label3.ForeColor = form2.numberC;
            label4.ForeColor = form2.numberC;
            this.BackColor = form2.backC;

            time = DateTime.Now;
            if (form2.mode == 2)
            {
                label1.Visible = false;
                label2.Visible = true;
                string h = Convert.ToString(time.Hour, form2.mode);
                while (h.Length < 7)
                {
                    h = "0" + h;
                }
                string m = Convert.ToString(time.Minute, form2.mode);
                while (m.Length < 7)
                {
                    m = "0" + m;
                }
                string s = Convert.ToString(time.Second, form2.mode);
                while (s.Length < 7)
                {
                    s = "0" + s;
                }
                label2.Text = $"{h}:{m}:{s}";
                label3.Text = "(2)";
                label3.Location = new Point(label2.Location.X + label2.Width / 2 - label3.Width / 2, label2.Location.Y + label2.Height);
            }
            else if (form2.mode == 16)
            {
                label1.Visible = true;
                label2.Visible = false;
                string h = time.Hour.ToString("X");
                if (h.Length < 2)
                {
                    h = "0" + h;
                }
                string m = time.Minute.ToString("X");
                if (m.Length < 2)
                {
                    m = "0" + m;
                }
                string s = time.Second.ToString("X");
                if (s.Length < 2)
                {
                    s = "0" + s;
                }
                label1.Text = $"{h}:{m}:{s}";
                label1.Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);
                label3.Text = $"({form2.mode})";
                label3.Location = new Point(label1.Location.X + label1.Width, label1.Location.Y + label1.Height - label3.Height);
            }
            else if (form2.mode == 3)
            {
                label1.Visible = false;
                label2.Visible = true;
                string h = Convert.ToString(time.Hour, 2);
                while (h.Length < 7)
                {
                    h = "0" + h;
                }
                string hh = h.Substring(0, 1);
                for (int a = 1; a < 7; a++)
                {
                    if (int.Parse(h.Substring(a - 1, 1)) + int.Parse(h.Substring(a, 1)) == 1)
                    {
                        hh += "1";
                    }
                    else
                    {
                        hh += "0";
                    }
                }
                string m = Convert.ToString(time.Minute, 2);
                while (m.Length < 7)
                {
                    m = "0" + m;
                }
                string mm = m.Substring(0, 1);
                for (int a = 1; a < 7; a++)
                {
                    if (int.Parse(m.Substring(a - 1, 1)) + int.Parse(m.Substring(a, 1)) == 1)
                    {
                        mm += "1";
                    }
                    else
                    {
                        mm += "0";
                    }
                }
                string s = Convert.ToString(time.Second, 2);
                while (s.Length < 7)
                {
                    s = "0" + s;
                }
                string ss = s.Substring(0, 1);
                for (int a = 1; a < 7; a++)
                {
                    if (int.Parse(s.Substring(a - 1, 1)) + int.Parse(s.Substring(a, 1)) == 1)
                    {
                        ss += "1";
                    }
                    else
                    {
                        ss += "0";
                    }
                }
                label2.Text = $"{hh}:{mm}:{ss}";
                label3.Text = "(GRAY)";
                label3.Location = new Point(label2.Location.X + label2.Width / 2 - label3.Width / 2, label2.Location.Y + label2.Height);
            }
            else if (form2.mode == 11)
            {
                label1.Visible = true;
                label2.Visible = false;
                string h = ((char)time.Hour).ToString();
                if (h == ""||time.Hour==11 || time.Hour == 12 || time.Hour == 13 )
                {
                    h = "  ";
                }

                string m = ((char)time.Minute).ToString();
                if (m == "" || time.Minute == 11 || time.Minute == 12 || time.Minute == 13 )
                {
                    m = "  ";
                }

                string s = ((char)time.Second).ToString();
                if (s == "" || time.Second == 11 || time.Second == 12 || time.Second == 13 )
                {
                    s = "  ";
                }

                label1.Text = $"{h} : {m} : {s}";
                label3.Text = $"(ASCII)";
                label3.Location = new Point(label1.Location.X + label1.Width, label1.Location.Y + label1.Height - label3.Height);
                label1.Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);
            }
            else if (form2.mode != 1)
            {
                label1.Visible = true;
                label2.Visible = false;
                string h = Convert.ToString(time.Hour, form2.mode);
                if (h.Length < 2)
                {
                    h = "0" + h;
                }
                string m = Convert.ToString(time.Minute, form2.mode);
                if (m.Length < 2)
                {
                    m = "0" + m;
                }
                string s = Convert.ToString(time.Second, form2.mode);
                if (s.Length < 2)
                {
                    s = "0" + s;
                }
                label1.Text = $"{h}:{m}:{s}";
                label3.Text = $"({form2.mode})";
                label3.Location = new Point(label1.Location.X + label1.Width, label1.Location.Y + label1.Height - label3.Height);
            }
            else
            {
                label1.Visible = false;
                label2.Visible = true;
                string h1 = Convert.ToString((int)(time.Hour / 10), 2);
                string h2 = Convert.ToString((int)(time.Hour % 10), 2);
                string m1 = Convert.ToString((int)(time.Minute / 10), 2);
                string m2 = Convert.ToString((int)(time.Minute % 10), 2);
                string s1 = Convert.ToString((int)(time.Second / 10), 2);
                string s2 = Convert.ToString((int)(time.Second % 10), 2);
                while (h1.Length < 4) h1 = "0" + h1;
                while (h2.Length < 4) h2 = "0" + h2;
                while (m1.Length < 4) m1 = "0" + m1;
                while (m2.Length < 4) m2 = "0" + m2;
                while (s1.Length < 4) s1 = "0" + s1;
                while (s2.Length < 4) s2 = "0" + s2;
                label2.Text = $"{h1} {h2} : {m1} {m2} : {s1} {s2}";
                label3.Text = "(BCD)";
                label3.Location = new Point(label2.Location.X + label2.Width / 2 - label3.Width / 2, label2.Location.Y + label2.Height);
            }



            Bitmap bpm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bpm);
            g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
            g.DrawEllipse(new Pen(form2.circleC,3), -310, -310, 620, 620);
            for (int a = 0; a < 60; a ++)
            {
                g.DrawLine(new Pen(form2.circleC, 5), 290 * (float)Math.Sin(Math.PI * 2 / 60 * a), 290 * (float)Math.Cos(Math.PI * 2 / 60 * a), 310 * (float)Math.Sin(Math.PI * 2 / 60 * a), 310 * (float)Math.Cos(Math.PI * 2 / 60 * a));
            }
            for (int a = 0; a < 12; a++)
            {
                g.DrawLine(new Pen(form2.circleC, 5), 260 * (float)Math.Sin(Math.PI / 6 * a), 260 * (float)Math.Cos(Math.PI / 6 * a), 310 * (float)Math.Sin(Math.PI /6 * a), 310 * (float)Math.Cos(Math.PI /6 * a));
            }

            g.DrawLine(new Pen(Color.Red,5), 0, 0, 300 * (float)Math.Sin(Math.PI * 2 *(time.Second+(double)time.Millisecond/1000) / 60), -300 * (float)Math.Cos(Math.PI * 2 * (time.Second + (double)time.Millisecond / 1000) / 60));
            g.DrawLine(new Pen(form2.circleC, 6), 0, 0, 250 * (float)Math.Sin(Math.PI * 2 * (time.Minute+(double)time.Second/60) / 60), -250 * (float)Math.Cos(Math.PI * 2 * (time.Minute + (double)time.Second / 60) / 60));
            g.DrawLine(new Pen(form2.circleC, 7), 0, 0, 200 * (float)Math.Sin(Math.PI * 2 * (time.Hour+(double)time.Minute/60) / 12), -200 * (float)Math.Cos(Math.PI * 2 * (time.Hour + (double)time.Minute / 60) / 12));
            pictureBox1.Image = bpm;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
