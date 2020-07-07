using Fgj.Cqrs.Application.Interfaces;
using Fgj.Cqrs.Application.Share.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Fgj.Cqrs.Api.Controllers
{
    [Route("api/type")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeAppService _typeAppService;

        public TypeController(ITypeAppService typeAppService)
        {
            _typeAppService = typeAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            ResponseViewModel response = _typeAppService.GetAll();
            return Ok(response);
        }
    }
}