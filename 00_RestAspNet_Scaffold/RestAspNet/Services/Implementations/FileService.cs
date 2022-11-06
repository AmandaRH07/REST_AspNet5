using Microsoft.AspNetCore.Http;
using RestAspNet.Services.Implementations.Interfaces;
using RestAspNet.Uploads.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RestAspNet.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileService(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "\\Uploads\\";
        }

        public byte[] GetFile(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailVO fileDetail = new FileDetailVO();

            try
            {
                var fileType = Path.GetExtension(file.FileName);
                var baseUrl = _context.HttpContext.Request.Host;
                if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpg")
                {
                    var docName = Path.GetFileName(file.FileName);
                    if (file != null && file.Length > 0)
                    {
                        var destination = Path.Combine(_basePath, "", docName);
                        fileDetail.DocName = docName;
                        fileDetail.DocType = fileType;
                        fileDetail.DocUrl = Path.Combine(baseUrl + "/api/file/v1/" + fileDetail.DocName);

                        using var stream = new FileStream(destination, FileMode.Create);
                        await file.CopyToAsync(stream);
                    }
                }
                else
                {
                    fileDetail.DocName = "Upload failed! Make sure that you're inserting an acceptable archive type (PDF, JPG, PNG, JPG).";
                }
            }
            catch (Exception)
            {
                fileDetail.DocName = "Upload failed! Make sure that you insert an archive.";
            }

            return fileDetail;
        }

        public Task<List<FileDetailVO>> SaveFileToDisk(List<IFormFile> file)
        {
            throw new System.NotImplementedException();
        }
    }
}
