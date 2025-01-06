using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace qr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Download();
            //Crop();
        }

        static void Crop()
        {
            int size = 29;
            int border = 4;

            // rust moment
            var input_path = Path.Combine(Directory.GetCurrentDirectory(), "d");
            var output_path = Path.Combine(Directory.GetCurrentDirectory(), "o");

            if (!Directory.Exists(input_path))
            {
                Console.WriteLine("input dir not found!");
                return;
            }

            if (!Directory.Exists(output_path))
            {
                Directory.CreateDirectory(output_path);
                return;
            }

            for (int i = 1; i < 100; i++)
            {
                var inputFilename = Path.Combine(input_path, $"qr{i.ToString("00")}");
                if (!File.Exists(inputFilename))
                {
                    Console.WriteLine($"File not found - {inputFilename}");
                    continue;
                }
                Bitmap bitmap = new Bitmap(inputFilename);
                var bitmap2 = bitmap.Clone(new Rectangle(border, border, size - border * 2, size - border * 2), bitmap.PixelFormat);
                var outputFilename = Path.Combine(output_path, $"qr{i.ToString("00")}.png");
                bitmap2.Save(outputFilename, ImageFormat.Png);
                Console.WriteLine($"+ " + outputFilename);
            }
        }

        static void Download()
        {
            var output_path = Path.Combine(Directory.GetCurrentDirectory(), "d");

            if (!Directory.Exists(output_path))
                Directory.CreateDirectory(output_path);

            for (int i = 1; i < 100; i++)
            {
                using (WebClient client = new WebClient())
                {
                    var filename = Path.Combine(output_path, $"qr{i.ToString("00")}");
                    if (!File.Exists(filename))
                    {
                        client.DownloadFile($"http://qrcoder.ru/code/?8493{i.ToString("00")}&1&0", filename);
                        Console.WriteLine("+ " + filename);
                    }

                }
            }
        }
    }
}
