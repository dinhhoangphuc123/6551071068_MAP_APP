#nullable disable
namespace _6551071068_MAP_APP.Forms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.picDangNhap = new System.Windows.Forms.PictureBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.linkQuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlRight
            //
            this.pnlRight.Controls.Add(this.picDangNhap);
            this.pnlRight.Controls.Add(this.lblTenDangNhap);
            this.pnlRight.Controls.Add(this.lblMatKhau);
            this.pnlRight.Controls.Add(this.txtUsername);
            this.pnlRight.Controls.Add(this.txtPassword);
            this.pnlRight.Controls.Add(this.linkQuenMatKhau);
            this.pnlRight.Controls.Add(this.btnLogin);
            this.pnlRight.BackColor = System.Drawing.Color.Beige;
            this.pnlRight.Location = new System.Drawing.Point(448, 16);
            this.pnlRight.Size = new System.Drawing.Size(395, 531);
            //
            // picDangNhap
            //
            this.picDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("picDangNhap.Image")));
            this.picDangNhap.Location = new System.Drawing.Point(97, 44);
            this.picDangNhap.Size = new System.Drawing.Size(203, 75);
            this.picDangNhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //
            // lblTenDangNhap
            //
            this.lblTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.lblTenDangNhap.Location = new System.Drawing.Point(19, 182);
            this.lblTenDangNhap.Size = new System.Drawing.Size(141, 24);
            this.lblTenDangNhap.Text = "Tên đăng nhập";
            //
            // lblMatKhau
            //
            this.lblMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblMatKhau.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.lblMatKhau.Location = new System.Drawing.Point(62, 265);
            this.lblMatKhau.Size = new System.Drawing.Size(86, 24);
            this.lblMatKhau.Text = "Mật khẩu";
            //
            // txtUsername
            //
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtUsername.Location = new System.Drawing.Point(177, 170);
            this.txtUsername.Size = new System.Drawing.Size(192, 34);
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SubmitOnEnter);
            //
            // txtPassword
            //
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtPassword.Location = new System.Drawing.Point(177, 255);
            this.txtPassword.Size = new System.Drawing.Size(192, 34);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SubmitOnEnter);
            //
            // linkQuenMatKhau
            //
            this.linkQuenMatKhau.AutoSize = true;
            this.linkQuenMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Italic);
            this.linkQuenMatKhau.LinkColor = System.Drawing.Color.Blue;
            this.linkQuenMatKhau.Location = new System.Drawing.Point(222, 328);
            this.linkQuenMatKhau.Text = "Quên mật khẩu";
            this.linkQuenMatKhau.Click += new System.EventHandler(this.LinkQuenMatKhau_Click);
            //
            // btnLogin
            //
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(117, 380);
            this.btnLogin.Size = new System.Drawing.Size(134, 66);
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            //
            // pnlLeft
            //
            this.pnlLeft.Controls.Add(this.picLeft);
            this.pnlLeft.BackColor = System.Drawing.Color.Beige;
            this.pnlLeft.Location = new System.Drawing.Point(-22, 16);
            this.pnlLeft.Size = new System.Drawing.Size(414, 531);
            //
            // picLeft
            //
            this.picLeft.Image = ((System.Drawing.Image)(resources.GetObject("picLeft.Image")));
            this.picLeft.Location = new System.Drawing.Point(-16, 20);
            this.picLeft.Size = new System.Drawing.Size(458, 524);
            this.picLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //
            // LoginForm
            //
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.AcceptButton = this.btnLogin;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(855, 562);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Name = "LoginForm";
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.PictureBox picDangNhap;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.LinkLabel linkQuenMatKhau;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picLeft;
    }
}
