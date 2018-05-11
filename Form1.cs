using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastWritingApp
{
    public partial class Form1 : Form
    {
        
        string textToWrite = "Księżyc to jedyne ciało niebieskie, do którego podróżowali i " +
            "na którym wylądowali ludzie. Do tej pory na księżycowym globie stanęło 12 osób. Pierwszym " +
            "sztucznym obiektem w historii, który przeleciał blisko Księżyca, była wystrzelona przez Związek " +
            "Radziecki sonda kosmiczna Łuna 1; Łuna 2 jako pierwszy statek osiągnęła powierzchnię ziemskiego " +
            "satelity, zaś Łuna 3 jeszcze w tym samym roku, co poprzedniczki - 1959 - wykonała pierwsze zdjęcia " +
            "niewidocznej z Ziemi strony Księżyca.";


        string[] textToWriteWords;

        Color normalTextColor = Color.Black;
        Color wrongTextColor = Color.Red;

        int currentWord = 0;

        int timePassed = 0;

        float wordsPerMinute;

        Timer t = new Timer();

        public Form1()
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();
            

            InitializeComponent();
            textBox1.Text = textToWrite;

            textToWriteWords = textToWrite.Split();

            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            if (currentWord >= textToWriteWords.Length)
            {
                return;
            }               
                
            CalculateWordsPerMinute();

            textBox3.Text = textToWriteWords[currentWord];
            textBox5.Text = "Time: " + timePassed.ToString() + " seconds";
            textBox4.Text = wordsPerMinute.ToString("0") + " words per minute";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (currentWord >= textToWriteWords.Length)
            {
                t.Stop();
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                return;

            }

            if (textBox2.Text == textToWriteWords[currentWord])
            {
                if(currentWord > textToWriteWords.Length)
                {
                   
                }
                else if (currentWord < textToWriteWords.Length)
                {
                    currentWord++;
                    textBox2.Text = "";

                    if (currentWord > textToWriteWords.Length)
                        currentWord = textToWriteWords.Length;

                }

            }
            else
            {
                if (textBox2.Text.Length < textToWriteWords[currentWord].Length)
                {
                    for (int i = 0; i < textBox2.Text.Length; i++)
                    {
                        if (textBox2.Text[i] != textToWriteWords[currentWord][i])
                        {
                            textBox2.ForeColor = wrongTextColor;
                            return;
                        }
                        else
                        {
                            textBox2.ForeColor = normalTextColor;
                        }
                    }
                }
            }

            UpdateDisplay();
        }
            

        void CalculateWordsPerMinute()
        {
            if (timePassed == 0)
                return;

            wordsPerMinute = currentWord / (timePassed / 60f);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timePassed++;
            UpdateDisplay();         
        }


    }
}
