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
        {
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
            Bitmap rbmp = new Bitmap(bmp);
            Bitmap gbmp = new Bitmap(bmp);
            Bitmap bbmp = new Bitmap(bmp);

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

                    //set red image pixel
                    rbmp.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));

                    //set green image pixel
                    gbmp.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));

                    //set blue image pixel
                    bbmp.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));

                }
            }

            //load red image in picturebox2
            pictureBox2.Image = rbmp;

            //load green image in picturebox3
            pictureBox3.Image = gbmp;

            //load blue image in picturebox4
            pictureBox4.Image = bbmp;

            //write (save) red image
            rbmp.Save("C:\\Users\\admin\\Desktop\\Test\\Red.png");

            //write(save) green image
            gbmp.Save("C:\\Users\\admin\\Desktop\\Test\\Green.png");

            //write (save) blue image
            bbmp.Save("C:\\Users\\admin\\Desktop\\Test\\Blue.png");
        }
    }
}

