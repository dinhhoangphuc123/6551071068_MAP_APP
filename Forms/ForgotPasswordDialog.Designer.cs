#nullable enable

namespace _6551071068_MAP_APP.Forms;

public sealed partial class ForgotPasswordDialog
{
    private Label lblTitle = null!;
    private Label lblDescription = null!;
    private Label lblStatus = null!;
    private Panel pnlAccount = null!;
    private Panel pnlVerify = null!;
    private Panel pnlReset = null!;
    private Label lblUsername = null!;
    private TextBox txtUsername = null!;
    private Button btnSendCode = null!;
    private Label lblMaskedEmail = null!;
    private Label lblCode = null!;
    private TextBox txtCode = null!;
    private Button btnVerifyCode = null!;
    private Button btnResendCode = null!;
    private Label lblNewPassword = null!;
    private TextBox txtNewPassword = null!;
    private Label lblConfirmPassword = null!;
    private TextBox txtConfirmPassword = null!;
    private Button btnSavePassword = null!;
    private Button btnClose = null!;

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblDescription = new Label();
        lblStatus = new Label();
        pnlAccount = new Panel();
        lblUsername = new Label();
        txtUsername = new TextBox();
        btnSendCode = new Button();
        pnlVerify = new Panel();
        lblMaskedEmail = new Label();
        lblCode = new Label();
        txtCode = new TextBox();
        btnVerifyCode = new Button();
        btnResendCode = new Button();
        pnlReset = new Panel();
        lblNewPassword = new Label();
        txtNewPassword = new TextBox();
        lblConfirmPassword = new Label();
        txtConfirmPassword = new TextBox();
        btnSavePassword = new Button();
        btnClose = new Button();
        pnlAccount.SuspendLayout();
        pnlVerify.SuspendLayout();
        pnlReset.SuspendLayout();
        SuspendLayout();
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Microsoft Sans Serif", 17F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(105, 45, 35);
        lblTitle.Location = new Point(27, 20);
        lblTitle.Text = "Quên mật khẩu";
        //
        // lblDescription
        //
        lblDescription.Location = new Point(30, 61);
        lblDescription.Size = new Size(496, 44);
        lblDescription.Text = "Nhận mã xác nhận qua email nhân viên đã đăng ký, sau đó dùng mã để đặt mật khẩu mới.";
        //
        // pnlAccount
        //
        pnlAccount.BorderStyle = BorderStyle.FixedSingle;
        pnlAccount.Controls.Add(lblUsername);
        pnlAccount.Controls.Add(txtUsername);
        pnlAccount.Controls.Add(btnSendCode);
        pnlAccount.Location = new Point(27, 119);
        pnlAccount.Size = new Size(500, 228);
        //
        // lblUsername
        //
        lblUsername.AutoSize = true;
        lblUsername.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        lblUsername.Location = new Point(24, 28);
        lblUsername.Text = "Tên đăng nhập hoặc email nhân viên";
        //
        // txtUsername
        //
        txtUsername.Font = new Font("Microsoft Sans Serif", 12F);
        txtUsername.Location = new Point(24, 61);
        txtUsername.Size = new Size(448, 30);
        txtUsername.MaxLength = 100;
        txtUsername.KeyDown += AccountInput_KeyDown;
        //
        // btnSendCode
        //
        btnSendCode.BackColor = Color.FromArgb(255, 224, 178);
        btnSendCode.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        btnSendCode.Location = new Point(144, 124);
        btnSendCode.Size = new Size(212, 46);
        btnSendCode.Text = "Gửi mã xác nhận";
        btnSendCode.UseVisualStyleBackColor = false;
        btnSendCode.Click += BtnSendCode_Click;
        //
        // pnlVerify
        //
        pnlVerify.BorderStyle = BorderStyle.FixedSingle;
        pnlVerify.Controls.Add(lblMaskedEmail);
        pnlVerify.Controls.Add(lblCode);
        pnlVerify.Controls.Add(txtCode);
        pnlVerify.Controls.Add(btnVerifyCode);
        pnlVerify.Controls.Add(btnResendCode);
        pnlVerify.Location = new Point(27, 119);
        pnlVerify.Size = new Size(500, 228);
        pnlVerify.Visible = false;
        //
        // lblMaskedEmail
        //
        lblMaskedEmail.Location = new Point(24, 23);
        lblMaskedEmail.Size = new Size(448, 28);
        lblMaskedEmail.Text = "Mã đã được gửi đến";
        //
        // lblCode
        //
        lblCode.AutoSize = true;
        lblCode.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        lblCode.Location = new Point(24, 61);
        lblCode.Text = "Mã xác nhận gồm 6 chữ số";
        //
        // txtCode
        //
        txtCode.Font = new Font("Microsoft Sans Serif", 16F);
        txtCode.Location = new Point(24, 91);
        txtCode.Size = new Size(448, 32);
        txtCode.MaxLength = 6;
        txtCode.TextAlign = HorizontalAlignment.Center;
        txtCode.KeyPress += CodeInput_KeyPress;
        txtCode.KeyDown += CodeInput_KeyDown;
        //
        // btnVerifyCode
        //
        btnVerifyCode.BackColor = Color.FromArgb(255, 224, 178);
        btnVerifyCode.Location = new Point(24, 155);
        btnVerifyCode.Size = new Size(210, 42);
        btnVerifyCode.Text = "Xác nhận mã";
        btnVerifyCode.UseVisualStyleBackColor = false;
        btnVerifyCode.Click += BtnVerifyCode_Click;
        //
        // btnResendCode
        //
        btnResendCode.Location = new Point(260, 155);
        btnResendCode.Size = new Size(212, 42);
        btnResendCode.Text = "Gửi lại mã";
        btnResendCode.Click += BtnResendCode_Click;
        //
        // pnlReset
        //
        pnlReset.BorderStyle = BorderStyle.FixedSingle;
        pnlReset.Controls.Add(lblNewPassword);
        pnlReset.Controls.Add(txtNewPassword);
        pnlReset.Controls.Add(lblConfirmPassword);
        pnlReset.Controls.Add(txtConfirmPassword);
        pnlReset.Controls.Add(btnSavePassword);
        pnlReset.Location = new Point(27, 119);
        pnlReset.Size = new Size(500, 228);
        pnlReset.Visible = false;
        //
        // lblNewPassword
        //
        lblNewPassword.AutoSize = true;
        lblNewPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        lblNewPassword.Location = new Point(24, 24);
        lblNewPassword.Text = "Mật khẩu mới (ít nhất 8 ký tự)";
        //
        // txtNewPassword
        //
        txtNewPassword.Font = new Font("Microsoft Sans Serif", 12F);
        txtNewPassword.Location = new Point(24, 54);
        txtNewPassword.Size = new Size(448, 30);
        txtNewPassword.MaxLength = 1000;
        txtNewPassword.PasswordChar = '*';
        txtNewPassword.KeyDown += PasswordInput_KeyDown;
        //
        // lblConfirmPassword
        //
        lblConfirmPassword.AutoSize = true;
        lblConfirmPassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        lblConfirmPassword.Location = new Point(24, 98);
        lblConfirmPassword.Text = "Nhập lại mật khẩu mới";
        //
        // txtConfirmPassword
        //
        txtConfirmPassword.Font = new Font("Microsoft Sans Serif", 12F);
        txtConfirmPassword.Location = new Point(24, 128);
        txtConfirmPassword.Size = new Size(448, 30);
        txtConfirmPassword.MaxLength = 1000;
        txtConfirmPassword.PasswordChar = '*';
        txtConfirmPassword.KeyDown += PasswordInput_KeyDown;
        //
        // btnSavePassword
        //
        btnSavePassword.BackColor = Color.FromArgb(255, 224, 178);
        btnSavePassword.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        btnSavePassword.Location = new Point(144, 171);
        btnSavePassword.Size = new Size(212, 42);
        btnSavePassword.Text = "Đổi mật khẩu";
        btnSavePassword.UseVisualStyleBackColor = false;
        btnSavePassword.Click += BtnSavePassword_Click;
        //
        // lblStatus
        //
        lblStatus.ForeColor = Color.FromArgb(80, 80, 80);
        lblStatus.Location = new Point(29, 361);
        lblStatus.Size = new Size(497, 42);
        lblStatus.Text = "";
        //
        // btnClose
        //
        btnClose.DialogResult = DialogResult.Cancel;
        btnClose.Location = new Point(206, 414);
        btnClose.Size = new Size(140, 40);
        btnClose.Text = "Đóng";
        btnClose.UseVisualStyleBackColor = true;
        //
        // ForgotPasswordDialog
        //
        AcceptButton = btnSendCode;
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Beige;
        CancelButton = btnClose;
        ClientSize = new Size(556, 476);
        Controls.Add(btnClose);
        Controls.Add(lblStatus);
        Controls.Add(pnlReset);
        Controls.Add(pnlVerify);
        Controls.Add(pnlAccount);
        Controls.Add(lblDescription);
        Controls.Add(lblTitle);
        Font = new Font("Microsoft Sans Serif", 9F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ForgotPasswordDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Quên mật khẩu";
        Shown += ForgotPasswordDialog_Shown;
        pnlAccount.ResumeLayout(false);
        pnlAccount.PerformLayout();
        pnlVerify.ResumeLayout(false);
        pnlVerify.PerformLayout();
        pnlReset.ResumeLayout(false);
        pnlReset.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private void AccountInput_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            btnSendCode.PerformClick();
        }
    }

    private void CodeInput_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void CodeInput_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            btnVerifyCode.PerformClick();
        }
    }

    private void PasswordInput_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            btnSavePassword.PerformClick();
        }
    }
}
