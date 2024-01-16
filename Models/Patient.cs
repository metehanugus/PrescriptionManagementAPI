namespace PrescriptionManagementAPI.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string TCIDNumber { get; set; } = string.Empty;

        // Navigation properties
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
