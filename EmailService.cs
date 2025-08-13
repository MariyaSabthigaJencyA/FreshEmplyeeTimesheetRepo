using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.Generic;

public class EmailService : IEmailService
{
    public async Task SendTimesheetRemindersAsync()
    {
        // Replace with your employee email list retrieval logic
        List<string> employeeEmails = new List<string> { "employee1@example.com", "employee2@example.com" };

        foreach (var email in employeeEmails)
        {
            await SendEmailAsync(email, "Timesheet Reminder", "Please submit your timesheet before month end.");
        }
    }

    private async Task SendEmailAsync(string to, string subject, string body)
    {
        var smtpClient = new SmtpClient("smtp.yourserver.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("yourusername", "yourpassword"),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("noreply@yourdomain.com"),
            Subject = subject,
            Body = body,
            IsBodyHtml = false,
        };
        mailMessage.To.Add(to);

        await smtpClient.SendMailAsync(mailMessage);
    }
}
