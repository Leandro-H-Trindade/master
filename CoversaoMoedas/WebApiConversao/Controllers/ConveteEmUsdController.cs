using PackageConversao.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApiConversao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConveteEmUsdController : ControllerBase
    {
        [HttpPost]
        public IActionResult ConverteEmReais([FromBody] Moeda moeda)
        {
            var response = new ConverterEmReais().Executa(moeda.Valor, moeda.Cotacao);

            return StatusCode(200, response);
        }
    }
}