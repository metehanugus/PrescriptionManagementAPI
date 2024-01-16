namespace PrescriptionManagementAPI.Models
{
    public class PaymentReport
    {
        public int PaymentReportID { get; set; }
        public int PharmacyID { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmountDue { get; set; }
        public bool EmailSent { get; set; }

        // Navigation property
        public Pharmacy Pharmacy { get; set; } = new Pharmacy();
    }
}
