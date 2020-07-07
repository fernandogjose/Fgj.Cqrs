using Fgj.Cqrs.Application.Blog.Interfaces;
using Fgj.Cqrs.Application.Blog.ViewModels;
using Fgj.Cqrs.Application.Share.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Api.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogAppService _blogAppService;

        public BlogController(IBlogAppService blogAppService)
        {
            _blogAppService = blogAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody]BlogCreateRequestViewModel request)
        {
            ResponseViewModel response = await _blogAppService.CreateAsync(request).ConfigureAwait(true);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            ResponseViewModel response = await _blogAppService.GetAllAsync().ConfigureAwait(true);
            return Ok(response);
        }
    }
}