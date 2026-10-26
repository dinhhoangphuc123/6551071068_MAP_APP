using _6551071068_MAP_APP.Data;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class LoginForm : Form
{
    public static string MaNvDangNhap { get; private set; } = string.Empty;
    public static string TenNvDangNhap { get; private set; } = string.Empty;
    public static int CapDoQuyenDangNhap { get; private set; }

    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginForm_Shown(object? sender, EventArgs e) => txtUsername.Focus();

    private void LinkQuenMatKhau_Click(object? sender, EventArgs e)
    {
        using var dialog = new ForgotPasswordDialog(txtUsername.Text.Trim());
        dialog.ShowDialog(this);
    }

    private void SubmitOnEnter(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            btnLogin.PerformClick();
        }
    }

    private async void BtnLogin_Click(object? sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;
        if (username.Length == 0 || password.Length == 0)
        {
            MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnLogin.Enabled = false;
        btnLogin.Text = "Đang kiểm tra...";
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
                !PasswordHasher.Verify(account.Password, password))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            if (PasswordHasher.NeedsRehash(account.Password))
            {
                var accountToUpgrade = await db.TaiKhoans.FirstOrDefaultAsync(t => t.TenTk == username);
                if (accountToUpgrade is not null &&
                    string.Equals(accountToUpgrade.Password, account.Password, StringComparison.Ordinal))
                {
                    accountToUpgrade.Password = PasswordHasher.Hash(password);
                    await db.SaveChangesAsync();
                }
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
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
        }
    }
}
