namespace MedicalSystemApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } // Doctor, Admin, Nurse
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
