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
}
