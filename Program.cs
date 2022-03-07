using System;
using System.Diagnostics;
using System.IO;



/* для подключения System.Drawing в своем проекте правой в проекте нажать правой кнопкой по Ссылкам -> Добавить ссылку
    отметить галочкой сборку System.Drawing    */
using System.Drawing;
using System.Drawing.Drawing2D;


namespace IMGapp
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first image name: ");
            string first_input_filename = Console.ReadLine();
            Console.WriteLine("Enter second image name: ");
            string second_input_filename = Console.ReadLine();

            using (Bitmap img1 = new Bitmap($"..\\..\\{first_input_filename}"), img2 = new Bitmap($"..\\..\\{second_input_filename}"))
            {
                Console.WriteLine("Openning first image " + Directory.GetParent("..\\..\\") + $"\\{first_input_filename}");
                Console.WriteLine("Openning second image " + Directory.GetParent("..\\..\\") + $"\\{second_input_filename}");

                var w = img1.Width;
                var h = img1.Height;

                var imageProc = new ImageProccesor();
                Console.WriteLine("Choose image proccessing: ");
                Console.WriteLine("1.Pixel sum");
                Console.WriteLine("2.Pixel product");
                Console.WriteLine("3.Mean");
                Console.WriteLine("4.Min");
                Console.WriteLine("5.Max");
                Console.WriteLine("6.Mask");
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        using (var img_out = imageProc.PixSum(img1, img2, w, h))
                        {
                            Console.WriteLine("Enter output image name: ");
                            string output_image_name = Console.ReadLine();

                            img_out.Save($"..\\..\\{output_image_name}");

                            Console.WriteLine("Output image has been saved in " + Directory.GetParent("..\\..\\") + $"\\{output_image_name}");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        using (var img_out = imageProc.PixProd(img1, img2, w, h))
                        {
                            Console.WriteLine("Enter output image name: ");
                            string output_image_name = Console.ReadLine();

                            img_out.Save($"..\\..\\{output_image_name}");

                            Console.WriteLine("Output image has been saved in " + Directory.GetParent("..\\..\\") + $"\\{output_image_name}");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        using (var img_out = imageProc.PixMean(img1, img2, w, h))
                        {
                            Console.WriteLine("Enter output image name: ");
                            string output_image_name = Console.ReadLine();

                            img_out.Save($"..\\..\\{output_image_name}");

                            Console.WriteLine("Output image has been saved in " + Directory.GetParent("..\\..\\") + $"\\{output_image_name}");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        using (var img_out = imageProc.PixMin(img1, img2, w, h))
                        {
                            Console.WriteLine("Enter output image name: ");
                            string output_image_name = Console.ReadLine();

                            img_out.Save($"..\\..\\{output_image_name}");

                            Console.WriteLine("Output image has been saved in " + Directory.GetParent("..\\..\\") + $"\\{output_image_name}");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        using (var img_out = imageProc.PixMax(img1, img2, w, h))
                        {
                            Console.WriteLine("Enter output image name: ");
                            string output_image_name = Console.ReadLine();

                            img_out.Save($"..\\..\\{output_image_name}");

                            Console.WriteLine("Output image has been saved in " + Directory.GetParent("..\\..\\") + $"\\{output_image_name}");
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter mask type: ");
                        Console.WriteLine("1.Rectangle");
                        Console.WriteLine("2.Circle");
                        Console.WriteLine("3.Square");
                        int maskType = int.Parse(Console.ReadLine());

                        using (var mask = new Bitmap(w, h))
                        {
                            using(var g = Graphics.FromImage(mask))
                            {
                                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                g.SmoothingMode = SmoothingMode.HighQuality;
                                switch (maskType)
                                {
                                    case 1:
                                        g.FillRectangle(Brushes.White, (w - 300) / 2, (h - 200) / 2, 300, 200);
                                        break;
                                    case 2:
                                        g.FillEllipse(Brushes.White, (w - 200) / 2, (h - 200) / 2, 200, 200);
                                        break;
                                    case 3:
                                        g.FillRectangle(Brushes.White, (w - 200) / 2, (h - 200) / 2, 200, 200);
                                        break;
                                }
                               
                                using (var img_out = imageProc.PixMask(img1, mask, w, h))
                                {
                                    Console.WriteLine("Enter output image name: ");
                                    string output_image_name = Console.ReadLine();

                                    img_out.Save($"..\\..\\{output_image_name}");

                                    Console.WriteLine("Output image has been saved in " + Directory.GetParent("..\\..\\") + $"\\{output_image_name}");
                                    Console.ReadKey();
                                }
                                break;
                            }
                        }
                    default:
                        Console.WriteLine("Incorrect operation number");
                        Console.ReadKey();
                        break;
                }
            }
        }



        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
    }


}
