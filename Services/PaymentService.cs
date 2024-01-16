using Microsoft.EntityFrameworkCore;
using PrescriptionManagementAPI.Models;
using System.Net.Mail;
using System.Net;

namespace PrescriptionManagementAPI.Services
{
    public class PaymentService
    {
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


            public async Task SendEmailReportsAsync(IEnumerable<PaymentReport> paymentReports)
            {
                foreach (var report in paymentReports)
                {
                    var pharmacy = await _context.Pharmacies.FindAsync(report.PharmacyID);
                    if (pharmacy != null)
                    {
                        // Construct the email message
                        string subject = "Daily Payment Report";
                        string body = $"Total amount due: {report.TotalAmountDue} TL";
                        await EmailSender.SendEmailAsync(pharmacy.Email, subject, body);
                    }
                }
            }
            public async Task SendEmailAsync(string toEmail, string subject, string body)
            {
                try
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("your_email@example.com"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };
                    mailMessage.To.Add(new MailAddress(toEmail));

                    await _smtpClient.SendMailAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    // Handle any errors here (log them, etc.)
                    throw;
                }
            }
        }

    }
}
