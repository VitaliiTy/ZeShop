using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ZeShop.Controllers
{
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
    }
}
