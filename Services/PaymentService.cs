using PrescriptionManagementAPI.Data;
using PrescriptionManagementAPI.Models;
using System.Net;
using System.Net.Mail;

public class PaymentService
{
    private readonly PrescriptionManagementContext _context;
    private readonly EmailSender _emailSender;

    public PaymentService(PrescriptionManagementContext context, EmailSender emailSender)
    {
        _context = context;
        _emailSender = emailSender;
    }

    public async Task SendEmailReportsAsync(IEnumerable<PaymentReport> paymentReports)
    {
        foreach (var report in paymentReports)
        {
            var pharmacy = await _context.Pharmacies.FindAsync(report.PharmacyID);
            if (pharmacy != null)
            {
                
                string subject = "Daily Payment Report";
                string body = $"Total amount due: {report.TotalAmountDue} TL";
                await _emailSender.SendEmailAsync(pharmacy.Email, subject, body);
            }
        }
    }
}

public class EmailSender
{
    private readonly SmtpClient _smtpClient;
    public EmailSender(string smtpHost, int smtpPort, string smtpUsername, string smtpPassword)
    {
        _smtpClient = new SmtpClient(smtpHost)
        {
            Port = smtpPort,
            Credentials = new NetworkCredential(smtpUsername, smtpPassword),
            EnableSsl = true,
        };
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        try
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("se4458information@example.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(new MailAddress(toEmail));

            await _smtpClient.SendMailAsync(mailMessage);
        }
        catch (Exception ex)
        {
            
        }
    }
}

