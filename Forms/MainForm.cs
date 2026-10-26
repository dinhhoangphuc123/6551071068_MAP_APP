using _6551071068_MAP_APP.UI;

namespace _6551071068_MAP_APP.Forms;

public sealed class MainForm : Form
{
    private readonly Panel _mainContent = new()
    {
        BackColor = ClassicUi.Honeydew,
        Location = new Point(312, 105),
        Size = new Size(1647, 1349),
        AutoScroll = true
    };
    private readonly Label _userLabel = new()
    {
        AutoSize = false,
        Location = new Point(8, 155),
        Size = new Size(288, 28),
        TextAlign = ContentAlignment.MiddleCenter,
        ForeColor = Color.Black,
        Font = new Font("Microsoft Sans Serif", 13f, FontStyle.Bold)
    };

    public MainForm()
    {
        Text = "Hotel Management";
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;
        AutoScroll = true;
        AutoScrollMinSize = new Size(1834, 1450);
        BackColor = Color.White;
        Font = new Font("Microsoft Sans Serif", 10f);

        Controls.Add(BuildHeader());
        Controls.Add(BuildProfile());
        Controls.Add(BuildNavigation());
        Controls.Add(_mainContent);
        ShowHome();
    }

    private Control BuildHeader()
    {
        var header = new Panel
        {
            BackColor = ClassicUi.SeaGreen,
            Location = new Point(0, 4),
            Size = new Size(1834, 92)
        };
        var logo = new PictureBox
        {
            Image = ClassicUi.Image("Menu.png"),
            Location = new Point(3, 4),
            Size = new Size(48, 78),
            SizeMode = PictureBoxSizeMode.StretchImage
        };
        header.Controls.Add(logo);
        header.Controls.Add(new Label
        {
            Text = "Hotel Management",
            AutoSize = true,
            Location = new Point(66, 19),
            ForeColor = Color.LightSalmon,
            Font = new Font("Segoe UI Semibold", 18f, FontStyle.Bold)
        });
        return header;
    }

    private Control BuildProfile()
    {
        var profile = new Panel
        {
            BackColor = ClassicUi.MediumSeaGreen,
            Location = new Point(0, 94),
            Size = new Size(304, 198)
        };
        var logout = new LinkLabel
        {
            Text = "Đăng xuất",
            AutoSize = true,
            Location = new Point(4, 11),
            LinkColor = Color.MidnightBlue,
            ActiveLinkColor = Color.DarkBlue,
            Font = new Font("Microsoft Sans Serif", 13f)
        };
        logout.Click += Logout_Click;
        profile.Controls.Add(logout);
        profile.Controls.Add(new PictureBox
        {
            Image = ClassicUi.Image("user.png"),
            Location = new Point(101, 48),
            Size = new Size(87, 108),
            SizeMode = PictureBoxSizeMode.StretchImage
        });
        _userLabel.Text = LoginForm.TenNvDangNhap;
        profile.Controls.Add(_userLabel);
        return profile;
    }

    private Control BuildNavigation()
    {
        var navigation = new Panel
        {
            BackColor = ClassicUi.DarkCyan,
            Location = new Point(0, 289),
            Size = new Size(304, 1161)
        };
        var entries = new (string Text, string Icon, Action Open)[]
        {
            ("Trang chủ", "MenuTrangChu.png", ShowHome),
            ("Sơ đồ phòng", "MenuSoDoPhong.png", ShowFloorPlan),
            ("Phòng", "MenuPhong.png", ShowRoomList),
            ("Loại phòng", "MenuLoaiPhong.png", ShowRoomTypes),
            ("Danh sách đặt phòng", "MenuDatPhong.png", () => ShowPlaceholder("Danh sách đặt phòng")),
            ("Danh sách hóa đơn", "MenuDanhSachHoaDon.png", () => ShowPlaceholder("Danh sách hóa đơn")),
            ("Danh sách dịch vụ", "MenuQuanLyDichVu.png", () => ShowPlaceholder("Danh sách dịch vụ")),
            ("Danh sách tiện nghi", "MenuTienNghi.png", () => ShowPlaceholder("Danh sách tiện nghi")),
            ("Danh sách khách hàng", "MenuQuanLyKhachHang.png", () => ShowPlaceholder("Danh sách khách hàng")),
            ("Danh sách nhân viên", "MenuQuanLyNhanVien.png", () => ShowPlaceholder("Danh sách nhân viên")),
            ("Danh sách tài khoản", "MenuQuanLyTaiKhoan.png", () => ShowPlaceholder("Danh sách tài khoản")),
            ("Thống kê", "MenuThongKe.png", () => ShowPlaceholder("Thống kê"))
        };

        int y = 0;
        foreach (var entry in entries)
        {
            int height = y == 0 ? 69 : 58;
            var button = new Button
            {
                Text = entry.Text,
                TextAlign = ContentAlignment.MiddleCenter,
                Image = ClassicUi.Image(entry.Icon),
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.Overlay,
                Location = new Point(0, y),
                Size = new Size(304, height),
                BackColor = ClassicUi.DarkCyan,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 13f),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                Padding = new Padding(15, 0, 4, 0),
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderColor = Color.White;
            button.FlatAppearance.BorderSize = 1;
            button.Click += (_, _) => entry.Open();
            navigation.Controls.Add(button);
            y += height;
        }

        return navigation;
    }

    private void SetPage(Control page)
    {
        foreach (Control control in _mainContent.Controls.Cast<Control>().ToList())
        {
            _mainContent.Controls.Remove(control);
            control.Dispose();
        }

        page.Dock = DockStyle.Fill;
        _mainContent.Controls.Add(page);
        page.BringToFront();
    }

    private void ShowHome()
    {
        if (_mainContent.Controls.Count == 1 && _mainContent.Controls[0] is FormTrangChu)
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
            _userLabel.Text = LoginForm.TenNvDangNhap;
            ShowHome();
            Show();
            Activate();
            return;
        }

        Close();
    }
}
