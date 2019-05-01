using Athlete.DAL.AthleteContext;
using Athlete.ML.Model;
using Athlete.ML.Utility;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Athlete.BL
{
    public class AuthenticationBL
    {
        private readonly AthleteServerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationBL(AthleteServerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public bool AuthenticateUser(string userName, string password)
        {
            TblUserMaster objUserMaster = _context.TblUserMaster.Where(a => a.UserName == userName && a.Password == password).FirstOrDefault();
            if (objUserMaster != null)
            {
                SessionExtensions.SetString(_httpContextAccessor.HttpContext.Session, Constants.SessionUserSessions, JsonConvert.SerializeObject(objUserMaster));
                SessionExtensions.SetString(_httpContextAccessor.HttpContext.Session, Constants.SessionUserId, Convert.ToString(objUserMaster.Id));
                return true;
            }
            else
                return false;
        }
    }
}
