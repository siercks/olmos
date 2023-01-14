using OlmosBartending.com.Models;

namespace OlmosBartending.com.Services
{
    public class DBcrud:ICRUD
    {
        private AppointmentContext _apptContext;
        public DBcrud(AppointmentContext apptContext)
        {
            _apptContext = apptContext;
        }
        public Appointment GetAppointment(int id)
        {
            return _apptContext.AppointmentList.Find(id);
        }

        public List<Appointment> GetAppointmentList()
        {
            return new List<Appointment>(_apptContext.AppointmentList);
        }

        public int GetMaxId()
        {
            return _apptContext.AppointmentList.Max(x => x.EventId) + 1;
        }
        public void UpdateAppointment()
        {

        }
    }
}
