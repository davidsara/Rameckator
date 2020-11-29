using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace DavidSara.Rameckator
{
    internal static class ImageProcessor
    {
        const int MaxWidht = 800;
        const int MaxHeight = 600;

        const int Quality = 80;

        internal static string Resize(string imageFile, string outputPath)
        {
            try
            {
                using (var input = File.OpenRead(imageFile))
                {
                    using (var output = File.OpenWrite(outputPath + @"\" + Path.GetFileName(imageFile)))
                    {
                        using (var image = Image.Load(input))
                        {
                            image.Mutate(a => a.Resize(new ResizeOptions { Size = new Size(MaxWidht, MaxHeight), Mode = ResizeMode.Max }));
                            image.SaveAsJpeg(output, new JpegEncoder { Quality = Quality });
                        }
                    }
                }

                return string.Empty;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}