using MediatR;
using Microsoft.AspNetCore.Mvc;
using POne.Core.Contracts;
using POne.Core.Mvc;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using IOFile = System.IO.File;

namespace POne.Financial.Api.Controllers
{

    [Route("[controller]")]
    public class VideoController : BaseController
    {
        public VideoController(IMediator mediator, IUow uow) : base(mediator, uow)
        {
        }

        [HttpGet("{fileName}")]
        public async Task<FileStreamResult> GetAsync([FromRoute] string fileName, CancellationToken cancellationToken)
        {
            var filePath = Path.Combine("C:\\Users\\uilli\\Videos\\A Dance Of Fire And Ice", fileName);

            var fileBytes = await IOFile.ReadAllBytesAsync(filePath, cancellationToken);

            var memoryStream = new MemoryStream(fileBytes);

            return File(memoryStream, "video/mp4");
        }
    }
}
