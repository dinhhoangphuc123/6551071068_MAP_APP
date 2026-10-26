namespace _6551071068_MAP_APP.UI;

internal static class ClassicUi
{
    public static readonly Color Honeydew = Color.FromArgb(240, 255, 240);
    public static readonly Color SeaGreen = Color.FromArgb(46, 139, 87);
    public static readonly Color MediumSeaGreen = Color.FromArgb(60, 179, 113);
    public static readonly Color DarkCyan = Color.FromArgb(0, 139, 139);
    public static readonly Color GreenYellow = Color.FromArgb(173, 255, 47);

    public static Image? Image(string fileName) => AppImages.Load(fileName);

    public static DataGridView Grid()
        => new()
        {
            Dock = DockStyle.Fill,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            AutoGenerateColumns = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = SystemColors.AppWorkspace,
            BorderStyle = BorderStyle.Fixed3D,
            CellBorderStyle = DataGridViewCellBorderStyle.Single,
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised,
            ColumnHeadersHeight = 35,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            EnableHeadersVisualStyles = true,
            Font = new Font("Microsoft Sans Serif", 9f),
            GridColor = SystemColors.ControlDark,
            MultiSelect = false,
            ReadOnly = true,
            RowHeadersVisible = false,
            RowTemplate = { Height = 40 },
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };

    public static Button ToolbarButton(string text, Color color, int width)
        => new()
        {
            Text = text,
            Size = new Size(width, 37),
            BackColor = color,
            ForeColor = Color.Black,
            Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold),
            FlatStyle = FlatStyle.Standard,
            UseVisualStyleBackColor = false
        };

    public static void AddImageColumn(DataGridView grid, string name, string header, string imageFile,
        int width, string description)
    {
        var image = Image(imageFile);
        if (image is null)
        {
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                FillWeight = width
            });
            return;
        }

        grid.Columns.Add(new DataGridViewImageColumn
        {
            Name = name,
            HeaderText = header,
            Image = image,
            ImageLayout = DataGridViewImageCellLayout.Zoom,
            FillWeight = width,
            Description = description,
            ValuesAreIcons = false
        });
    }
}
