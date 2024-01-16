namespace PrescriptionManagementAPI.Models
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Navigation properties
        public List<PrescriptionDetail> PrescriptionDetails { get; set; } = new List<PrescriptionDetail>();
    }
}
