using System.Net;
using System.Net.Mail;
using System.Text;

namespace _6551071068_MAP_APP.Data;

internal static class GmailSmtpMailSender
{
    public static async Task SendPasswordResetCodeAsync(string recipient, string code)
    {
        GmailSmtpSettings settings = AppConfiguration.GetGmailSmtpSettings();
        if (string.IsNullOrWhiteSpace(settings.From) || string.IsNullOrWhiteSpace(settings.AppPassword))
        {
            throw new InvalidOperationException(
                "Chưa cấu hình GmailSMTP:From và GmailSMTP:AppPassword trong appsettings.json hoặc biến môi trường.");
        }

        using var message = new MailMessage
        {
            From = new MailAddress(settings.From, "HotelManagement"),
            Subject = "Mã xác nhận đặt lại mật khẩu",
            SubjectEncoding = Encoding.UTF8,
            BodyEncoding = Encoding.UTF8,
            IsBodyHtml = false,
            Body = $"Mã xác nhận đặt lại mật khẩu của bạn là: {code}\r\n\r\n" +
                   "Mã có hiệu lực trong 5 phút. Nếu bạn không yêu cầu đặt lại mật khẩu, hãy bỏ qua email này."
        };
        message.To.Add(new MailAddress(recipient));

        using var client = new SmtpClient(settings.Host, settings.Port)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(settings.From, settings.AppPassword),
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Timeout = 20000
        };

        await client.SendMailAsync(message);
    }
}
