using OlmosBartending.com.Models;

namespace OlmosBartending.com.Services
{
    public class DBcrud:ICRUD
    {
        private AppointmentContext _apptContext;
        //private List<Appointment> apptList;
        public DBcrud(AppointmentContext apptContext)
        {
            _apptContext = apptContext;
            //apptList= new List<Appointment>();
        }
        public void AddAppointment(Appointment appointment)
        {
            _apptContext.AppointmentList.Add(appointment);
            _apptContext.SaveChanges();
        }
        public void DeleteAppointment(int? id)
        {
            var apptToDelete = _apptContext.AppointmentList.Find(id);
            if(apptToDelete !=null)
            {
                _apptContext.AppointmentList.Remove(apptToDelete);
            }
        }
        public Appointment GetAppointment(int? id)
        {
            if(id==null)
            {
                return null;
            }
            else
            {
                return _apptContext.AppointmentList.Find(id);
            }
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
        //int ICRUD.GetMaxId()
        //{
        //    int maxId = apptList.Max(x => x.EventId);
        //    return maxId + 1 ;
        //}
    }
}
