using Athlete.BL;
using Athlete.DAL.AthleteContext;
using Athlete.ML.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AthleteTest.Controllers
{
    public class LoginController : Controller
    {
        private readonly AthleteServerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(AthleteServerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            ApplicationSettings.AppBaseUrl = httpContextAccessor.HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host + "/";
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Authentications(string UserName, string Password)
        {
            AuthenticationBL obj = new AuthenticationBL(_context, _httpContextAccessor);
            bool result = obj.AuthenticateUser(UserName, Password);
            return Json(result);
        }
    }
}