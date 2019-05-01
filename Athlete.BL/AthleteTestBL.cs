using Athlete.DAL.AthleteContext;
using Athlete.ML.Model;
using Athlete.ML.Services;
using Athlete.ML.Utility;
using Athlete.ML.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Athlete.BL
{
    public class AthleteTestBL
    {
        private readonly AthleteServerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AthleteTestBL(AthleteServerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<TestListViewModel> GetAllAthleteTest()
        {
            List<TestListViewModel> lstTests = new List<TestListViewModel>();
            //lstTests = _context.TblAthleteTestMaster.Where(a => a.IsActive).ToList();

            using (SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllAthleteTest", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (IDataReader idr = cmd.ExecuteReader())
                    {
                        while (idr.Read())
                        {
                            TestListViewModel objTests = new TestListViewModel();
                            objTests.Id = Convert.ToInt32(idr["Id"]);
                            objTests.TestTypeId = Convert.ToInt64(idr["TestTypeId"]);
                            objTests.TestDate = Convert.ToDateTime(idr["TestDate"]);
                            objTests.TestType = Convert.ToString(idr["TestType"]);
                            objTests.NumOfAttendee = idr["NumOfAttendee"] != null ? Convert.ToInt32(idr["NumOfAttendee"]) : 0;
                            lstTests.Add(objTests);
                        }
                    }

                    con.Close();
                }
            }


            return lstTests;
        }

        public bool SaveTestDetials(TblAthleteTestMaster tblAthleteTestMaster)
        {
            if (tblAthleteTestMaster.Id > 0)
            {
                TblAthleteTestMaster obj = _context.TblAthleteTestMaster.Find(tblAthleteTestMaster.Id);
                obj.TestTypeId = tblAthleteTestMaster.TestTypeId;
                obj.TestDate = tblAthleteTestMaster.TestDate;
                obj.UpdatedBy = Convert.ToInt64(HttpHelper.GetSessionString(Constants.SessionUserId));
                obj.UpdatedDate = DateTime.Now;
                _context.TblAthleteTestMaster.Update(obj);
                _context.SaveChanges();
            }
            else
            {
                tblAthleteTestMaster.CreatedBy = Convert.ToInt64(HttpHelper.GetSessionString(Constants.SessionUserId));
                _context.TblAthleteTestMaster.Add(tblAthleteTestMaster);
                _context.SaveChanges();
            }
            return true;
        }

        public bool DeleteTestDetails(long id)
        {
            TblAthleteTestMaster objTest = new TblAthleteTestMaster();
            objTest = _context.TblAthleteTestMaster.Find(id);
            _context.TblAthleteTestMaster.Remove(objTest);
            _context.SaveChanges();
            return true;
        }

        public TblAthleteTestMaster GetTestDetails(long id)
        {
            TblAthleteTestMaster objTest = new TblAthleteTestMaster();
            if (_context.TblAthleteTestMaster.Find(id) != null)
            {
                objTest = _context.TblAthleteTestMaster.Find(id);
            }
            return objTest;
        }
    }
}
