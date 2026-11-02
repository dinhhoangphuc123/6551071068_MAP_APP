namespace HotelManagement.SoDoPhong
{
    partial class FormDatPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label6 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            cbGioiTinh = new ComboBox();
            label7 = new Label();
            txtSoDienThoai = new TextBox();
            label3 = new Label();
            txtQuocTich = new TextBox();
            label2 = new Label();
            txtCCCD = new TextBox();
            label1 = new Label();
            txtHoVaTen = new TextBox();
            label5 = new Label();
            panel2 = new Panel();
            label14 = new Label();
            label13 = new Label();
            dtgDanhSachPhongDaChon = new DataGridView();
            dtgDanhSachPhongTrong = new DataGridView();
            cbDangGioDi = new ComboBox();
            cbGioDi = new ComboBox();
            cbDangGioDen = new ComboBox();
            cbGioDen = new ComboBox();
            label12 = new Label();
            label11 = new Label();
            dtpNgayKT = new DateTimePicker();
            dtpNgayBD = new DateTimePicker();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            btnDatPhong = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachPhongDaChon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachPhongTrong).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(192, 0, 192);
            label6.Location = new Point(515, 9);
            label6.Name = "label6";
            label6.Size = new Size(138, 29);
            label6.TabIndex = 22;
            label6.Text = "Đặt phòng";
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbGioiTinh);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtSoDienThoai);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtQuocTich);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtCCCD);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtHoVaTen);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(12, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(465, 413);
            panel1.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(192, 0, 0);
            label4.Location = new Point(119, 23);
            label4.Name = "label4";
            label4.Size = new Size(276, 29);
            label4.TabIndex = 24;
            label4.Text = "Thông tin khách hàng";
            // 
            // cbGioiTinh
            // 
            cbGioiTinh.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbGioiTinh.FormattingEnabled = true;
            cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cbGioiTinh.Location = new Point(236, 288);
            cbGioiTinh.Name = "cbGioiTinh";
            cbGioiTinh.Size = new Size(199, 30);
            cbGioiTinh.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(68, 191);
            label7.Name = "label7";
            label7.Size = new Size(139, 26);
            label7.TabIndex = 24;
            label7.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoDienThoai.Location = new Point(236, 187);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(199, 30);
            txtSoDienThoai.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(115, 292);
            label3.Name = "label3";
            label3.Size = new Size(92, 26);
            label3.TabIndex = 22;
            label3.Text = "Giới tính";
            // 
            // txtQuocTich
            // 
            txtQuocTich.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuocTich.Location = new Point(236, 240);
            txtQuocTich.Name = "txtQuocTich";
            txtQuocTich.Size = new Size(199, 30);
            txtQuocTich.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(109, 240);
            label2.Name = "label2";
            label2.Size = new Size(104, 26);
            label2.TabIndex = 20;
            label2.Text = "Quốc tịch";
            // 
            // txtCCCD
            // 
            txtCCCD.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCCCD.Location = new Point(236, 135);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(199, 30);
            txtCCCD.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(-1, 137);
            label1.Name = "label1";
            label1.Size = new Size(201, 26);
            label1.TabIndex = 18;
            label1.Text = "Số CCCD/Passport";
            // 
            // txtHoVaTen
            // 
            txtHoVaTen.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHoVaTen.Location = new Point(236, 87);
            txtHoVaTen.Name = "txtHoVaTen";
            txtHoVaTen.Size = new Size(199, 30);
            txtHoVaTen.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(89, 89);
            label5.Name = "label5";
            label5.Size = new Size(105, 26);
            label5.TabIndex = 16;
            label5.Text = "Họ và tên";
            // 
            // panel2
            // 
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(dtgDanhSachPhongDaChon);
            panel2.Controls.Add(dtgDanhSachPhongTrong);
            panel2.Controls.Add(cbDangGioDi);
            panel2.Controls.Add(cbGioDi);
            panel2.Controls.Add(cbDangGioDen);
            panel2.Controls.Add(cbGioDen);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(dtpNgayKT);
            panel2.Controls.Add(dtpNgayBD);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(483, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(796, 521);
            panel2.TabIndex = 26;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Green;
            label14.Location = new Point(440, 199);
            label14.Name = "label14";
            label14.Size = new Size(331, 29);
            label14.TabIndex = 38;
            label14.Text = "Danh sách phòng đã chọn";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Green;
            label13.Location = new Point(43, 199);
            label13.Name = "label13";
            label13.Size = new Size(296, 29);
            label13.TabIndex = 26;
            label13.Text = "Danh sách phòng trống";
            // 
            // dtgDanhSachPhongDaChon
            // 
            dtgDanhSachPhongDaChon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachPhongDaChon.Location = new Point(396, 235);
            dtgDanhSachPhongDaChon.Name = "dtgDanhSachPhongDaChon";
            dtgDanhSachPhongDaChon.RowHeadersWidth = 51;
            dtgDanhSachPhongDaChon.RowTemplate.Height = 24;
            dtgDanhSachPhongDaChon.Size = new Size(397, 276);
            dtgDanhSachPhongDaChon.TabIndex = 37;
            dtgDanhSachPhongDaChon.CellClick += dtgDanhSachPhongDaChon_CellClick;
            // 
            // dtgDanhSachPhongTrong
            // 
            dtgDanhSachPhongTrong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachPhongTrong.Location = new Point(3, 235);
            dtgDanhSachPhongTrong.Name = "dtgDanhSachPhongTrong";
            dtgDanhSachPhongTrong.RowHeadersWidth = 51;
            dtgDanhSachPhongTrong.RowTemplate.Height = 24;
            dtgDanhSachPhongTrong.Size = new Size(373, 276);
            dtgDanhSachPhongTrong.TabIndex = 36;
            dtgDanhSachPhongTrong.CellClick += dtgDanhSachPhongTrong_CellClick;
            // 
            // cbDangGioDi
            // 
            cbDangGioDi.FormattingEnabled = true;
            cbDangGioDi.Items.AddRange(new object[] { "AM", "PM" });
            cbDangGioDi.Location = new Point(634, 138);
            cbDangGioDi.Name = "cbDangGioDi";
            cbDangGioDi.Size = new Size(55, 24);
            cbDangGioDi.TabIndex = 35;
            // 
            // cbGioDi
            // 
            cbGioDi.FormattingEnabled = true;
            cbGioDi.Items.AddRange(new object[] {
                "01:00", "01:30", "02:00", "02:30", "03:00", "03:30",
                "04:00", "04:30", "05:00", "05:30", "06:00", "06:30",
                "07:00", "07:30", "08:00", "08:30", "09:00", "09:30",
                "10:00", "10:30", "11:00", "11:30", "12:00", "12:30"
            });
            cbGioDi.Location = new Point(536, 138);
            cbGioDi.Name = "cbGioDi";
            cbGioDi.Size = new Size(101, 24);
            cbGioDi.TabIndex = 34;
            // 
            // cbDangGioDen
            // 
            cbDangGioDen.FormattingEnabled = true;
            cbDangGioDen.Items.AddRange(new object[] { "AM", "PM" });
            cbDangGioDen.Location = new Point(634, 69);
            cbDangGioDen.Name = "cbDangGioDen";
            cbDangGioDen.Size = new Size(55, 24);
            cbDangGioDen.TabIndex = 33;
            // 
            // cbGioDen
            // 
            cbGioDen.FormattingEnabled = true;
            cbGioDen.Items.AddRange(new object[] {
                "01:00", "01:30", "02:00", "02:30", "03:00", "03:30",
                "04:00", "04:30", "05:00", "05:30", "06:00", "06:30",
                "07:00", "07:30", "08:00", "08:30", "09:00", "09:30",
                "10:00", "10:30", "11:00", "11:30", "12:00", "12:30"
            });
            cbGioDen.Location = new Point(536, 69);
            cbGioDen.Name = "cbGioDen";
            cbGioDen.Size = new Size(101, 24);
            cbGioDen.TabIndex = 32;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(463, 138);
            label12.Name = "label12";
            label12.Size = new Size(53, 20);
            label12.TabIndex = 31;
            label12.Text = "Giờ đi";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(463, 72);
            label11.Name = "label11";
            label11.Size = new Size(67, 20);
            label11.TabIndex = 30;
            label11.Text = "Giờ đến";
            // 
            // dtpNgayKT
            // 
            dtpNgayKT.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgayKT.Location = new Point(145, 133);
            dtpNgayKT.Name = "dtpNgayKT";
            dtpNgayKT.Size = new Size(267, 26);
            dtpNgayKT.TabIndex = 29;
            // 
            // dtpNgayBD
            // 
            dtpNgayBD.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgayBD.Location = new Point(145, 67);
            dtpNgayBD.Name = "dtpNgayBD";
            dtpNgayBD.Size = new Size(267, 26);
            dtpNgayBD.TabIndex = 28;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(32, 133);
            label10.Name = "label10";
            label10.Size = new Size(111, 20);
            label10.TabIndex = 27;
            label10.Text = "Ngày kết thúc";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(32, 72);
            label9.Name = "label9";
            label9.Size = new Size(107, 20);
            label9.TabIndex = 26;
            label9.Text = "Ngày bắt đầu";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(192, 0, 0);
            label8.Location = new Point(306, 8);
            label8.Name = "label8";
            label8.Size = new Size(210, 29);
            label8.TabIndex = 24;
            label8.Text = "Thông tin phòng";
            // 
            // btnDatPhong
            // 
            btnDatPhong.BackColor = SystemColors.ActiveCaption;
            btnDatPhong.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatPhong.ForeColor = Color.ForestGreen;
            btnDatPhong.Location = new Point(45, 496);
            btnDatPhong.Name = "btnDatPhong";
            btnDatPhong.Size = new Size(167, 42);
            btnDatPhong.TabIndex = 27;
            btnDatPhong.Text = "Đặt trước";
            btnDatPhong.UseVisualStyleBackColor = false;
            btnDatPhong.Click += btnDatPhong_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(227, 496);
            button2.Name = "button2";
            button2.Size = new Size(129, 42);
            button2.TabIndex = 28;
            button2.Text = "Hủy";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormDatPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1291, 575);
            Controls.Add(button2);
            Controls.Add(btnDatPhong);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label6);
            Name = "FormDatPhong";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đặt phòng trước";
            Load += FormDatPhong_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachPhongDaChon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachPhongTrong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuocTich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoVaTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbDangGioDi;
        private System.Windows.Forms.ComboBox cbGioDi;
        private System.Windows.Forms.ComboBox cbDangGioDen;
        private System.Windows.Forms.ComboBox cbGioDen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dtgDanhSachPhongDaChon;
        private System.Windows.Forms.DataGridView dtgDanhSachPhongTrong;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}

