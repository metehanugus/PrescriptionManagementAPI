namespace PrescriptionManagementAPI.Models
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public int PatientID { get; set; }
        public int PharmacyID { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation properties
        public Patient Patient { get; set; } = new Patient();
        public Pharmacy Pharmacy { get; set; } = new Pharmacy();
        public List<PrescriptionDetail> PrescriptionDetails { get; set; } = new List<PrescriptionDetail>();
    }
}
