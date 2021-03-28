using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var (newPath, path2) = NewPath(file);
            File.Move(sourcepath, newPath);
            return path2;
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var (newPath, path2) = NewPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return path2;
        }

        public static (string newPath, string Path2) NewPath(IFormFile file)
        {
            var ff = new FileInfo(file.FileName);
            var fileExtension = ff.Extension;
            var path = Environment.CurrentDirectory + @"\wwwroot\Images\CarImages";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + "_"
            + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + DateTime.Now.Millisecond + fileExtension;
            var result = $@"{path}\{newPath}";
            return (result, $"\\Images\\CarImages\\{newPath}");
        }
    }
}