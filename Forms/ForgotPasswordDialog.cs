using System.Net.Mail;
using System.Security.Cryptography;
using _6551071068_MAP_APP.Data;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class ForgotPasswordDialog : Form
{
    private const int CodeLifetimeMinutes = 5;
    private const int MaxVerificationAttempts = 5;
    private const int ResendDelaySeconds = 60;

    private readonly System.Windows.Forms.Timer _resendTimer = new() { Interval = 1000 };
    private string _username = string.Empty;
    private string? _verificationCode;
    private DateTimeOffset _codeExpiresAt;
    private DateTimeOffset _resendAvailableAt;
    private int _verificationAttempts;
    private bool _isVerified;

    public ForgotPasswordDialog(string username = "")
    {
        InitializeComponent();
        txtUsername.Text = username;
        _resendTimer.Tick += ResendTimer_Tick;
    }

    private void ForgotPasswordDialog_Shown(object? sender, EventArgs e) => txtUsername.Focus();

    private async void BtnSendCode_Click(object? sender, EventArgs e)
    {
        await SendCodeAsync(isResend: false);
    }

    private async void BtnResendCode_Click(object? sender, EventArgs e)
    {
        await SendCodeAsync(isResend: true);
    }

    private async Task SendCodeAsync(bool isResend)
    {
        string username = _username.Length == 0 ? txtUsername.Text.Trim() : _username;
        if (username.Length == 0)
        {
            MessageBox.Show(this, "Vui lòng nhập tên đăng nhập hoặc email nhân viên.", "Thiếu thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Focus();
            return;
        }

        if (isResend && DateTimeOffset.UtcNow < _resendAvailableAt)
        {
            UpdateResendButton();
            return;
        }

        btnSendCode.Enabled = false;
        btnResendCode.Enabled = false;
        btnSendCode.Text = "Đang gửi mã...";

        try
        {
            // Check SMTP configuration first so a missing setup does not reveal
            // whether a username exists in the database.
            GmailSmtpSettings smtp = AppConfiguration.GetGmailSmtpSettings();
            if (string.IsNullOrWhiteSpace(smtp.From))
            {
                throw new InvalidOperationException(
                    "Thiếu GmailSMTP:From. Hãy điền địa chỉ Gmail gửi trong appsettings.json hoặc biến môi trường GmailSMTP__From.");
            }

            if (string.IsNullOrWhiteSpace(smtp.AppPassword))
            {
                throw new InvalidOperationException(
                    "Chưa có GmailSMTP:AppPassword. Hãy lưu Gmail App Password mới vào biến môi trường người dùng " +
                    "GmailSMTP__AppPassword rồi khởi động lại Visual Studio.");
            }

            await using var db = new HotelManagementContext();
            var account = await db.TaiKhoans
                .AsNoTracking()
                .Where(t => (t.TenTk == username || t.MaNvNavigation!.Email == username) &&
                    t.DaXoa != true && t.MaNvNavigation!.DaXoa != true)
                .Select(t => new { t.TenTk, Email = t.MaNvNavigation!.Email })
                .FirstOrDefaultAsync();

            if (account is null || string.IsNullOrWhiteSpace(account.Email) ||
                !MailAddress.TryCreate(account.Email, out _))
            {
                MessageBox.Show(this,
                    "Nếu tài khoản hợp lệ và có email nhân viên đã đăng ký, mã xác nhận sẽ được gửi. " +
                    "Nếu chưa nhận được mã, hãy kiểm tra email trong hồ sơ nhân viên.",
                    "Yêu cầu đã được tiếp nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string code = RandomNumberGenerator.GetInt32(0, 1_000_000).ToString("D6");
            await GmailSmtpMailSender.SendPasswordResetCodeAsync(account.Email, code);

            _username = account.TenTk;
            _verificationCode = code;
            _codeExpiresAt = DateTimeOffset.UtcNow.AddMinutes(CodeLifetimeMinutes);
            _verificationAttempts = 0;
            _resendAvailableAt = DateTimeOffset.UtcNow.AddSeconds(ResendDelaySeconds);
            lblMaskedEmail.Text = $"Mã đã được gửi đến {MaskEmail(account.Email)}";
            txtCode.Clear();
            pnlAccount.Visible = false;
            pnlVerify.Visible = true;
            pnlReset.Visible = false;
            lblStatus.Text = "Mã có hiệu lực trong 5 phút.";
            UpdateResendButton();
            _resendTimer.Start();
            txtCode.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this,
                "Không gửi được email xác nhận. Kiểm tra cấu hình Gmail SMTP và kết nối Internet.\n\n" +
                ex.GetBaseException().Message,
                "Lỗi gửi email", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (!IsDisposed)
            {
                btnSendCode.Enabled = true;
                btnSendCode.Text = "Gửi mã xác nhận";
                UpdateResendButton();
            }
        }
    }

    private void BtnVerifyCode_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_verificationCode))
        {
            MessageBox.Show(this, "Mã xác nhận không còn hiệu lực. Hãy yêu cầu gửi mã mới.",
                "Mã hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (DateTimeOffset.UtcNow >= _codeExpiresAt)
        {
            InvalidateCode();
            lblStatus.Text = "Mã đã hết hạn. Hãy gửi lại mã mới.";
            UpdateResendButton();
            return;
        }

        if (!string.Equals(txtCode.Text.Trim(), _verificationCode, StringComparison.Ordinal))
        {
            _verificationAttempts++;
            int attemptsLeft = MaxVerificationAttempts - _verificationAttempts;
            if (attemptsLeft <= 0)
            {
                InvalidateCode();
                lblStatus.Text = "Bạn đã nhập sai quá số lần cho phép. Hãy yêu cầu mã mới.";
                UpdateResendButton();
            }
            else
            {
                lblStatus.Text = $"Mã không đúng. Bạn còn {attemptsLeft} lần thử.";
            }

            txtCode.Clear();
            txtCode.Focus();
            return;
        }

        _verificationCode = null;
        _isVerified = true;
        _resendTimer.Stop();
        pnlAccount.Visible = false;
        pnlVerify.Visible = false;
        pnlReset.Visible = true;
        lblStatus.Text = "Mã xác nhận hợp lệ. Hãy đặt mật khẩu mới.";
        txtNewPassword.Focus();
    }

    private async void BtnSavePassword_Click(object? sender, EventArgs e)
    {
        if (!_isVerified)
        {
            MessageBox.Show(this, "Bạn cần xác minh mã trước khi đổi mật khẩu.",
                "Chưa xác minh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string password = txtNewPassword.Text;
        if (password.Length < 8)
        {
            MessageBox.Show(this, "Mật khẩu mới phải có ít nhất 8 ký tự.",
                "Mật khẩu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNewPassword.Focus();
            return;
        }

        if (!string.Equals(password, txtConfirmPassword.Text, StringComparison.Ordinal))
        {
            MessageBox.Show(this, "Mật khẩu xác nhận không khớp.",
                "Mật khẩu chưa khớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtConfirmPassword.Clear();
            txtConfirmPassword.Focus();
            return;
        }

        btnSavePassword.Enabled = false;
        try
        {
            await using var db = new HotelManagementContext();
            var account = await db.TaiKhoans
                .Where(t => t.TenTk == _username && t.DaXoa != true && t.MaNvNavigation!.DaXoa != true)
                .FirstOrDefaultAsync();

            if (account is null)
            {
                _isVerified = false;
                MessageBox.Show(this, "Tài khoản không còn hoạt động. Hãy yêu cầu mã xác nhận mới.",
                    "Không thể đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            account.Password = PasswordHasher.Hash(password);
            await db.SaveChangesAsync();
            _isVerified = false;
            DialogResult = DialogResult.OK;
            MessageBox.Show(this, "Đổi mật khẩu thành công. Bạn có thể đăng nhập bằng mật khẩu mới.",
                "Đã cập nhật mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this,
                "Không thể cập nhật mật khẩu vào cơ sở dữ liệu.\n\n" + ex.GetBaseException().Message,
                "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (!IsDisposed)
            {
                btnSavePassword.Enabled = true;
            }
        }
    }

    private void ResendTimer_Tick(object? sender, EventArgs e) => UpdateResendButton();

    private void UpdateResendButton()
    {
        if (IsDisposed || btnResendCode is null)
        {
            return;
        }

        int secondsLeft = Math.Max(0, (int)Math.Ceiling((_resendAvailableAt - DateTimeOffset.UtcNow).TotalSeconds));
        btnResendCode.Enabled = pnlVerify.Visible && secondsLeft == 0;
        btnResendCode.Text = secondsLeft == 0 ? "Gửi lại mã" : $"Gửi lại mã ({secondsLeft}s)";
    }

    private void InvalidateCode()
    {
        _verificationCode = null;
        _verificationAttempts = 0;
    }

    private static string MaskEmail(string email)
    {
        int separator = email.IndexOf('@');
        if (separator <= 0)
        {
            return "***";
        }

        string localPart = email[..separator];
        string visiblePart = localPart.Length == 1 ? localPart : localPart[..Math.Min(2, localPart.Length)];
        return $"{visiblePart}***{email[separator..]}";
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _resendTimer.Stop();
        _resendTimer.Dispose();
        _verificationCode = null;
        base.OnFormClosed(e);
    }
}
