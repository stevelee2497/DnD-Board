using DnD_Board.Common.Exceptions;
using DnD_Board.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DnD_Board.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    [Produces("application/json")]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<SuccessResponse<string>> Upload(IFormFile file)
        {
            if (file.Length <= 0)
            {
                throw new BadRequestException("The uploading file has no data");
            }

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}");
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return new SuccessResponse<string>($"/{Path.GetFileName(filePath)}");

        }
   
        [HttpGet("{fileName}")]
        public async Task<IActionResult> Download(string fileName)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, fileName);
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(filePath));
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }

    }
}