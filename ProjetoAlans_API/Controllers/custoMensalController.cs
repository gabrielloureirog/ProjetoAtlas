using Microsoft.AspNetCore.Mvc;

namespace ProjetoAlans_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustoMensalController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAction() {
            return Ok("Custo Mensal");
        }
    }
}