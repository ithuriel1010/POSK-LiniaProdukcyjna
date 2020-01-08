using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiniaProdukcyjnaApp
{
    public partial class Form1 : Form
    {
        int licznik = 0;
        Image tort = Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/tort.png");
        int random;
        public Form1()
        {
            InitializeComponent();
            pictureBox5.BackColor = Color.Black;
            var thread = new Thread(StartCounting);
            thread.IsBackground = true;
            thread.Start();


        }

        private delegate void SetImageDelegate(Image path);

        private void SetImagePicture4(Image path)
        {
            pictureBox4.Visible = true;
            pictureBox4.Image = path;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }
        private void SetImagePicture2(Image path)
        {
            pictureBox2.Visible = true;
            pictureBox2.Image = path;
            pictureBox4.Visible = false;
        }
        private void SetImagePicture3(Image path)
        {
            pictureBox3.Visible = true;
            pictureBox3.Image = path;
            pictureBox4.Visible = false;
            pictureBox2.Visible = false;
        }
        private void SetImagePicture1(Image path)
        {
            pictureBox1.Visible = true;
            pictureBox1.Image = path;
            pictureBox4.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }
        private void DoNothing(Image path)
        {
            pictureBox1.Visible = false;
            pictureBox4.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }


        private void StartCounting()
        {

            while(true)
            {
                licznik++;
                Thread.Sleep(2000);

                if (licznik == 1)
                {
                    random = GetRandomNumber(0, 4);
                    if(random==2)
                    {
                        tort= Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/tort2.png");
                    }
                    else
                    {
                        tort = Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/tort.png");
                    }
                    pictureBox4.Invoke(new SetImageDelegate(SetImagePicture4), tort);
                }
                else if (licznik == 2)
                {
                    pictureBox2.Invoke(new SetImageDelegate(SetImagePicture2), tort);
                }
                else if (licznik == 3)
                {
                    pictureBox3.Invoke(new SetImageDelegate(SetImagePicture3), tort);
                }
                else if (licznik == 4)
                {
                    pictureBox1.Invoke(new SetImageDelegate(SetImagePicture1), tort);
                }
                else if (licznik == 5)
                {
                    pictureBox1.Invoke(new SetImageDelegate(DoNothing), tort);
                    licznik = 0;
                }
            }
            


            //thread.Start();
        }

        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
