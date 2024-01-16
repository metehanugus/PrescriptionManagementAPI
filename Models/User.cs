namespace PrescriptionManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; } // Primary key
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
    }

}
