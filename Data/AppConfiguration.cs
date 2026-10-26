using System.Text.Json;

namespace _6551071068_MAP_APP.Data;

internal static class AppConfiguration
{
    public static string GetDefaultConnectionString()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(
                "Không tìm thấy appsettings.json trong thư mục chạy ứng dụng.", filePath);
        }

        using JsonDocument settings = JsonDocument.Parse(File.ReadAllText(filePath));
        if (!settings.RootElement.TryGetProperty("ConnectionStrings", out JsonElement strings) ||
            !strings.TryGetProperty("DefaultConnection", out JsonElement connectionString) ||
            string.IsNullOrWhiteSpace(connectionString.GetString()))
        {
            throw new InvalidOperationException(
                "appsettings.json chưa khai báo ConnectionStrings:DefaultConnection.");
        }

        return connectionString.GetString()!;
    }

    public static GmailSmtpSettings GetGmailSmtpSettings()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        JsonDocument? settings = File.Exists(filePath)
            ? JsonDocument.Parse(File.ReadAllText(filePath))
            : null;

        using (settings)
        {
            JsonElement smtp = default;
            if (settings is not null &&
                settings.RootElement.TryGetProperty("GmailSMTP", out JsonElement smtpSection))
            {
                smtp = smtpSection;
            }

            string Read(string key, string fallback = "")
            {
                string? environmentValue = Environment.GetEnvironmentVariable($"GmailSMTP__{key}");
                if (!string.IsNullOrWhiteSpace(environmentValue))
                {
                    return environmentValue.Trim();
                }

                return smtp.ValueKind == JsonValueKind.Object &&
                    smtp.TryGetProperty(key, out JsonElement value)
                    ? value.ToString().Trim()
                    : fallback;
            }

            string host = Read("Host", "smtp.gmail.com");
            string portText = Read("Port", "587");
            if (!int.TryParse(portText, out int port) || port is < 1 or > 65535)
            {
                throw new InvalidOperationException("GmailSMTP:Port phải là số từ 1 đến 65535.");
            }

            string appPassword = string.Concat(Read("AppPassword").Where(c => !char.IsWhiteSpace(c)));
            return new GmailSmtpSettings(host, port, Read("From"), appPassword);
        }
    }
}

internal sealed record GmailSmtpSettings(string Host, int Port, string From, string AppPassword);
