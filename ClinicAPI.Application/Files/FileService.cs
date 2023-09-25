using System;
using System.IO;
using ClinicAPI.Application.Base;

namespace ClinicAPI.Application.Files
{
	public static class FileService
	{
        public static void InsertFile(this FileModel file,int id, string folderName)
        {
            try
            {
                var bytes = Convert.FromBase64String(file.Data);
                var path = Directory.GetCurrentDirectory() + $"/wwwroot/{id}/{folderName}";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                File.WriteAllBytes(path + $"/{file.Name}", bytes);
            }
            catch (Exception ex)
            {
                throw new Exception("დაფიქსირდა შეცდომა ფაილის ატვირთვის დროს:" + ex.Message);
            }
        }
    }
}

