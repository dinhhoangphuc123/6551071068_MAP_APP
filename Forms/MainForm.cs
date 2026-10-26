using _6551071068_MAP_APP.UI;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        ConfigureResponsiveLayout();
        lblUser.Text = LoginForm.TenNvDangNhap;
        ShowHome();
    }

    private void ConfigureResponsiveLayout()
    {
        AutoScroll = false;
        pnlHeader.Dock = DockStyle.Top;
        pnlSidebar.Dock = DockStyle.Left;
        pnlProfile.Dock = DockStyle.Top;
        pnlNav.Dock = DockStyle.Fill;
        pnlMainContent.Dock = DockStyle.Fill;
        pnlMainContent.AutoScroll = false;

        Resize += (_, _) => LayoutResponsiveShell();
        pnlNav.Resize += (_, _) => LayoutNavigation();
        pnlProfile.Resize += (_, _) => LayoutProfile();
        LayoutResponsiveShell();
    }

    private void LayoutResponsiveShell()
    {
        int clientWidth = Math.Max(1, ClientSize.Width);
        int clientHeight = Math.Max(1, ClientSize.Height);
        int headerHeight = Math.Clamp((int)(clientHeight * 0.102), 52, 74);
        int profileHeight = Math.Clamp((int)(clientHeight * 0.195), 100, 142);

        pnlHeader.Height = headerHeight;
        pnlSidebar.Width = Math.Clamp((int)(clientWidth * 0.18), 170, 235);
        pnlProfile.Height = profileHeight;

        int logoHeight = Math.Max(36, headerHeight - 10);
        int logoWidth = Math.Max(26, (int)(logoHeight * 0.62));
        picLogo.SetBounds(4, (headerHeight - logoHeight) / 2, logoWidth, logoHeight);
        lblTitle.Location = new Point(logoWidth + 14, Math.Max(4, (headerHeight - lblTitle.Height) / 2));
        lblTitle.Font = new Font("Segoe UI Semibold", Math.Clamp(headerHeight * 0.22f, 12f, 16f), FontStyle.Bold);

        linkDangXuat.Location = new Point(6, 5);
        linkDangXuat.Font = new Font("Microsoft Sans Serif", Math.Clamp(headerHeight * 0.14f, 8.5f, 10f));
        LayoutProfile();
        LayoutNavigation();
    }

    private void LayoutProfile()
    {
        int profileHeight = pnlProfile.ClientSize.Height;
        if (profileHeight <= 0)
        {
            return;
        }

        int imageHeight = Math.Clamp(profileHeight - 48, 48, 78);
        int imageWidth = Math.Max(38, (int)(imageHeight * 0.81));
        picUser.SetBounds((pnlProfile.ClientSize.Width - imageWidth) / 2, 21, imageWidth, imageHeight);
        int labelTop = Math.Max(68, profileHeight - 27);
        lblUser.SetBounds(5, labelTop, Math.Max(0, pnlProfile.ClientSize.Width - 10), 24);
        lblUser.Font = new Font("Microsoft Sans Serif", Math.Clamp(profileHeight * 0.071f, 8f, 10f), FontStyle.Bold);
    }

    private void LayoutNavigation()
    {
        Button[] buttons =
        [
            btnTrangChu, btnSoDoPhong, btnPhong, btnLoaiPhong,
            btnDanhSachDatPhong, btnDanhSachHoaDon, btnDanhSachDichVu,
            btnDanhSachTienNghi, btnDanhSachKhachHang, btnDanhSachNhanVien,
            btnDanhSachTaiKhoan, btnThongKe
        ];
        if (pnlNav.ClientSize.Height <= 0 || pnlNav.ClientSize.Width <= 0)
        {
            return;
        }

        int rowHeight = Math.Max(1, pnlNav.ClientSize.Height / buttons.Length);
        float baseFontSize = Math.Clamp(rowHeight * 0.25f, 7f, 11.5f);
        for (int index = 0; index < buttons.Length; index++)
        {
            buttons[index].SetBounds(0, index * rowHeight, pnlNav.ClientSize.Width,
                index == buttons.Length - 1 ? pnlNav.ClientSize.Height - index * rowHeight : rowHeight);
            buttons[index].TextAlign = ContentAlignment.MiddleLeft;
            buttons[index].ImageAlign = ContentAlignment.MiddleLeft;
            buttons[index].TextImageRelation = TextImageRelation.ImageBeforeText;
            buttons[index].Padding = new Padding(10, 0, 4, 0);

            int iconWidth = buttons[index].Image?.Width ?? 28;
            int textWidth = Math.Max(40, pnlNav.ClientSize.Width - buttons[index].Padding.Horizontal - iconWidth - 8);
            float fontSize = baseFontSize;
            while (fontSize > 7f)
            {
                using var measureFont = new Font("Microsoft Sans Serif", fontSize);
                if (TextRenderer.MeasureText(buttons[index].Text, measureFont, Size.Empty,
                        TextFormatFlags.NoPadding | TextFormatFlags.SingleLine).Width <= textWidth)
                {
                    break;
                }

                fontSize -= 0.5f;
            }
            buttons[index].Font = new Font("Microsoft Sans Serif", fontSize);
        }
    }

    private void BtnTrangChu_Click(object? sender, EventArgs e) => ShowHome();
    private void BtnSoDoPhong_Click(object? sender, EventArgs e) => ShowFloorPlan();
    private void BtnPhong_Click(object? sender, EventArgs e) => ShowRoomList();
    private void BtnLoaiPhong_Click(object? sender, EventArgs e) => ShowRoomTypes();

    // Các mục menu chưa làm: tiêu đề trang chính là chữ trên nút
    private void NavPlaceholder_Click(object? sender, EventArgs e) => ShowPlaceholder(((Button)sender!).Text);

    private void SetPage(Control page)
    {
        foreach (Control control in pnlMainContent.Controls.Cast<Control>().ToList())
        {
            pnlMainContent.Controls.Remove(control);
            control.Dispose();
        }

        page.Dock = DockStyle.Fill;
        pnlMainContent.Controls.Add(page);
        page.BringToFront();
    }

    private void ShowHome()
    {
        if (pnlMainContent.Controls.Count == 1 && pnlMainContent.Controls[0] is FormTrangChu)
        {
            return;
        }

        SetPage(new FormTrangChu());
    }

    private void ShowFloorPlan() => SetPage(new FloorPlanControl());
    private void ShowRoomList() => SetPage(new RoomListControl());
    private void ShowRoomTypes() => SetPage(new RoomTypeControl());

    private void ShowPlaceholder(string title)
    {
        var label = new Label
        {
            Dock = DockStyle.Fill,
            Text = $"{title}{Environment.NewLine}(chức năng đang được xây dựng)",
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Italic),
            ForeColor = Color.DarkCyan,
            BackColor = ClassicUi.Honeydew
        };
        SetPage(label);
    }

    private void Logout_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        Hide();
        using var login = new LoginForm();
        if (login.ShowDialog() == DialogResult.OK)
        {
            lblUser.Text = LoginForm.TenNvDangNhap;
            ShowHome();
            Show();
            Activate();
            return;
        }

        Close();
    }
}
