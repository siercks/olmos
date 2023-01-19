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
        public void AddAppointment(Appointment appointment)
        {
            //if (appointment.ServiceRequested.ToString() == "Birthday") { appointment.ServiceRequested = 1; }
            //if (appointment.ServiceRequested.ToString() == "") { appointment.ServiceRequested = 2; }
            //if (appointment.ServiceRequested.ToString() == "") { appointment.ServiceRequested = 3; }
            //if (appointment.ServiceRequested.ToString() == "") { appointment.ServiceRequested = 4; }
            //if (appointment.ServiceRequested.ToString() == "") { appointment.ServiceRequested = 5; }
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
        public void UpdateAppointment(Appointment appointment)
        {
            var apptToUpdate = _apptContext.AppointmentList.Find(appointment.EventId);
            if (apptToUpdate != null)
            {
                apptToUpdate.EventId = appointment.EventId;
                apptToUpdate.CustomerName = appointment.CustomerName;
                apptToUpdate.CustomerEmail = appointment.CustomerEmail;
                apptToUpdate.DateRequested = appointment.DateRequested;
                apptToUpdate.ServiceRequested= appointment.ServiceRequested;
                apptToUpdate.OptionalMessage = appointment.OptionalMessage;
                _apptContext.SaveChanges();
            }
        }
    }
}
