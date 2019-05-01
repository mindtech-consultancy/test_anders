using Athlete.DAL.Model;

namespace Athlete.DAL.ViewModel
{
    public class TestListViewModel : AthleteTestMasterModel
    {
        public string TestType { get; set; }
        public int NumOfAttendee { get; set; }
    }
}
