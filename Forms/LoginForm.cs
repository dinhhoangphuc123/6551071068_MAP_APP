using _6551071068_MAP_APP.Data;
using _6551071068_MAP_APP.UI;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed class LoginForm : Form
{
    private readonly TextBox _txtUsername = new();
    private readonly TextBox _txtPassword = new();
    private readonly Button _btnLogin = new();

    public static string MaNvDangNhap { get; private set; } = string.Empty;
    public static string TenNvDangNhap { get; private set; } = string.Empty;
    public static int CapDoQuyenDangNhap { get; private set; }

    public LoginForm()
    {
        Text = "Đăng nhập";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(855, 562);
        BackColor = Color.Beige;
        AcceptButton = _btnLogin;
        Font = new Font("Microsoft Sans Serif", 10f);

        var leftPanel = new Panel
        {
            Location = new Point(-22, 16),
            Size = new Size(414, 531),
            BackColor = Color.Beige
        };
        leftPanel.Controls.Add(new PictureBox
        {
            Image = AppImages.Load("pictureIcon.png"),
            Location = new Point(-16, 20),
            Size = new Size(458, 524),
            SizeMode = PictureBoxSizeMode.StretchImage
        });

        var panel = new Panel
        {
            BackColor = Color.Beige,
            Location = new Point(448, 16),
            Size = new Size(395, 531)
        };
        Controls.Add(panel);
        Controls.Add(leftPanel);

        panel.Controls.Add(new PictureBox
        {
            Image = AppImages.Load("DangNhap.png"),
            Location = new Point(97, 44),
            Size = new Size(203, 75),
            SizeMode = PictureBoxSizeMode.StretchImage
        });

        panel.Controls.Add(new Label
        {
            Text = "Tên đăng nhập",
            Location = new Point(19, 182),
            Size = new Size(141, 24),
            ForeColor = Color.FromArgb(192, 0, 0),
            Font = new Font("Microsoft Sans Serif", 11f)
        });
        panel.Controls.Add(new Label
        {
            Text = "Mật khẩu",
            Location = new Point(62, 265),
            Size = new Size(86, 24),
            ForeColor = Color.FromArgb(192, 0, 0),
            Font = new Font("Microsoft Sans Serif", 11f)
        });

        ConfigureLoginTextBox(_txtUsername, new Point(177, 170));
        ConfigureLoginTextBox(_txtPassword, new Point(177, 255));
        _txtPassword.PasswordChar = '*';
        panel.Controls.Add(_txtUsername);
        panel.Controls.Add(_txtPassword);

        var forgot = new LinkLabel
        {
            Text = "Quên mật khẩu",
            AutoSize = true,
            Location = new Point(222, 328),
            Font = new Font("Microsoft Sans Serif", 13f, FontStyle.Italic),
            LinkColor = Color.Blue
        };
        forgot.Click += (_, _) => MessageBox.Show("Vui lòng liên hệ quản trị viên để đặt lại mật khẩu.",
            "Quên mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        panel.Controls.Add(forgot);

        _btnLogin.Text = "Đăng nhập";
        _btnLogin.Location = new Point(117, 380);
        _btnLogin.Size = new Size(134, 66);
        _btnLogin.BackColor = Color.FromArgb(192, 192, 255);
        _btnLogin.ForeColor = Color.Black;
        _btnLogin.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);
        _btnLogin.UseVisualStyleBackColor = false;
        _btnLogin.Click += BtnLogin_Click;
        panel.Controls.Add(_btnLogin);
        _txtUsername.KeyDown += SubmitOnEnter;
        _txtPassword.KeyDown += SubmitOnEnter;
        Shown += (_, _) => _txtUsername.Focus();
    }

    private static void ConfigureLoginTextBox(TextBox textBox, Point location)
    {
        textBox.Location = location;
        textBox.Size = new Size(192, 34);
        textBox.Font = new Font("Microsoft Sans Serif", 14f);
        textBox.BorderStyle = BorderStyle.Fixed3D;
    }

    private void SubmitOnEnter(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            _btnLogin.PerformClick();
        }
    }

    private async void BtnLogin_Click(object? sender, EventArgs e)
    {
        string username = _txtUsername.Text.Trim();
        string password = _txtPassword.Text;
        if (username.Length == 0 || password.Length == 0)
        {
            MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _btnLogin.Enabled = false;
        _btnLogin.Text = "Đang kiểm tra...";
        try
        {
            await using var db = new HotelManagementContext();
            var account = await db.TaiKhoans
                .AsNoTracking()
                .Where(t => t.TenTk == username && t.DaXoa != true)
                .Select(t => new
                {
                    t.Password,
                    t.MaNv,
                    t.CapDoQuyen,
                    TenNv = t.MaNvNavigation!.TenNv,
                    NhanVienDaXoa = t.MaNvNavigation!.DaXoa
                })
                .FirstOrDefaultAsync();

            if (account is null || account.NhanVienDaXoa == true ||
                !string.Equals(account.Password, password, StringComparison.Ordinal))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _txtPassword.Clear();
                _txtPassword.Focus();
                return;
            }

            MaNvDangNhap = account.MaNv ?? string.Empty;
            TenNvDangNhap = account.TenNv ?? username;
            CapDoQuyenDangNhap = account.CapDoQuyen;
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể kết nối hoặc đọc dữ liệu đăng nhập từ HotelManagement. " +
                "Kiểm tra SQL Server và chuỗi kết nối trong appsettings.json.\n\n" + ex.GetBaseException().Message,
                "Lỗi kết nối cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (!IsDisposed)
            {
                _btnLogin.Enabled = true;
                _btnLogin.Text = "Đăng nhập";
            }
        }
    }
}
