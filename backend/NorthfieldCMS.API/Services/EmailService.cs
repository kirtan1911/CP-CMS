using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NorthfieldCMS.API.Services
{
    public interface IEmailService
    {
        Task SendOtpEmailAsync(string toEmail, string recipientName, string otpCode);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration config, ILogger<EmailService> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task SendOtpEmailAsync(string toEmail, string recipientName, string otpCode)
        {
            var senderEmail = _config["EmailSettings:SenderEmail"] ?? "kirtanbarot1911@gmail.com";
            var senderName = _config["EmailSettings:SenderName"] ?? "College Management System";
            var smtpHost = _config["EmailSettings:SmtpHost"] ?? "smtp.gmail.com";
            var smtpPortStr = _config["EmailSettings:SmtpPort"] ?? "587";
            var appPassword = _config["EmailSettings:AppPassword"] ?? "";

            int smtpPort = int.TryParse(smtpPortStr, out var p) ? p : 587;

            _logger.LogInformation("[EMAIL SERVICE]: Preparing OTP email for {Email} with OTP: {Otp}", toEmail, otpCode);

            if (string.IsNullOrWhiteSpace(appPassword))
            {
                _logger.LogWarning("[EMAIL SERVICE]: AppPassword not set in appsettings.json. OTP for {Email} is {OtpCode}", toEmail, otpCode);
                return;
            }

            try
            {
                using var message = new MailMessage();
                message.From = new MailAddress(senderEmail, senderName);
                message.To.Add(new MailAddress(toEmail, recipientName));
                message.Subject = "Your Password Reset OTP — College Management System";
                message.Body = BuildOtpEmailBody(recipientName, otpCode);
                message.IsBodyHtml = true;

                using var smtpClient = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(senderEmail, appPassword),
                    EnableSsl = true
                };

                await smtpClient.SendMailAsync(message);
                _logger.LogInformation("[EMAIL SERVICE]: OTP email sent successfully to {Email}", toEmail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[EMAIL SERVICE]: Failed to send OTP email to {Email}. Logging OTP for fallback: {OtpCode}", toEmail, otpCode);
            }
        }

        private static string BuildOtpEmailBody(string recipientName, string otpCode)
        {
            return $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""UTF-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
  <title>Password Reset OTP</title>
</head>
<body style=""margin:0;padding:0;background:#0d1117;font-family:'Segoe UI',Arial,sans-serif;"">
  <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""background:#0d1117;padding:40px 0;"">
    <tr>
      <td align=""center"">
        <table width=""520"" cellpadding=""0"" cellspacing=""0""
               style=""background:#161b22;border:1px solid #30363d;border-radius:16px;overflow:hidden;"">

          <!-- Header -->
          <tr>
            <td style=""background:linear-gradient(135deg,#7c3aed,#22d3ee);padding:32px;text-align:center;"">
              <div style=""font-size:36px;"">🎓</div>
              <h1 style=""color:#fff;margin:10px 0 4px;font-size:22px;font-weight:700;"">
                College Management System
              </h1>
              <p style=""color:rgba(255,255,255,.8);margin:0;font-size:13px;"">
                Password Reset Request
              </p>
            </td>
          </tr>

          <!-- Body -->
          <tr>
            <td style=""padding:36px 40px;"">
              <p style=""color:#c9d1d9;font-size:15px;margin:0 0 8px;"">
                Hello <strong style=""color:#fff;"">{recipientName}</strong>,
              </p>
              <p style=""color:#8b949e;font-size:14px;margin:0 0 28px;line-height:1.6;"">
                We received a request to reset the password for your College Management System account. Use the OTP code below to proceed.
                This code expires in <strong style=""color:#f0883e;"">5 minutes</strong>.
              </p>

              <!-- OTP Box -->
              <div style=""background:#0d1117;border:2px dashed #7c3aed;border-radius:12px;
                           padding:24px;text-align:center;margin-bottom:28px;"">
                <p style=""color:#8b949e;font-size:12px;letter-spacing:2px;
                            text-transform:uppercase;margin:0 0 12px;"">Your One-Time Password</p>
                <span style=""font-size:42px;font-weight:700;letter-spacing:12px;
                              color:#22d3ee;font-family:monospace;"">{otpCode}</span>
              </div>

              <p style=""color:#8b949e;font-size:13px;line-height:1.6;margin:0 0 20px;"">
                ⚠️ <strong style=""color:#f0883e;"">Do not share this OTP with anyone.</strong>
                If you did not request a password reset, please ignore this email. Your account remains secure.
              </p>

              <hr style=""border:none;border-top:1px solid #30363d;margin:24px 0;"">
              <p style=""color:#484f58;font-size:12px;text-align:center;margin:0;"">
                This is an automated email — please do not reply.<br>
                © {DateTime.UtcNow.Year} Northfield College Management System
              </p>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</body>
</html>";
        }
    }
}
