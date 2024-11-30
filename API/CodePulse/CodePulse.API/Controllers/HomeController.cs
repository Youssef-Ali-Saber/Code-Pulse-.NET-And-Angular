using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodePulse.API.Controllers;

public class HomeController : ControllerBase
{
    [SwaggerIgnore]
    [HttpGet("")]
    public ActionResult Index()
    {
        return Redirect("~/swagger");
    }
}