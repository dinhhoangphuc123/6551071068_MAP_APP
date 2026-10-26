#nullable disable
namespace _6551071068_MAP_APP.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.linkDangXuat = new System.Windows.Forms.LinkLabel();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.btnSoDoPhong = new System.Windows.Forms.Button();
            this.btnPhong = new System.Windows.Forms.Button();
            this.btnLoaiPhong = new System.Windows.Forms.Button();
            this.btnDanhSachDatPhong = new System.Windows.Forms.Button();
            this.btnDanhSachHoaDon = new System.Windows.Forms.Button();
            this.btnDanhSachDichVu = new System.Windows.Forms.Button();
            this.btnDanhSachTienNghi = new System.Windows.Forms.Button();
            this.btnDanhSachKhachHang = new System.Windows.Forms.Button();
            this.btnDanhSachNhanVien = new System.Windows.Forms.Button();
            this.btnDanhSachTaiKhoan = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
            this.pnlHeader.Location = new System.Drawing.Point(0, 4);
            this.pnlHeader.Size = new System.Drawing.Size(1180, 74);
            //
            // picLogo
            //
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(3, 4);
            this.picLogo.Size = new System.Drawing.Size(48, 78);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.LightSalmon;
            this.lblTitle.Location = new System.Drawing.Point(66, 19);
            this.lblTitle.Text = "Hotel Management";
            //
            // pnlProfile
            //
            this.pnlProfile.Controls.Add(this.linkDangXuat);
            this.pnlProfile.Controls.Add(this.picUser);
            this.pnlProfile.Controls.Add(this.lblUser);
            this.pnlProfile.BackColor = System.Drawing.Color.FromArgb(60, 179, 113);
            this.pnlProfile.Location = new System.Drawing.Point(0, 94);
            this.pnlProfile.Size = new System.Drawing.Size(304, 198);
            //
            // linkDangXuat
            //
            this.linkDangXuat.ActiveLinkColor = System.Drawing.Color.DarkBlue;
            this.linkDangXuat.AutoSize = true;
            this.linkDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.linkDangXuat.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkDangXuat.Location = new System.Drawing.Point(4, 11);
            this.linkDangXuat.Text = "Đăng xuất";
            this.linkDangXuat.Click += new System.EventHandler(this.Logout_Click);
            //
            // picUser
            //
            this.picUser.Image = ((System.Drawing.Image)(resources.GetObject("picUser.Image")));
            this.picUser.Location = new System.Drawing.Point(101, 48);
            this.picUser.Size = new System.Drawing.Size(87, 108);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //
            // lblUser
            //
            this.lblUser.AutoSize = false;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(8, 155);
            this.lblUser.Size = new System.Drawing.Size(288, 28);
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // pnlNav
            //
            this.pnlNav.Controls.Add(this.btnTrangChu);
            this.pnlNav.Controls.Add(this.btnSoDoPhong);
            this.pnlNav.Controls.Add(this.btnPhong);
            this.pnlNav.Controls.Add(this.btnLoaiPhong);
            this.pnlNav.Controls.Add(this.btnDanhSachDatPhong);
            this.pnlNav.Controls.Add(this.btnDanhSachHoaDon);
            this.pnlNav.Controls.Add(this.btnDanhSachDichVu);
            this.pnlNav.Controls.Add(this.btnDanhSachTienNghi);
            this.pnlNav.Controls.Add(this.btnDanhSachKhachHang);
            this.pnlNav.Controls.Add(this.btnDanhSachNhanVien);
            this.pnlNav.Controls.Add(this.btnDanhSachTaiKhoan);
            this.pnlNav.Controls.Add(this.btnThongKe);
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.pnlNav.Location = new System.Drawing.Point(0, 289);
            this.pnlNav.Size = new System.Drawing.Size(304, 1161);
            //
            // btnTrangChu
            //
            this.btnTrangChu.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnTrangChu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrangChu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTrangChu.FlatAppearance.BorderSize = 1;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnTrangChu.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangChu.Image")));
            this.btnTrangChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.Location = new System.Drawing.Point(0, 0);
            this.btnTrangChu.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnTrangChu.Size = new System.Drawing.Size(304, 69);
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrangChu.UseVisualStyleBackColor = false;
            this.btnTrangChu.Click += new System.EventHandler(this.BtnTrangChu_Click);
            //
            // btnSoDoPhong
            //
            this.btnSoDoPhong.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnSoDoPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSoDoPhong.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSoDoPhong.FlatAppearance.BorderSize = 1;
            this.btnSoDoPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoDoPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnSoDoPhong.ForeColor = System.Drawing.Color.White;
            this.btnSoDoPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnSoDoPhong.Image")));
            this.btnSoDoPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoDoPhong.Location = new System.Drawing.Point(0, 69);
            this.btnSoDoPhong.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnSoDoPhong.Size = new System.Drawing.Size(304, 58);
            this.btnSoDoPhong.Text = "Sơ đồ phòng";
            this.btnSoDoPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoDoPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSoDoPhong.UseVisualStyleBackColor = false;
            this.btnSoDoPhong.Click += new System.EventHandler(this.BtnSoDoPhong_Click);
            //
            // btnPhong
            //
            this.btnPhong.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhong.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPhong.FlatAppearance.BorderSize = 1;
            this.btnPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnPhong.ForeColor = System.Drawing.Color.White;
            this.btnPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnPhong.Image")));
            this.btnPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhong.Location = new System.Drawing.Point(0, 127);
            this.btnPhong.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnPhong.Size = new System.Drawing.Size(304, 58);
            this.btnPhong.Text = "Phòng";
            this.btnPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPhong.UseVisualStyleBackColor = false;
            this.btnPhong.Click += new System.EventHandler(this.BtnPhong_Click);
            //
            // btnLoaiPhong
            //
            this.btnLoaiPhong.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnLoaiPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoaiPhong.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLoaiPhong.FlatAppearance.BorderSize = 1;
            this.btnLoaiPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoaiPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnLoaiPhong.ForeColor = System.Drawing.Color.White;
            this.btnLoaiPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnLoaiPhong.Image")));
            this.btnLoaiPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoaiPhong.Location = new System.Drawing.Point(0, 185);
            this.btnLoaiPhong.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnLoaiPhong.Size = new System.Drawing.Size(304, 58);
            this.btnLoaiPhong.Text = "Loại phòng";
            this.btnLoaiPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoaiPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoaiPhong.UseVisualStyleBackColor = false;
            this.btnLoaiPhong.Click += new System.EventHandler(this.BtnLoaiPhong_Click);
            //
            // btnDanhSachDatPhong
            //
            this.btnDanhSachDatPhong.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnDanhSachDatPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhSachDatPhong.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDanhSachDatPhong.FlatAppearance.BorderSize = 1;
            this.btnDanhSachDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhSachDatPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnDanhSachDatPhong.ForeColor = System.Drawing.Color.White;
            this.btnDanhSachDatPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhSachDatPhong.Image")));
            this.btnDanhSachDatPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachDatPhong.Location = new System.Drawing.Point(0, 243);
            this.btnDanhSachDatPhong.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnDanhSachDatPhong.Size = new System.Drawing.Size(304, 58);
            this.btnDanhSachDatPhong.Text = "Danh sách đặt phòng";
            this.btnDanhSachDatPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachDatPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDanhSachDatPhong.UseVisualStyleBackColor = false;
            this.btnDanhSachDatPhong.Click += new System.EventHandler(this.NavPlaceholder_Click);
            //
            // btnDanhSachHoaDon
            //
            this.btnDanhSachHoaDon.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnDanhSachHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhSachHoaDon.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDanhSachHoaDon.FlatAppearance.BorderSize = 1;
            this.btnDanhSachHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhSachHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnDanhSachHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnDanhSachHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhSachHoaDon.Image")));
            this.btnDanhSachHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachHoaDon.Location = new System.Drawing.Point(0, 301);
            this.btnDanhSachHoaDon.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnDanhSachHoaDon.Size = new System.Drawing.Size(304, 58);
            this.btnDanhSachHoaDon.Text = "Danh sách hóa đơn";
            this.btnDanhSachHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDanhSachHoaDon.UseVisualStyleBackColor = false;
            this.btnDanhSachHoaDon.Click += new System.EventHandler(this.NavPlaceholder_Click);
            //
            // btnDanhSachDichVu
            //
            this.btnDanhSachDichVu.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnDanhSachDichVu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhSachDichVu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDanhSachDichVu.FlatAppearance.BorderSize = 1;
            this.btnDanhSachDichVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhSachDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnDanhSachDichVu.ForeColor = System.Drawing.Color.White;
            this.btnDanhSachDichVu.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhSachDichVu.Image")));
            this.btnDanhSachDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachDichVu.Location = new System.Drawing.Point(0, 359);
            this.btnDanhSachDichVu.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnDanhSachDichVu.Size = new System.Drawing.Size(304, 58);
            this.btnDanhSachDichVu.Text = "Danh sách dịch vụ";
            this.btnDanhSachDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachDichVu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDanhSachDichVu.UseVisualStyleBackColor = false;
            this.btnDanhSachDichVu.Click += new System.EventHandler(this.NavPlaceholder_Click);
            //
            // btnDanhSachTienNghi
            //
            this.btnDanhSachTienNghi.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnDanhSachTienNghi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhSachTienNghi.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDanhSachTienNghi.FlatAppearance.BorderSize = 1;
            this.btnDanhSachTienNghi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhSachTienNghi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnDanhSachTienNghi.ForeColor = System.Drawing.Color.White;
            this.btnDanhSachTienNghi.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhSachTienNghi.Image")));
            this.btnDanhSachTienNghi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachTienNghi.Location = new System.Drawing.Point(0, 417);
            this.btnDanhSachTienNghi.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnDanhSachTienNghi.Size = new System.Drawing.Size(304, 58);
            this.btnDanhSachTienNghi.Text = "Danh sách tiện nghi";
            this.btnDanhSachTienNghi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachTienNghi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDanhSachTienNghi.UseVisualStyleBackColor = false;
            this.btnDanhSachTienNghi.Click += new System.EventHandler(this.NavPlaceholder_Click);
            //
            // btnDanhSachKhachHang
            //
            this.btnDanhSachKhachHang.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnDanhSachKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhSachKhachHang.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDanhSachKhachHang.FlatAppearance.BorderSize = 1;
            this.btnDanhSachKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhSachKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnDanhSachKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnDanhSachKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhSachKhachHang.Image")));
            this.btnDanhSachKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachKhachHang.Location = new System.Drawing.Point(0, 475);
            this.btnDanhSachKhachHang.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnDanhSachKhachHang.Size = new System.Drawing.Size(304, 58);
            this.btnDanhSachKhachHang.Text = "Danh sách khách hàng";
            this.btnDanhSachKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDanhSachKhachHang.UseVisualStyleBackColor = false;
            this.btnDanhSachKhachHang.Click += new System.EventHandler(this.NavPlaceholder_Click);
            //
            // btnDanhSachNhanVien
            //
            this.btnDanhSachNhanVien.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnDanhSachNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhSachNhanVien.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDanhSachNhanVien.FlatAppearance.BorderSize = 1;
            this.btnDanhSachNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhSachNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnDanhSachNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnDanhSachNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhSachNhanVien.Image")));
            this.btnDanhSachNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachNhanVien.Location = new System.Drawing.Point(0, 533);
            this.btnDanhSachNhanVien.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnDanhSachNhanVien.Size = new System.Drawing.Size(304, 58);
            this.btnDanhSachNhanVien.Text = "Danh sách nhân viên";
            this.btnDanhSachNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDanhSachNhanVien.UseVisualStyleBackColor = false;
            this.btnDanhSachNhanVien.Click += new System.EventHandler(this.NavPlaceholder_Click);
            //
            // btnDanhSachTaiKhoan
            //
            this.btnDanhSachTaiKhoan.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnDanhSachTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhSachTaiKhoan.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDanhSachTaiKhoan.FlatAppearance.BorderSize = 1;
            this.btnDanhSachTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhSachTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnDanhSachTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnDanhSachTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhSachTaiKhoan.Image")));
            this.btnDanhSachTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachTaiKhoan.Location = new System.Drawing.Point(0, 591);
            this.btnDanhSachTaiKhoan.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnDanhSachTaiKhoan.Size = new System.Drawing.Size(304, 58);
            this.btnDanhSachTaiKhoan.Text = "Danh sách tài khoản";
            this.btnDanhSachTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachTaiKhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDanhSachTaiKhoan.UseVisualStyleBackColor = false;
            this.btnDanhSachTaiKhoan.Click += new System.EventHandler(this.NavPlaceholder_Click);
            //
            // btnThongKe
            //
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnThongKe.FlatAppearance.BorderSize = 1;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(0, 649);
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(15, 0, 4, 0);
            this.btnThongKe.Size = new System.Drawing.Size(304, 58);
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.NavPlaceholder_Click);
            //
            // pnlMainContent
            //
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            // pnlSidebar
            //
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(0, 139, 139);
            this.pnlSidebar.Controls.Add(this.pnlNav);
            this.pnlSidebar.Controls.Add(this.pnlProfile);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Size = new System.Drawing.Size(235, 646);
            //
            // pnlHeader responsive row
            //
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 74;
            this.pnlProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProfile.Height = 142;
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNav.AutoScroll = false;
            //
            // MainForm
            //
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.AutoScroll = false;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Name = "MainForm";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlProfile.ResumeLayout(false);
            this.pnlProfile.PerformLayout();
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlProfile;
        private System.Windows.Forms.LinkLabel linkDangXuat;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnSoDoPhong;
        private System.Windows.Forms.Button btnPhong;
        private System.Windows.Forms.Button btnLoaiPhong;
        private System.Windows.Forms.Button btnDanhSachDatPhong;
        private System.Windows.Forms.Button btnDanhSachHoaDon;
        private System.Windows.Forms.Button btnDanhSachDichVu;
        private System.Windows.Forms.Button btnDanhSachTienNghi;
        private System.Windows.Forms.Button btnDanhSachKhachHang;
        private System.Windows.Forms.Button btnDanhSachNhanVien;
        private System.Windows.Forms.Button btnDanhSachTaiKhoan;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Panel pnlMainContent;
    }
}
