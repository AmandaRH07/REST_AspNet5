using Microsoft.AspNetCore.Http;
using RestAspNet.Uploads.VO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace RestAspNet.Services.Implementations.Interfaces
{
    public interface IFileService
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveFileToDisk(List<IFormFile> file);
    }
}
