using Athlete.DAL.AthleteContext;
using Athlete.DAL.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Athlete.BL
{
    public class AthleteTestTypesBL
    {
        private readonly AthleteServerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AthleteTestTypesBL(AthleteServerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<TestTypeModel> GetAllAthleteTestType()
        {
            //List<TblTestType> lstTestTypes = new List<TblTestType>();
            return _context.TblTestType.Where(a => a.IsActive).ToList();
            // return lstTestTypes;
        }


    }
}
