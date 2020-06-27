using Fgj.Cqrs.Application.Interfaces;
using Fgj.Cqrs.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Fgj.Cqrs.Api.Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestResponseAppService _requestResponseAppService;
        private string Request;
        private string Response;
        private string EndPoint;

        public RequestResponseMiddleware(RequestDelegate next, IRequestResponseAppService requestResponseAppService)
        {
            _next = next;
            _requestResponseAppService = requestResponseAppService;
        }

        private async Task ObterRequestAsync(HttpContext context)
        {
            var request = context.Request;
            request.EnableBuffering();

            using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                Request = await reader.ReadToEndAsync();
                EndPoint = request.Path.ToString();
                request.Body.Position = 0;
            }
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var method = context.Request.Method;

                // Obter o request
                await ObterRequestAsync(context).ConfigureAwait(true);
                var originalBodyStream = context.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    // Processando a requisição
                    await _next(context).ConfigureAwait(true);

                    // Verifica o status code do response
                    context.Response.StatusCode = await ObterStatusCode(context.Response).ConfigureAwait(true);

                    // Adiciona o Request e Response 
                    await RequestResponseAdicionar().ConfigureAwait(false);

                    // Response
                    await responseBody.CopyToAsync(originalBodyStream).ConfigureAwait(true);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private async Task<int> ObterStatusCode(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            Encoding utf8 = new UTF8Encoding(false);
            Response = await new StreamReader(response.Body, utf8).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            // Verificar se teve algum erro de negócio e volta StatusCode diferente de 200
            ResponseViewModel responseViewModel = JsonConvert.DeserializeObject<ResponseViewModel>(Response);
            if (responseViewModel?.Success == false)
            {
                response.StatusCode = response.StatusCode == 500 ? 500 : 400;
            }

            return response.StatusCode;
        }

        private async Task RequestResponseAdicionar()
        {
            try
            {
                RequestResponseAddRequestViewModel request = new RequestResponseAddRequestViewModel(DateTime.Now, Request, Response, EndPoint);
                await _requestResponseAppService.AddAsync(request).ConfigureAwait(false);
            }
            catch { }
        }
    }
}