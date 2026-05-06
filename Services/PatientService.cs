namespace MedicalSystemApp.Services
{
    using MedicalSystemApp.Models;

    public class PatientService
    {
        private static List<Patient> patients = new List<Patient>();

        public List<Patient> GetAllPatients()
        {
            return patients;
        }

        public Patient GetPatientById(int id)
        {
            return patients.FirstOrDefault(p => p.Id == id);
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }
    }
}
