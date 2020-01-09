﻿using System;
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
        Boolean somethingWrong = false;
        public Form1()
        {
            InitializeComponent();
            pictureBox5.BackColor = Color.Black;
            pictureBox6.Image= Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/tort0.png");
            Font f = new Font("Arial", 20, FontStyle.Bold);
            Font f1 = new Font("Arial", 10, FontStyle.Bold);
            button1.Font = f;
            button2.Font = f;
            button3.Font = f;
            button4.Font = f;
            button5.Font = f;
            button6.Font = f;
            label2.Font = f1;
            label3.Font = f1;
            label4.Font = f1;
            label5.Font = f1;
            label6.Font = f1;
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

        private delegate void ChangeButtonsDelegate();
        private void TooMuchChocolate()
        {
            button1.BackColor = Color.Red;
            button1.Text = "ZMNIEJSZ";
            tort = Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/tort2.png");
            somethingWrong = true;
        }

        private void TooMuchCream()
        {
            button2.BackColor = Color.Red;
            button2.Text = "ZMNIEJSZ";
            tort = Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/tort3.png");
            somethingWrong = true;
        }
        private void TooMuchBakingPowder()
        {
            button3.BackColor = Color.Red;
            button3.Text = "ZMNIEJSZ";
            tort = Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/tort4.png");
            somethingWrong = true;
        }
        private void TooHotOwen()
        {
            button4.BackColor = Color.Red;
            button4.Text = "ZMNIEJSZ TEMP.";
            tort = Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/burnedCake.png");
            somethingWrong = true;
        }
        private void TooMuchSugar()
        {
            button5.BackColor = Color.Red;
            button5.Text = "ZMNIEJSZ";
            tort = Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/donut.png");
            somethingWrong = true;
        }


        private void StartCounting()
        {

            while (true)
            {
                licznik++;
                Thread.Sleep(500);

                switch (licznik)
                {
                    case 1:

                        if (somethingWrong == false)
                        {
                            random = GetRandomNumber(0, 10);
                            if (random == 2)
                            {
                                button1.Invoke(new ChangeButtonsDelegate(TooMuchChocolate));
                            }
                            else if(random==3)
                            {
                                button2.Invoke(new ChangeButtonsDelegate(TooMuchCream));
                            }
                            else if (random == 4)
                            {
                                button3.Invoke(new ChangeButtonsDelegate(TooMuchBakingPowder));
                            }
                            else if (random == 5)
                            {
                                button4.Invoke(new ChangeButtonsDelegate(TooHotOwen));
                            }
                            else if (random == 6)
                            {
                                button5.Invoke(new ChangeButtonsDelegate(TooMuchSugar));
                            }
                            else
                            {
                                tort = Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/tort.png");
                            }
                        }
                        else
                        {
                            //tort = Image.FromFile("D:/Studia/Semestr V/Współczesne języki programowania/Projekt/Sweets/PNG/tort.png");
                        }

                        pictureBox4.Invoke(new SetImageDelegate(SetImagePicture4), tort);
                        break;

                    case 2:

                        pictureBox2.Invoke(new SetImageDelegate(SetImagePicture2), tort);
                        break;

                    case 3:

                        pictureBox3.Invoke(new SetImageDelegate(SetImagePicture3), tort);
                        break;

                    case 4:

                        pictureBox1.Invoke(new SetImageDelegate(SetImagePicture1), tort);
                        break;

                    case 5:

                        pictureBox1.Invoke(new SetImageDelegate(DoNothing), tort);
                        licznik = 0;
                        break;

                }
            }
        }

        private static readonly Random getrandom = new Random();

        public object FontUnit { get; }

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
            button1.Text = "OK";
            somethingWrong = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightGray;
            button2.Text = "OK";
            somethingWrong = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.LightGray;
            button3.Text = "OK";
            somethingWrong = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.LightGray;
            button4.Text = "OK";
            somethingWrong = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.LightGray;
            button5.Text = "OK";
            somethingWrong = false;
        }
    }
}
