using Athlete.BL;
using Athlete.DAL.AthleteContext;
using Athlete.ML.Model;
using Athlete.ML.Services;
using Athlete.ML.Utility;
using Athlete.ML.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics;

namespace AthleteTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly AthleteServerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(AthleteServerContext context, IOptions<ConnectionStringsModel> app, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            ApplicationSettings.ConnectionString = app.Value.AthleteContextDatabase;
            ApplicationSettings.AppBaseUrl = httpContextAccessor.HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host + "/";
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            AthleteTestBL objAthleteTest = new AthleteTestBL(_context, _httpContextAccessor);
            List<TestListViewModel> lstTests = objAthleteTest.GetAllAthleteTest();
            return View(lstTests);
        }

        public PartialViewResult _AddEditTest(long Id)
        {
            AthleteTestBL objAthleteTest = new AthleteTestBL(_context, _httpContextAccessor);
            TblAthleteTestMaster objTest = objAthleteTest.GetTestDetails(Id);


            AthleteTestTypesBL objTestType = new AthleteTestTypesBL(_context, _httpContextAccessor);
            List<TblTestType> lstTestTypess = objTestType.GetAllAthleteTestType();
            if (objTest != null)
            {
                ViewBag.lstTestType = new SelectList(lstTestTypess, "Id", "TestType", objTest.TestTypeId);
            }
            else
            {
                objTest = new TblAthleteTestMaster();
                ViewBag.lstTestType = new SelectList(lstTestTypess, "Id", "TestType");
            }
            return PartialView(objTest);
        }


        public JsonResult SaveTest(TblAthleteTestMaster objTest)
        {
            AthleteTestBL objAthleteTest = new AthleteTestBL(_context, _httpContextAccessor);
            bool Status = objAthleteTest.SaveTestDetials(objTest);
            return Json(Status);
        }

        public JsonResult DeleteTestDetails(long Id)
        {
            AthleteTestBL objAthleteTest = new AthleteTestBL(_context, _httpContextAccessor);
            bool Status = objAthleteTest.DeleteTestDetails(Id);
            return Json(Status);
        }


        public IActionResult TestAttendees(long Id)
        {
            TestAttendeesBL objAttendees = new TestAttendeesBL(_context, _httpContextAccessor);
            List<TestAttendeeViewModel> lstAttendees = objAttendees.GetAllTestAttendee(Id);
            ViewBag.TestId = Id;
            return View(lstAttendees);
        }

        public PartialViewResult _AddEditAttendee(long Id)
        {
            TestAttendeesBL objAttendees = new TestAttendeesBL(_context, _httpContextAccessor);
            TblAthleteTestAttendees objAttendee = objAttendees.GetAttendeeDetails(Id);

            List<TblUserMaster> lstUsers = objAttendees.GetAllUsers();
            ViewBag.lstUsers = new SelectList(lstUsers, "Id", "UserName", objAttendee.UserId);
            return PartialView(objAttendee);
        }

        public JsonResult SaveAttendeeForTest(TblAthleteTestAttendees objAttendee)
        {
            TestAttendeesBL objAttendeeBL = new TestAttendeesBL(_context, _httpContextAccessor);
            bool Status = objAttendeeBL.SaveAttendeeDetrails(objAttendee);
            return Json(Status);
        }

        public JsonResult DeleteAttendeeDetails(long Id)
        {
            TestAttendeesBL objAttendeeBL = new TestAttendeesBL(_context, _httpContextAccessor);
            bool Status = objAttendeeBL.DeleteAttendeeDetails(Id);
            return Json(Status);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
