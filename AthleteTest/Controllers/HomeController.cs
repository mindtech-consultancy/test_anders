using Athlete.BL;
using Athlete.DAL.AthleteContext;
using Athlete.DAL.Helper;
using Athlete.DAL.Model;
using Athlete.DAL.Utility;
using Athlete.DAL.ViewModel;
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
        #region Constaructor and Private Properties

        private readonly AthleteServerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(AthleteServerContext context, IOptions<ConnectionStringsHelper> app, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            ApplicationSettings.ConnectionString = app.Value.AthleteContextDatabase;
            ApplicationSettings.AppBaseUrl = httpContextAccessor.HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host + "/";
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Athlete Tests Methods

        public IActionResult Index()
        {
            AthleteTestBL objAthleteTest = new AthleteTestBL(_context, _httpContextAccessor);
            List<TestListViewModel> lstTests = objAthleteTest.GetAllAthleteTest();
            return View(lstTests);
        }

        public PartialViewResult _AddEditTest(long Id)
        {
            AthleteTestBL athleteTestBL = new AthleteTestBL(_context, _httpContextAccessor);
            AthleteTestMasterModel athleteTestMasterModel = athleteTestBL.GetTestDetails(Id);


            AthleteTestTypesBL objTestType = new AthleteTestTypesBL(_context, _httpContextAccessor);
            List<TestTypeModel> lstTestTypess = objTestType.GetAllAthleteTestType();
            if (athleteTestMasterModel != null)
            {
                ViewBag.lstTestType = new SelectList(lstTestTypess, "Id", "TestType", athleteTestMasterModel.TestTypeId);
            }
            else
            {
                athleteTestMasterModel = new AthleteTestMasterModel();
                ViewBag.lstTestType = new SelectList(lstTestTypess, "Id", "TestType");
            }
            return PartialView(athleteTestMasterModel);
        }

        public JsonResult SaveTest(AthleteTestMasterModel objTest)
        {
            AthleteTestBL athleteTestBL = new AthleteTestBL(_context, _httpContextAccessor);
            bool Status = athleteTestBL.SaveTestDetials(objTest);
            return Json(Status);
        }

        public JsonResult DeleteTestDetails(long Id)
        {
            AthleteTestBL objAthleteTest = new AthleteTestBL(_context, _httpContextAccessor);
            bool Status = objAthleteTest.DeleteTestDetails(Id);
            return Json(Status);
        }

        #endregion

        #region Athlete Tests Attendees Related Methods

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
            AthleteTestAttendeesModel objAttendee = objAttendees.GetAttendeeDetails(Id);

            List<UserMasterModel> lstUsers = objAttendees.GetAllUsers();
            ViewBag.lstUsers = new SelectList(lstUsers, "Id", "UserName", objAttendee.UserId);
            return PartialView(objAttendee);
        }

        public JsonResult SaveAttendeeForTest(AthleteTestAttendeesModel tblAthleteTestAttendees)
        {
            TestAttendeesBL objAttendeeBL = new TestAttendeesBL(_context, _httpContextAccessor);
            bool Status = objAttendeeBL.SaveAttendeeDetrails(tblAthleteTestAttendees);
            return Json(Status);
        }

        public JsonResult DeleteAttendeeDetails(long Id)
        {
            TestAttendeesBL objAttendeeBL = new TestAttendeesBL(_context, _httpContextAccessor);
            bool Status = objAttendeeBL.DeleteAttendeeDetails(Id);
            return Json(Status);
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
