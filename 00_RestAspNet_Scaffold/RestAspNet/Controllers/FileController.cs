using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAspNet.Services.Implementations.Interfaces;
using RestAspNet.Uploads.VO;
using System.Threading.Tasks;

namespace RestAspNet.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("uploadFile")]
        [ProducesResponseType((200), Type = typeof(FileDetailVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/json")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            FileDetailVO detail = await _fileService.SaveFileToDisk(file);

            return new OkObjectResult(detail);
        }
    }
}
