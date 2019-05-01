using Athlete.DAL.AthleteContext;
using Athlete.ML.Model;
using Athlete.ML.Services;
using Athlete.ML.Utility;
using Microsoft.AspNetCore.Http;
using System;
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

        public List<TblTestType> GetAllAthleteTestType()
        {
            List<TblTestType> lstTestTypes = new List<TblTestType>();
            lstTestTypes = _context.TblTestType.Where(a => a.IsActive).ToList();
            return lstTestTypes;
        }

        
    }
}
