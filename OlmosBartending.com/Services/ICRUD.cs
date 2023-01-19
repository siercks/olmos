using OlmosBartending.com.Models;

namespace OlmosBartending.com.Services
{
    public interface ICRUD
    {
        List<Appointment> GetAppointmentList();
        Appointment GetAppointment(int id);
        void AddAppointment(Appointment appointment) 
        {
            //
        }
        void DeleteAppointment(int? id)
        {

        }
        void UpdateAppointment(Appointment appointment)
        {
            //
        }
        int GetMaxId();
        
    } 
}

