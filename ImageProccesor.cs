using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Drawing.Drawing2D;

namespace IMGapp
{
    public class ImageProccesor
    {
        public Bitmap PixSum(Bitmap img1, Bitmap img2, int w, int h)
        {
            var out_img = new Bitmap(w, h);
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var pix1 = img1.GetPixel(j, i);
                    var pix2 = img2.GetPixel(j, i);

                    int r1 = pix1.R;
                    int g1 = pix1.G;
                    int b1 = pix1.B;

                    int r2 = pix2.R;
                    int g2 = pix2.G;
                    int b2 = pix2.B;

                    int r = (int)Program.Clamp(r1 + r2, 0, 255);
                    int g = (int)Program.Clamp(g1 + g2, 0, 255);
                    int b = (int)Program.Clamp(b1 + b2, 0, 255);

                    var pix = Color.FromArgb(r, g, b);
                    out_img.SetPixel(j, i, pix);
                }
            }
            return out_img;
        }

        public Bitmap PixProd(Bitmap img1, Bitmap img2, int w, int h)
        {
            var out_img = new Bitmap(w, h);
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var pix1 = img1.GetPixel(j, i);
                    var pix2 = img2.GetPixel(j, i);

                    int r1 = pix1.R;
                    int g1 = pix1.G;
                    int b1 = pix1.B;

                    int r2 = pix2.R;
                    int g2 = pix2.G;
                    int b2 = pix2.B;

                    int r = (int)Program.Clamp(r1 * r2 / 255, 0, 255);
                    int g = (int)Program.Clamp(g1 * g2 / 255, 0, 255);
                    int b = (int)Program.Clamp(b1 * b2 / 255, 0, 255);


                    var pix = Color.FromArgb(r, g, b);
                    out_img.SetPixel(j, i, pix);
                }
            }
            return out_img;

        }

        public Bitmap PixMean(Bitmap img1, Bitmap img2, int w, int h)
        {
            var out_img = new Bitmap(w, h);
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var pix1 = img1.GetPixel(j, i);
                    var pix2 = img2.GetPixel(j, i);

                    int r1 = pix1.R;
                    int g1 = pix1.G;
                    int b1 = pix1.B;

                    int r2 = pix2.R;
                    int g2 = pix2.G;
                    int b2 = pix2.B;

                    int r = (int)Program.Clamp((r1 + r2) / 2, 0, 255);
                    int g = (int)Program.Clamp((g1 + g2) / 2, 0, 255);
                    int b = (int)Program.Clamp((b1 + b2) / 2, 0, 255);


                    var pix = Color.FromArgb(r, g, b);
                    out_img.SetPixel(j, i, pix);
                }
            }
            return out_img;
        }

        public Bitmap PixMin(Bitmap img1, Bitmap img2, int w, int h)
        {
            var out_img = new Bitmap(w, h);
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var pix1 = img1.GetPixel(j, i);
                    var pix2 = img2.GetPixel(j, i);

                    int r1 = pix1.R;
                    int g1 = pix1.G;
                    int b1 = pix1.B;

                    int r2 = pix2.R;
                    int g2 = pix2.G;
                    int b2 = pix2.B;

                    int r = (int)Program.Clamp(Math.Min(r1, r2), 0, 255);
                    int g = (int)Program.Clamp(Math.Min(g1, g2), 0, 255);
                    int b = (int)Program.Clamp(Math.Min(b1, b2), 0, 255);


                    var pix = Color.FromArgb(r, g, b);
                    out_img.SetPixel(j, i, pix);
                }
            }
            return out_img;
        }

        public Bitmap PixMax(Bitmap img1, Bitmap img2, int w, int h)
        {
            var out_img = new Bitmap(w, h);
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var pix1 = img1.GetPixel(j, i);
                    var pix2 = img2.GetPixel(j, i);

                    int r1 = pix1.R;
                    int g1 = pix1.G;
                    int b1 = pix1.B;

                    int r2 = pix2.R;
                    int g2 = pix2.G;
                    int b2 = pix2.B;

                    int r = (int)Program.Clamp(Math.Max(r1, r2), 0, 255);
                    int g = (int)Program.Clamp(Math.Max(g1, g2), 0, 255);
                    int b = (int)Program.Clamp(Math.Max(b1, b2), 0, 255);


                    var pix = Color.FromArgb(r, g, b);
                    out_img.SetPixel(j, i, pix);
                }
            }
            return out_img;
        }

        public Bitmap PixMask(Bitmap img1, Bitmap img2, int w, int h)
        {
            var out_img = new Bitmap(w, h);
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    var pix1 = img1.GetPixel(j, i);
                    var pix2 = img2.GetPixel(j, i);

                    int r1 = pix1.R;
                    int g1 = pix1.G;
                    int b1 = pix1.B;

                    int r2 = pix2.R;
                    int g2 = pix2.G;
                    int b2 = pix2.B;

                    int r = (int)Program.Clamp(r1 * r2 / 255, 0, 255);
                    int g = (int)Program.Clamp(g1 * g2 / 255, 0, 255);
                    int b = (int)Program.Clamp(b1 * b2 / 255, 0, 255);


                    var pix = Color.FromArgb(r, g, b);
                    out_img.SetPixel(j, i, pix);
                }
            }
            return out_img;
        }

        public Bitmap GradProcess(Bitmap img)
        {
            int height = img.Height, width = img.Width;
            var out_img = new Bitmap(width, height);
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    out_img.SetPixel(j, i, func(img.GetPixel(j, i)));
                }
            }
            return out_img;
        }

        public Bitmap DrawGist(Bitmap img)
        {
            int[] hist = new int[256];
            var histImage = new Bitmap(256, 1024);
            int height = img.Height, width = img.Width;
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    var pixel = img.GetPixel(j, i);
                    var c = (pixel.R + pixel.G + pixel.B) / 3;
                    hist[c]++;
                }
            }

            var maxC = hist.Max();
            var k = (double)height / maxC;
            Console.WriteLine(maxC);
            Console.WriteLine(k);

            for (int i = 0; i < 256; i++)
            {
                int x1 = i, y1 = 1023;
                int x2 = i, y2 = (int)(1023 - hist[i] * k);
                Console.WriteLine(y2);

                using (var g = Graphics.FromImage(histImage))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    var pen = Pens.White.Clone() as Pen;
                    pen.Width = 5;
                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }

            return histImage;
        }

        private Color func(Color pixel)
        {
            var r = (int)Program.Clamp(255.0d * Math.Pow((double)pixel.R / 255.0, 2), 0, 255);
            var g = (int)Program.Clamp(255.0d * Math.Pow((double)pixel.G / 255.0, 2), 0, 255);
            var b = (int)Program.Clamp(255.0d * Math.Pow((double)pixel.B / 255.0, 2), 0, 255);
            var newPixel = Color.FromArgb(r, g, b);
            return newPixel;
        }
    }
}
