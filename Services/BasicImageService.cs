using CSharp___WebBlog.Services.Iterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp___WebBlog.Services
{
    public class BasicImageService : IImageService
    {
        public string ContentType(IFormFile image)
        {
            return image?.ContentType;
        }

        public string DecodeImage(byte[] data, string type)
        {
            if (data is null || type is null) return null;
            return $"data:image/{type};base64,{Convert.ToBase64String(data)}";
        }

        public async Task<byte[]> EncodeImageAsync(IFormFile image)
        {
            if (image is null) return null;

            using var ms = new MemoryStream();
            await image.CopyToAsync(ms);
            return ms.ToArray();
        }

        public async Task<byte[]> EncodeImageAsync(string imageFileName)
        {
            var imagePath = $"{Directory.GetCurrentDirectory()}//wwwroot.images/{imageFileName}";
            return await File.ReadAllBytesAsync(imagePath);
        }

        public int Size(IFormFile image)
        {
            return Convert.ToInt32(image?.Length);
        }
    }
    public class AdvancedImageService : IImageService
    {
        public string ContentType(IFormFile image)
        {
            throw new NotImplementedException();
        }

        public string DecodeImage(byte[] data, string type)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> EncodeImageAsync(IFormFile image)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> EncodeImageAsync(string image)
        {
            throw new NotImplementedException();
        }

        public int Size(IFormFile image)
        {
            throw new NotImplementedException();
        }
    }
}