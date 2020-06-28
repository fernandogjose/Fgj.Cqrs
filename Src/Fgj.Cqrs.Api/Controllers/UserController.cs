using Fgj.Cqrs.Application.Interfaces;
using Fgj.Cqrs.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] UserCreateRequestViewModel request)
        {
            ResponseViewModel response = await _userAppService.CreateAsync(request).ConfigureAwait(true);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put([FromBody] UserUpdateRequestViewModel request)
        {
            ResponseViewModel response = await _userAppService.UpdateAsync(request).ConfigureAwait(true);
            return Ok(response);
        }

        [HttpDelete("{guidUser}/{guidProfile}")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(string guidUser, string guidProfile)
        {
            ResponseViewModel response = await _userAppService.DeleteAsync(guidUser, guidProfile).ConfigureAwait(true);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            ResponseViewModel response = _userAppService.GetAll();
            return Ok(response);
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult GetByGuid(string guid)
        {
            ResponseViewModel response = _userAppService.GetByGuid(guid);
            return Ok(response);
        }
    }
}