using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_izobr
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        public static byte clamp(float value, float min, float max)
        {
            return (byte)(Math.Min(Math.Max(min, value), max));
        }

        public static int clamp(int value, int min, int max)
        {
            return (int)(Math.Min(Math.Max(min, value), max));
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"; ;
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)dialog.OpenFile();
                
                switch (dialog.FilterIndex)
                {
                    case 1:
                        pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }

        public Bitmap GrayScale(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    int n = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
                    Color resultColor = Color.FromArgb(n, n, n);

                    resultImage.SetPixel(i, j, resultColor);
                }
            return resultImage;
        }

        public Bitmap Average(Bitmap sourceImage)
        {
            
            Bitmap resImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Height; i++)
                for (int j = 0; j < sourceImage.Width; j++)
                {
                    int ct = 0;
                    int radiusX = 1;
                    int radiusY = radiusX;

                    byte resultR;
                    byte resultG;
                    byte resultB;

                    byte[] R = new byte[9];
                    byte[] G = new byte[9];
                    byte[] B = new byte[9];

                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = clamp(j + k, 0, sourceImage.Width - 1);
                            int idY = clamp(i + l, 0, sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idX, idY);

                            R[ct] = neighborColor.R;
                            G[ct] = neighborColor.G;
                            B[ct] = neighborColor.B;
                            ct++;
                        }
                    int sR = 0;
                    int sG = 0;
                    int sB = 0;

                    for (int k = 0; k < R.Length;k++)
                        sR+=R[k];
                    for (int k = 0; k < G.Length; k++)
                        sG += G[k];
                    for (int k = 0; k < B.Length; k++)
                        sB += B[k];

                    resultR = (byte)(Math.Round((decimal)sR / R.Length));
                    resultG = (byte)(Math.Round((decimal)sG / G.Length));
                    resultB = (byte)(Math.Round((decimal)sB / B.Length));

                    Color res = Color.FromArgb(resultR, resultG, resultB);

                    resImage.SetPixel(j, i, res);

                }
            return resImage;
        }

        public Bitmap AutoContrast(Bitmap sourceImage)
        {

            Bitmap resImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            byte maxIntensity = 0, minIntensity = 255;

            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color color = sourceImage.GetPixel(x, y);

                    byte intensity = (byte)(.299 * color.R + .587 * color.G + .114 * color.B);

                    maxIntensity = Math.Max(maxIntensity, intensity);
                    minIntensity = Math.Min(minIntensity, intensity);

                }

            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color color = sourceImage.GetPixel(x, y);

                    byte intensity = (byte)(.299 * color.R + .587 * color.G + .114 * color.B);

                    byte newIntensity = (byte)((intensity - minIntensity) * ((255f) / (float)(maxIntensity - minIntensity)));
                    byte R, G, B;

                    if (intensity == 0)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                    }
                    else
                    {
                        R = (byte)(color.R * newIntensity / intensity);
                        G = (byte)(color.G * newIntensity / intensity);
                        B = (byte)(color.B * newIntensity / intensity);
                    }

                    resImage.SetPixel(x, y, Color.FromArgb(R, G, B));
                }

            return resImage;
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = GrayScale(image);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = Average(image);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        private void autoContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = AutoContrast(image);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        public Bitmap pBin(Bitmap sourceImage, int value)
        {
            Bitmap resImage = sourceImage;

            // Так как изображение исходное в оттенках серого, значит можно взять для сравнения любой канал.
            // В данном коде взят красный канал.

            int width = resImage.Width;
            int height = resImage.Height;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color color = resImage.GetPixel(x, y);
                    if (color.R >= value)
                    {
                        resImage.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        resImage.SetPixel(x, y, Color.Black);
                    }

                }

            return resImage;
        }

        private void точечнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte val = (byte)numericUpDown1.Value;
            Bitmap result = pBin(image, val);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
