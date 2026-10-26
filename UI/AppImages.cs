using System.Collections.Concurrent;

namespace _6551071068_MAP_APP.UI;

internal static class AppImages
{
    // Mỗi ảnh chỉ nạp một lần và dùng chung toàn ứng dụng; không Dispose ảnh lấy từ đây.
    private static readonly ConcurrentDictionary<string, Image?> Cache = new(StringComparer.OrdinalIgnoreCase);

    public static Image? Load(string fileName)
        => Cache.GetOrAdd(fileName, static name =>
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Resources", name);
            if (!File.Exists(path))
            {
                return null;
            }

            using Image source = Image.FromFile(path);
            return new Bitmap(source);
        });
}
