namespace PrescriptionManagementAPI.Models
{
    public class PrescriptionDetail
    {
        public int PrescriptionDetailID { get; set; }
        public int PrescriptionID { get; set; }
        public int MedicineID { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Prescription Prescription { get; set; } = new Prescription();
        public Medicine Medicine { get; set; } = new Medicine();
    }
}
