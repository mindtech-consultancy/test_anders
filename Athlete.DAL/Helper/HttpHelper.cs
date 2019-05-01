using Microsoft.AspNetCore.Http;

namespace Athlete.DAL.Helper
{
    public class HttpHelper
    {
        private static IHttpContextAccessor _accessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public static HttpContext HttpContext => _accessor.HttpContext;

        public static T GetSessionObject<T>(string Key) where T : new()
        {
            try
            {
                T objSession = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(SessionExtensions.GetString(HttpHelper.HttpContext.Session, Key));
                return objSession;
            }
            catch (System.Exception)
            {
                return new T();
            }
        }

        public static string GetSessionString(string Key)
        {
            string strSession = string.Empty;
            try
            {
                strSession = SessionExtensions.GetString(HttpHelper.HttpContext.Session, Key);
            }
            catch (System.Exception)
            {
            }
            return strSession;
        }
    }
}
