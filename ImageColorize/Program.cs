using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageColorize
{
    public partial class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, EventArgs e)
        //private void timer_Tick1(object sender, EventArgs e)
        {
            //get RGB value from trackers
            int trackR = trackRed.Value;
            int trackG = trackGreen.Value;
            int trackB = trackBlue.Value;

            labRed.Text = trackRed.Value.ToString();
            labGreen.Text = trackGreen.Value.ToString();
            labBlue.Text = trackBlue.Value.ToString();

            //image path
            string img = "C:\\Users\\admin\\Downloads\\photo_2022-10-21_21-21-35.jpg";

            //read image
            Bitmap bmp = new Bitmap(img);

            //load original image in picturebox1
            pictureBox1.Image = Image.FromFile(img);

            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //3 bitmap for red green blue image
            Bitmap nbmp = new Bitmap(bmp);

            //red green blue image
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //setimage pixel
                    nbmp.SetPixel(x, y, Color.FromArgb(a, trackR, trackG, trackB));
                }
            }

            //load nbmp image in picturebox2
            pictureBox2.Image = nbmp;

            //write (save) red image
            nbmp.Save("C:\\Users\\admin\\Desktop\\Test\\Red.png");

        }
    }
}

