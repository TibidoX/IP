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
        Bitmap prevImage;
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
                prevImage = new Bitmap(dialog.FileName);
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

        public int[] CalculateHistogram(Bitmap image)
        {
            int[] hist = new int[256];

            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    Color color = image.GetPixel(x, y);
                    hist[color.R]++;
                }
            return hist;
        }

        public Bitmap GlobalGist(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap resImage = new Bitmap(width, height);

            
            int[] hist = CalculateHistogram(sourceImage);

            
            int histSum = hist.Sum();
            int cut = (int)(histSum * 0.05);

            for (int i = 0; i < 255; i++)
            {
                if (hist[i] < cut)
                {
                    cut -= hist[i];
                    hist[i] = 0;
                }
                else
                {
                    hist[i] -= cut;
                }
                if (cut == 0) break;

            }

            cut = (int)(histSum * 0.05);

            for (int i = 255; i < 0; i--)
            {
                if (hist[i] < cut)
                {
                    cut -= hist[i];
                    hist[i] = 0;
                }
                else
                {
                    hist[i] -= cut;
                }
                if (cut == 0) break;

            }

            int t = 0;

            int weight = 0;
            for (int i = 0; i < 255; i++)
            {
                if (hist[i] == 0) continue;

                weight += hist[i] * i;
            }

            t = (int)(weight / hist.Sum());

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color color = sourceImage.GetPixel(x, y);
                    if (color.R >= t) resImage.SetPixel(x, y, Color.White);
                    else resImage.SetPixel(x, y, Color.Black);

                }
            return resImage;
        }

        private void глобальнаяпоГистограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = GlobalGist(image);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = Median(image);
            prevImage = image;
            image = result;
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        public Bitmap Median(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap resImage = new Bitmap(width, height);


            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    int ct = 0;
                    int radiusX = 1;
                    int radiusY = radiusX;

                    byte[] R = new byte[9];
                    byte[] G = new byte[9];
                    byte[] B = new byte[9];

                    int med = (int)(9f / 2f);

                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = clamp(x + k, 0, sourceImage.Width - 1);
                            int idY = clamp(y + l, 0, sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idX, idY);

                            R[ct] = neighborColor.R;
                            G[ct] = neighborColor.G;
                            B[ct] = neighborColor.B;
                            ct++;
                        }

                    Array.Sort(R);
                    Array.Sort(G);
                    Array.Sort(B);

                    byte resultR = R[med];
                    byte resultG = G[med];
                    byte resultB = B[med];

                    resImage.SetPixel(x,y,Color.FromArgb(resultR, resultG, resultB));
                }
            return resImage;
        }


        public Bitmap Gauss(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap resImage = new Bitmap(width, height);


            float[,] kernel = null;


            int radius = 3;
            int sigma = 2;

            int size = 2 * radius + 1;
            kernel = new float[size, size];
            float norm = 0;
            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;



            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    int radiusX = kernel.GetLength(0) / 2;
                    int radiusY = kernel.GetLength(1) / 2;
                    float resultR = 0, resultG = 0, resultB = 0;

                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = clamp(x + k, 0, sourceImage.Width - 1);
                            int idY = clamp(y + l, 0, sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idX, idY);
                            resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                            resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                            resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                        }
                     resImage.SetPixel(x,y,Color.FromArgb(clamp((int)resultR, 0, 255),
                                          clamp((int)resultG, 0, 255),
                                          clamp((int)resultB, 0, 255)));
                }
            return resImage;
        }

        private void гауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = Gauss(image);
            prevImage = image;
            image = result;
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        private static byte GetBrightness(Color color)
        {
            return (byte)(.299 * color.R + .587 * color.G + .114 * color.B);
        }


        private static float ComputeMean(Bitmap image)
        {
            float sum = 0f;
            for (int i = 0; i < image.Height; i++)
                for (int j = 0; j < image.Width; j++)
                {
                    Color color = image.GetPixel(j, i);
                    sum += (float)GetBrightness(color);
                }
            return sum / (image.Width * image.Height);
        }

        private static float ComputeVariance(Bitmap image, float mean)
        {
            float sum = 0f;
            for (int i = 0; i < image.Height; i++)
                for (int j = 0; j < image.Width; j++)
                {
                    Color color = image.GetPixel(j, i);
                    sum += (float)Math.Pow((GetBrightness(color) - mean), 2);
                }
            return (float)Math.Sqrt(sum / ((image.Width * image.Height - 1)));
        }

        private static float ComputeCovariance(Bitmap image1, Bitmap image2, float var1, float var2)
        {
            float sum = 0f;
            for (int i = 0; i < image1.Height; i++)
                for (int j = 0; j < image1.Width; j++)
                {
                    Color color1 = image1.GetPixel(j, i);
                    Color color2 = image2.GetPixel(j, i);
                    sum += (GetBrightness(color1) - var1) * (GetBrightness(color2) - var2);
                }
            return sum / ((image1.Width * image1.Height - 1));
        }

        public float PSNR(Bitmap compareImage, Bitmap perfImage)
        {
            if (compareImage.Size != perfImage.Size) return -1;

            float sum = 0f;
            for (int i = 0; i < perfImage.Height; i++)
                for (int j = 0; j < perfImage.Width; j++)
                {
                    Color perfColor = perfImage.GetPixel(j, i);
                    Color compareColor = compareImage.GetPixel(j, i);
                    sum += (float)Math.Pow(GetBrightness(compareColor) - GetBrightness(perfColor), 2);
                }
            float mse = sum / (compareImage.Width * compareImage.Height);
            float psnr = (float)(20 * Math.Log10(255f / Math.Sqrt(mse)));
            return psnr;
        }

        static protected Tuple<int, int> GetNextRandPixel(int width, int height)
        {
            Random random = new Random();
            int x = random.Next(width);
            int y = random.Next(height);
            return new Tuple<int, int>(x, y);
        }

        public float SSIM(Bitmap compareImage, Bitmap perfImage)
        {
            const int L = 8;
            const float k1 = 0.01f;
            const float k2 = 0.03f;

            float c1 = (float)Math.Pow(L * k1, 2);
            float c2 = (float)Math.Pow(L * k2, 2);

            float comM = ComputeMean(compareImage);
            float perfM = ComputeMean(perfImage);

            float comVar = ComputeVariance(compareImage, comM);
            float perfVar = ComputeVariance(perfImage, perfM);

            float covar = ComputeCovariance(compareImage, perfImage, comM, perfM);

            float up = (2 * comM * perfM + c1) * (2 * covar + c2);
            float down = (comM * comM + perfM * perfM + c1) *
                    (comVar * comVar + perfVar * perfVar + c2);

            float ssim =  up / down;

            return ssim;
        }

        public float[] Uniform(int size)
        {
            double a = 32;
            double b = 64;

            var uniform = new float[256];
            float sum = 0f;

            for (int i = 0; i < 256; i++)
            {
                float step = i;
                if (step >= a && step <= b)
                {
                    uniform[i] = (1 / (float)(b - a));
                }
                else
                {
                    uniform[i] = 0;
                }
                sum += uniform[i];
            }

            for (int i = 0; i < 256; i++)
            {
                uniform[i] /= sum;
                uniform[i] *= size;
                uniform[i] = (int)Math.Floor(uniform[i]);
            }


            return uniform;
        }

        public float[] Rayleigh(int size)
        {
            double a = 0;
            double b = 0.4;

            var rayleigh = new float[256];
            float sum = 0f;

            for (int i = 0; i < 256; i++)
            {
                double step = (float)i * 0.01;
                if (step >= a)
                {
                    rayleigh[i] = (float)((2 / b) * (step - a) * Math.Exp(-Math.Pow(step - a, 2) / b));
                }
                else
                {
                    rayleigh[i] = 0;
                }
                sum += rayleigh[i];
            }

            for (int i = 0; i < 256; i++)
            {
                rayleigh[i] /= sum;
                rayleigh[i] *= size;
                rayleigh[i] = (int)Math.Floor(rayleigh[i]);
            }

            return rayleigh;
        }

        public Bitmap Maximum(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap resImage = new Bitmap(width, height);


            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    //Color Color = CalculateNewPixelColor(sourceImage, x, y);
                    //resImage.SetPixel(x, y, Color);
                    int radius = 1; // радиус матрицы
                    int matrixSize = (1 + 2 * radius) * (1 + 2 * radius);

                    byte max = 0;


                    for (int l = -radius; l <= radius; l++)
                        for (int k = -radius; k <= radius; k++)
                        {
                            int idX = clamp(x + k, 0, sourceImage.Width - 1);
                            int idY = clamp(y + l, 0, sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idX, idY);

                            if (GetBrightness(neighborColor) > max) max = GetBrightness(neighborColor);
                        }

                    resImage.SetPixel(x,y, Color.FromArgb(max, max, max));
                }
            return resImage;
        }

        private void pSNRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MessageBox.Show(PSNR(image, prevImage).ToString());
            Cursor.Current = Cursors.Default;
        }

        private void sSIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MessageBox.Show(SSIM(image, prevImage).ToString());
            Cursor.Current = Cursors.Default;
        }

        private void uniformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = CalculateBitmap(image, Uniform(image.Width * image.Height));
            prevImage = image;
            image = result;
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        public Bitmap ArMean(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap resImage = new Bitmap(width, height);


            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    int radius = 1; // радиус матрицы
                    int matrixSize = (1 + 2 * radius) * (1 + 2 * radius);

                    int intesitySum = 0; // сумма яркостей


                    for (int l = -radius; l <= radius; l++)
                        for (int k = -radius; k <= radius; k++)
                        {
                            int idX = clamp(x + k, 0, sourceImage.Width - 1);
                            int idY = clamp(y + l, 0, sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idX, idY);

                            intesitySum += GetBrightness(neighborColor);
                        }

                    Color Color = Color.FromArgb(intesitySum / matrixSize, intesitySum / matrixSize, intesitySum / matrixSize);
                    resImage.SetPixel(x, y, Color);

                }
            return resImage;
        }

        public Bitmap GeoMean(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap resImage = new Bitmap(width, height);


            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    int radius = 1; // радиус матрицы
                    int matrixSize = (1 + 2 * radius) * (1 + 2 * radius);

                    float intesityMult = 1f; // сумма яркостей


                    for (int l = -radius; l <= radius; l++)
                        for (int k = -radius; k <= radius; k++)
                        {
                            int idX = clamp(x + k, 0, sourceImage.Width - 1);
                            int idY = clamp(y + l, 0, sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idX, idY);

                            intesityMult *= GetBrightness(neighborColor);
                        }

                    var res = (byte)Math.Pow(intesityMult, 1 / (float)matrixSize);

                    Color Color = Color.FromArgb(res, res, res);

                    resImage.SetPixel(x, y, Color);

                }
            return resImage;
        }

        public Bitmap CalculateBitmap(Bitmap sourceImage, float[] uniform)
        {
            int size = sourceImage.Width * sourceImage.Height;

            var noise = ComputeNoise(uniform, size);

            var resImage = new Bitmap(sourceImage);

            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color color = sourceImage.GetPixel(x, y);
                    var newValue = clamp(GetBrightness(color) +
                        noise[sourceImage.Width * y + x], 0, 255);


                    resImage.SetPixel(x, y, Color.FromArgb(newValue, newValue, newValue));

                }
            return resImage;
        }

        protected byte[] ComputeNoise(float[] uniform, int size)
        {
            Random random = new Random();
            int count = 0;
            var noise = new byte[size];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < (int)uniform[i]; j++)
                {
                    noise[j + count] = (byte)i;
                }
                count += (int)uniform[i];
            }

            for (int i = 0; i < size - count; i++)
            {
                noise[count + i] = 0;
            }

            noise = noise.OrderBy(x => random.Next()).ToArray();
            return noise;
        }

        private void арифметическоеСреднееToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = ArMean(image);
            prevImage = image;
            image = result;
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        private void геометрическоеСреднееToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = GeoMean(image);
            prevImage = image;
            image = result;
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        private void райлиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = CalculateBitmap(image, Rayleigh(image.Width * image.Height));
            prevImage = image;
            image = result;
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        private void максимумаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = Maximum(image);
            prevImage = image;
            image = result;
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }
    }
}
