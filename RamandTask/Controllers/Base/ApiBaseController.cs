using Microsoft.AspNetCore.Mvc;

namespace RamandTask.Controllers.Base
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiBaseController : ControllerBase
    {
        
    }
}
