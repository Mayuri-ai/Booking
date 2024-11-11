using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repositories
{
    public class UtilityRepo : IUtilityRepo
    {
        private IWebHostEnvironment _env;
        private IHttpContextAccessor _contextAccessor;

        public UtilityRepo(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            _env = env;
            _contextAccessor = contextAccessor;
        }

        public Task DeleteImage(string ContainerName, string dbPath)
        {
            if(string.IsNullOrEmpty(dbPath))
            {
                return Task.CompletedTask;
            }
            var filename = Path.GetFileName(dbPath);
            var completePath = Path.Combine(_env.WebRootPath,ContainerName, filename);
            if(File.Exists(completePath))
            {
                File.Delete(completePath);
            }

            return Task.CompletedTask;
        }

       

        public async Task<string> EditImage(string ContainerName, IFormFile file, string dbPath)
        {
            await DeleteImage(ContainerName, dbPath);
            return await SaveImage(ContainerName, file);
        }

        // Guid.newguid() // yuir-ui987-jkiop-jiuop
        
        public async Task<string> SaveImage(string ContainerName, IFormFile file)
        {
            var extention = Path.GetExtension(file.FileName);
            var filename = $"{Guid.NewGuid()}{extention}";
            string folder = Path.Combine(_env.WebRootPath, ContainerName);
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Path.Combine(folder,filename);

            using(var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                await File.WriteAllBytesAsync(filePath, content);
            }

            var basePath = $"{_contextAccessor.HttpContext.Request.Scheme}://" +
                $"{_contextAccessor.HttpContext.Request.Host}";

            var completePath = Path.Combine(basePath, ContainerName, filename).Replace("\\", "/");
            return completePath;
        }
    }
}
