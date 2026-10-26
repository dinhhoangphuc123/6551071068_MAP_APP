using System.Drawing.Drawing2D;

namespace _6551071068_MAP_APP.UI;

internal static class UiTheme
{
    public static readonly Color Ink = Color.FromArgb(29, 41, 57);
    public static readonly Color Muted = Color.FromArgb(104, 119, 139);
    public static readonly Color Navy = Color.FromArgb(22, 46, 74);
    public static readonly Color Teal = Color.FromArgb(0, 136, 145);
    public static readonly Color TealDark = Color.FromArgb(0, 105, 112);
    public static readonly Color Canvas = Color.FromArgb(244, 247, 250);
    public static readonly Color Border = Color.FromArgb(224, 231, 238);
    public static readonly Color White = Color.White;

    public static Label Label(string text, float size = 10, bool bold = false, Color? color = null)
        => new()
        {
            AutoSize = true,
            Text = text,
            ForeColor = color ?? Ink,
            Font = new Font("Segoe UI", size, bold ? FontStyle.Bold : FontStyle.Regular),
            Margin = new Padding(0, 5, 8, 5)
        };

    public static Button Button(string text, bool primary = false)
    {
        var button = new Button
        {
            Text = text,
            AutoSize = true,
            MinimumSize = new Size(110, 40),
            Padding = new Padding(12, 5, 12, 5),
            FlatStyle = FlatStyle.Flat,
            BackColor = primary ? Teal : White,
            ForeColor = primary ? White : Ink,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
            Cursor = Cursors.Hand,
            Margin = new Padding(4)
        };
        button.FlatAppearance.BorderColor = primary ? Teal : Border;
        button.FlatAppearance.MouseOverBackColor = primary ? TealDark : Color.FromArgb(239, 244, 248);
        return button;
    }

    public static TextBox TextBox(bool password = false)
        => new()
        {
            BorderStyle = BorderStyle.FixedSingle,
            Font = new Font("Segoe UI", 11f),
            Height = 36,
            UseSystemPasswordChar = password,
            Margin = new Padding(0, 4, 0, 12),
            Dock = DockStyle.Top
        };

    public static ComboBox ComboBox()
        => new()
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = new Font("Segoe UI", 10f),
            Height = 34,
            Margin = new Padding(0, 4, 0, 10),
            Dock = DockStyle.Top
        };

    public static DataGridView Grid()
        => new()
        {
            Dock = DockStyle.Fill,
            AutoGenerateColumns = false,
            BackgroundColor = White,
            BorderStyle = BorderStyle.None,
            GridColor = Border,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            ReadOnly = true,
            MultiSelect = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            RowTemplate = { Height = 42 },
            ColumnHeadersHeight = 44,
            EnableHeadersVisualStyles = false,
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(238, 243, 247),
                ForeColor = Ink,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                SelectionBackColor = Color.FromArgb(238, 243, 247),
                SelectionForeColor = Ink,
                Padding = new Padding(6)
            },
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Ink,
                BackColor = White,
                SelectionBackColor = Color.FromArgb(222, 240, 241),
                SelectionForeColor = Ink,
                Padding = new Padding(6)
            },
            AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(249, 251, 253)
            }
        };

    public static Panel Card()
        => new()
        {
            BackColor = White,
            Padding = new Padding(18),
            Margin = new Padding(0),
            BorderStyle = BorderStyle.FixedSingle
        };

    public static void Round(Control control, int radius = 10)
    {
        if (control.Width <= 0 || control.Height <= 0)
        {
            return;
        }

        using var path = new GraphicsPath();
        int diameter = radius * 2;
        path.AddArc(0, 0, diameter, diameter, 180, 90);
        path.AddArc(control.Width - diameter - 1, 0, diameter, diameter, 270, 90);
        path.AddArc(control.Width - diameter - 1, control.Height - diameter - 1, diameter, diameter, 0, 90);
        path.AddArc(0, control.Height - diameter - 1, diameter, diameter, 90, 90);
        path.CloseFigure();
        control.Region = new Region(path);
    }
}

internal static class AppImages
{
    public static Image? Load(string fileName)
    {
        string path = Path.Combine(AppContext.BaseDirectory, "Resources", fileName);
        if (!File.Exists(path))
        {
            return null;
        }

        using Image source = Image.FromFile(path);
        return new Bitmap(source);
    }
}
