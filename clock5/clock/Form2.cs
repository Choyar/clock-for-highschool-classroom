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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Color tempcolor;
        public int mode = 10;
        public Color backC=Color.Black,numberC=Color.White,circleC=Color.White;
        public bool re = false;
        public int delay=0;
        public bool open = true;
        int FF = 0;

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            tempcolor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
            pictureBox1.BackColor = tempcolor;
            textBox1.Text = $"{Convert.ToString(tempcolor.R, 16)},{Convert.ToString(tempcolor.G, 16)},{Convert.ToString(tempcolor.B, 16)}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backC = tempcolor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numberC = tempcolor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            circleC = tempcolor;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button9.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            mode = 10;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;
            button4.Enabled = true;
            button9.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            mode = 16;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            button7.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button9.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            mode = 8;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button9.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            mode = 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button7.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button9.Enabled = false;
            button11.Enabled = true;
            button12.Enabled = true;
            mode = 2;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button7.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button9.Enabled = true;
            button11.Enabled = false;
            button12.Enabled = true;
            mode = 3;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button7.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button9.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = false;
            mode = 11;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (mode == 10)
            {
                button4.Enabled = false;
            }
            else if (mode == 16)
            {
                button5.Enabled = false;
            }
            else if (mode == 8)
            {
                button6.Enabled = false;
            }
            else if (mode == 2)
            {
                button9.Enabled = false;
            }
            else if (mode == 1)
            {
                button7.Enabled = false;
            }
            tempcolor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
            pictureBox1.BackColor = tempcolor;
            textBox1.Text = $"{Convert.ToString(tempcolor.R, 16)},{Convert.ToString(tempcolor.G, 16)},{Convert.ToString(tempcolor.B, 16)}";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (hScrollBar3.Value != 255)
            {
                hScrollBar3.Value = 255;

            }
            else
            {
                hScrollBar3.Value = 0;
            }
            tempcolor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
            pictureBox1.BackColor = tempcolor;
            textBox1.Text = $"{Convert.ToString(tempcolor.R, 16)},{Convert.ToString(tempcolor.G, 16)},{Convert.ToString(tempcolor.B, 16)}";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (hScrollBar2.Value != 255)
            {
                hScrollBar2.Value = 255;

            }
            else
            {
                hScrollBar2.Value = 0;
            }
            tempcolor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
            pictureBox1.BackColor = tempcolor;
            textBox1.Text = $"{Convert.ToString(tempcolor.R, 16)},{Convert.ToString(tempcolor.G, 16)},{Convert.ToString(tempcolor.B, 16)}";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (hScrollBar1.Value != 255)
            {
                hScrollBar1.Value = 255;

            }
            else
            {
                hScrollBar1.Value = 0;
            }
            tempcolor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
            pictureBox1.BackColor = tempcolor;
            textBox1.Text = $"{Convert.ToString(tempcolor.R, 16)},{Convert.ToString(tempcolor.G, 16)},{Convert.ToString(tempcolor.B, 16)}";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            delay = int.Parse(textBox2.Text);
        }

        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            if (hScrollBar4.Value == 0)
            {
                open = true;
            }
            else
            {
                open = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_BackColorChanged(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(255 - pictureBox1.BackColor.R, 255 - pictureBox1.BackColor.G, 255 - pictureBox1.BackColor.B);
            label1.BackColor = pictureBox1.BackColor;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hScrollBar5.Value == 0)
            {
                if (DateTime.Now.Minute % 5 == 0 && DateTime.Now.Second == 0)
                {
                    Random ran = new Random();
                    backC = Color.FromArgb(ran.Next(0, 256), ran.Next(0, 256), ran.Next(0, 256));
                    numberC = Color.FromArgb(ran.Next(0, 256), ran.Next(0, 256), ran.Next(0, 256));
                    circleC = Color.FromArgb(ran.Next(0, 256), ran.Next(0, 256), ran.Next(0, 256));
                }
                if (FF == 1)
                {
                    Random ran = new Random();
                    backC = Color.FromArgb(ran.Next(0, 256), ran.Next(0, 256), ran.Next(0, 256));
                    numberC = Color.FromArgb(ran.Next(0, 256), ran.Next(0, 256), ran.Next(0, 256));
                    circleC = Color.FromArgb(ran.Next(0, 256), ran.Next(0, 256), ran.Next(0, 256));
                    button13.BackColor = Color.FromArgb(ran.Next(0, 256), ran.Next(0, 256), ran.Next(0, 256));
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (FF == 0)
            {
                FF = 1;
            }
            else
            {
                FF = 0;
            }
            if (FF == 0)
            {
                button13.BackColor = Color.White;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int r, g, b;
            try
            {
                r = Convert.ToInt32(textBox1.Text.Split(',')[0], 16);
                g = Convert.ToInt32(textBox1.Text.Split(',')[1], 16);
                b = Convert.ToInt32(textBox1.Text.Split(',')[2], 16);
                if (r <= 255 && g <= 255 && b <= 255)
                {
                    hScrollBar1.Value = r;
                    hScrollBar2.Value = g;
                    hScrollBar3.Value = b;
                    tempcolor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
                    pictureBox1.BackColor = tempcolor;
                }
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            re = true;
        }
    }
}
