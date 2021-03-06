﻿using Athlete.DAL.AthleteContext;
using Athlete.DAL.Model;
using Athlete.DAL.Utility;
using Athlete.DAL.ViewModel;
using Athlete.DAL.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Athlete.BL
{
    public class TestAttendeesBL
    {
        private readonly AthleteServerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TestAttendeesBL(AthleteServerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<TestAttendeeViewModel> GetAllTestAttendee(long Id)
        {
            List<TestAttendeeViewModel> lstAttendees = new List<TestAttendeeViewModel>();
            using (SqlConnection con = new SqlConnection(ApplicationSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllAttendeesforTest", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("TestId", Id);
                    con.Open();
                    using (IDataReader idr = cmd.ExecuteReader())
                    {
                        while (idr.Read())
                        {
                            TestAttendeeViewModel objTests = new TestAttendeeViewModel();
                            objTests.Id = Convert.ToInt32(idr["Id"]);
                            objTests.UserName = Convert.ToString(idr["UserName"]);
                            objTests.TestAttributeValue = Convert.ToString(idr["TestAttributeValue"]);
                            objTests.FitenessRating = Convert.ToString(idr["FitenessRating"]);

                            lstAttendees.Add(objTests);
                        }
                    }

                    con.Close();
                }
            }
            return lstAttendees;
        }

        public bool SaveAttendeeDetrails(AthleteTestAttendeesModel objAttendee)
        {
            if (objAttendee.Id > 0)
            {
                AthleteTestAttendeesModel obj = _context.TblAthleteTestAttendees.Find(objAttendee.Id);
                obj.UserId = objAttendee.UserId;
                obj.TestAttributeValue = objAttendee.TestAttributeValue;
                obj.UpdatedBy = Convert.ToInt64(HttpHelper.GetSessionString(Constants.SessionUserId));
                obj.UpdatedDate = DateTime.Now;
                _context.TblAthleteTestAttendees.Update(obj);
                _context.SaveChanges();
            }
            else
            {
                objAttendee.CreatedBy = Convert.ToInt64(HttpHelper.GetSessionString(Constants.SessionUserId));
                _context.TblAthleteTestAttendees.Add(objAttendee);
                _context.SaveChanges();
            }
            return true;
        }

        public List<UserMasterModel> GetAllUsers()
        {
            return _context.TblUserMaster.Where(a => a.UserTypeId == 3).ToList();
        }

        public AthleteTestAttendeesModel GetAttendeeDetails(long id)
        {
            AthleteTestAttendeesModel objAttendee = new AthleteTestAttendeesModel();
            if (_context.TblAthleteTestAttendees.Find(id) != null)
            {
                objAttendee = _context.TblAthleteTestAttendees.Find(id);
            }
            return objAttendee;
        }

        public bool DeleteAttendeeDetails(long id)
        {
            AthleteTestAttendeesModel objAttendee = new AthleteTestAttendeesModel();
            objAttendee = _context.TblAthleteTestAttendees.Find(id);
            _context.TblAthleteTestAttendees.Remove(objAttendee);
            _context.SaveChanges();
            return true;
        }
    }
}
