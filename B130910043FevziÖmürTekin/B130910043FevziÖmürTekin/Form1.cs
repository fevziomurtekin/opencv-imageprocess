using System;
using OpenCvSharp;
using OpenCvSharp.MachineLearning;
using OpenCvSharp.Blob;
using OpenCvSharp.UserInterface;
using OpenCvSharp.CPlusPlus;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp.Extensions;
using System.IO;




namespace CSharp_Proje_Ödevi_Deneme_vol11._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool durum = false;

            OpenFileDialog ds = new OpenFileDialog();
            ds.Title = "Resim seç";
            ds.Filter = "(*.jpg) | *.jpg ";

            if (ds.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = new Bitmap(ds.OpenFile());
                durum = true;
            }

            var haarCascade = new CascadeClassifier("C:\\Users\\Ömür\\Desktop\\haarcascade_frontalface_alt2.xml");
            var gray = new Mat(ds.FileName, LoadMode.GrayScale);
            Rect[] faces = haarCascade.DetectMultiScale(gray, 1.08, 2, HaarDetectionType.ScaleImage, new OpenCvSharp.CPlusPlus.Size(30, 30));
            int yüzSayısı = faces.Length;


            if (durum)
            {
                if (!Directory.Exists(@"C:\Users\Ömür\Desktop\Resimler"))
                    Directory.CreateDirectory(@"C:\Users\Ömür\Desktop\Resimler");
                if (!Directory.Exists(@"C:\Users\Ömür\Desktop\Resimler\insan"))
                    Directory.CreateDirectory(@"C:\Users\Ömür\Desktop\Resimler\insan");
                if (!Directory.Exists(@"C:\Users\Ömür\Desktop\Resimler\Manzara"))
                    Directory.CreateDirectory(@"C:\Users\Ömür\Desktop\Resimler\Manzara");
                string imagePath = ds.FileName.ToString();
                string imagepath = imagePath.ToString();
                if (ds.FileName.ToString() != "")
                {

                    imagepath = imagepath.Substring(imagepath.LastIndexOf("\\"));
                    imagepath = imagepath.Remove(0, 1);
                }

                if (yüzSayısı < 1)
                {
                    File.Copy(ds.FileName, @"C:\Users\Ömür\Desktop\Resimler\Manzara\" + imagepath.ToString());
                    //durum = false;

                }

                else
                {
                    File.Copy(ds.FileName, @"C:\Users\Ömür\Desktop\Resimler\insan\" + imagepath.ToString());




                }

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int xKoordinatı, yKoordinatı;
            xKoordinatı = Int32.Parse(textBox1.Text);
            yKoordinatı = Int32.Parse(textBox2.Text);
            pictureBox1.Size = new System.Drawing.Size(xKoordinatı, yKoordinatı);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}