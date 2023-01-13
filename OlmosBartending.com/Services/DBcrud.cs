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
            throw new NotImplementedException();
        }

        public List<Appointment> GetAppointmentList()
        {
            return new List<Appointment>(_apptContext.AppointmentList);
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }
    }
}
