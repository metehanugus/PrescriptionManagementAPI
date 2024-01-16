namespace PrescriptionManagementAPI.Models
{
    public class Pharmacy
    {
        public int PharmacyID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();  // Store as a hash for security

        // Navigation properties
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
