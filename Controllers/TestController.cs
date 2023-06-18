using EmptyTemplateWebApiJwtAuthPsql.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace EmptyTemplateWebApiJwtAuthPsql.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TestController : Controller
{
    private readonly ITestRepository _testRepository;
    private readonly Logger _log = LogManager.GetLogger("ActionLog");
    
    public TestController(ITestRepository testRepository)
    {
        _log.Info("TestController Create");
        _testRepository = testRepository;
    }
    [AllowAnonymous]
        [HttpGet]
        public ActionResult TestApi()
        {
            _log.Info("TestApi Start");
            return Json("Api is work");
        }
        
        [HttpGet("auth")]
        public ActionResult AuthTest()
        {
            _log.Info("AuthTest Start");
            var userName = HttpContext.User.Identity?.Name;
            return Json($"User authorise Name:{userName}");
        }
        
        [AllowAnonymous]
        [HttpGet("db")]
        public async Task<ActionResult> DbTest()
        {
            _log.Info("DbTest Start");
            var testData = await _testRepository.TestRequestAsync();
            return Json(testData);
        }
}