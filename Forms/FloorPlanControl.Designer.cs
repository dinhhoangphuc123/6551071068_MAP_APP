#nullable disable
namespace _6551071068_MAP_APP.Forms
{
    partial class FloorPlanControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloorPlanControl));
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.grpStatus = new System.Windows.Forms.Panel();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.rdoBooked = new System.Windows.Forms.RadioButton();
            this.rdoOccupied = new System.Windows.Forms.RadioButton();
            this.rdoRepair = new System.Windows.Forms.RadioButton();
            this.rdoAllStatus = new System.Windows.Forms.RadioButton();
            this.grpType = new System.Windows.Forms.Panel();
            this.lblTypeTitle = new System.Windows.Forms.Label();
            this.rdoStandardSingle = new System.Windows.Forms.RadioButton();
            this.rdoStandardDouble = new System.Windows.Forms.RadioButton();
            this.rdoVipSingle = new System.Windows.Forms.RadioButton();
            this.rdoVipDouble = new System.Windows.Forms.RadioButton();
            this.rdoAllTypes = new System.Windows.Forms.RadioButton();
            this.grpCleaning = new System.Windows.Forms.Panel();
            this.lblCleaningTitle = new System.Windows.Forms.Label();
            this.rdoClean = new System.Windows.Forms.RadioButton();
            this.rdoNotClean = new System.Windows.Forms.RadioButton();
            this.rdoAllCleaning = new System.Windows.Forms.RadioButton();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblChonNgay = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblChonGio = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.MaPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.pnlFilters.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.grpType.SuspendLayout();
            this.grpCleaning.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlFilters
            //
            this.pnlFilters.Controls.Add(this.grpStatus);
            this.pnlFilters.Controls.Add(this.grpType);
            this.pnlFilters.Controls.Add(this.grpCleaning);
            this.pnlFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(173, 255, 47);
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Size = new System.Drawing.Size(267, 788);
            //
            // grpStatus
            //
            this.grpStatus.Controls.Add(this.lblStatusTitle);
            this.grpStatus.Controls.Add(this.rdoNormal);
            this.grpStatus.Controls.Add(this.rdoBooked);
            this.grpStatus.Controls.Add(this.rdoOccupied);
            this.grpStatus.Controls.Add(this.rdoRepair);
            this.grpStatus.Controls.Add(this.rdoAllStatus);
            this.grpStatus.BackColor = System.Drawing.Color.FromArgb(173, 255, 47);
            this.grpStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpStatus.Location = new System.Drawing.Point(3, 0);
            this.grpStatus.Size = new System.Drawing.Size(255, 279);
            //
            // lblStatusTitle
            //
            this.lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblStatusTitle.ForeColor = System.Drawing.Color.Black;
            this.lblStatusTitle.Location = new System.Drawing.Point(18, 9);
            this.lblStatusTitle.Size = new System.Drawing.Size(225, 31);
            this.lblStatusTitle.Text = "Trạng thái phòng";
            //
            // rdoNormal
            //
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoNormal.ForeColor = System.Drawing.Color.Black;
            this.rdoNormal.Location = new System.Drawing.Point(15, 61);
            this.rdoNormal.Text = "Phòng trống";
            this.rdoNormal.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // rdoBooked
            //
            this.rdoBooked.AutoSize = true;
            this.rdoBooked.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoBooked.ForeColor = System.Drawing.Color.Black;
            this.rdoBooked.Location = new System.Drawing.Point(15, 105);
            this.rdoBooked.Text = "Phòng đã đặt";
            this.rdoBooked.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // rdoOccupied
            //
            this.rdoOccupied.AutoSize = true;
            this.rdoOccupied.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoOccupied.ForeColor = System.Drawing.Color.Black;
            this.rdoOccupied.Location = new System.Drawing.Point(15, 149);
            this.rdoOccupied.Text = "Phòng đang thuê";
            this.rdoOccupied.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // rdoRepair
            //
            this.rdoRepair.AutoSize = true;
            this.rdoRepair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoRepair.ForeColor = System.Drawing.Color.Black;
            this.rdoRepair.Location = new System.Drawing.Point(15, 192);
            this.rdoRepair.Text = "Phòng đang sửa chữa";
            this.rdoRepair.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // rdoAllStatus
            //
            this.rdoAllStatus.AutoSize = true;
            this.rdoAllStatus.Checked = true;
            this.rdoAllStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoAllStatus.ForeColor = System.Drawing.Color.Black;
            this.rdoAllStatus.Location = new System.Drawing.Point(15, 236);
            this.rdoAllStatus.Text = "Tất cả phòng";
            this.rdoAllStatus.TabStop = true;
            this.rdoAllStatus.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // grpType
            //
            this.grpType.Controls.Add(this.lblTypeTitle);
            this.grpType.Controls.Add(this.rdoStandardSingle);
            this.grpType.Controls.Add(this.rdoStandardDouble);
            this.grpType.Controls.Add(this.rdoVipSingle);
            this.grpType.Controls.Add(this.rdoVipDouble);
            this.grpType.Controls.Add(this.rdoAllTypes);
            this.grpType.BackColor = System.Drawing.Color.FromArgb(173, 255, 47);
            this.grpType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpType.Location = new System.Drawing.Point(6, 298);
            this.grpType.Size = new System.Drawing.Size(255, 279);
            //
            // lblTypeTitle
            //
            this.lblTypeTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTypeTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTypeTitle.Location = new System.Drawing.Point(18, 9);
            this.lblTypeTitle.Size = new System.Drawing.Size(225, 31);
            this.lblTypeTitle.Text = "Loại phòng";
            //
            // rdoStandardSingle
            //
            this.rdoStandardSingle.AutoSize = true;
            this.rdoStandardSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoStandardSingle.ForeColor = System.Drawing.Color.Black;
            this.rdoStandardSingle.Location = new System.Drawing.Point(15, 61);
            this.rdoStandardSingle.Text = "Phòng thường đơn";
            this.rdoStandardSingle.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // rdoStandardDouble
            //
            this.rdoStandardDouble.AutoSize = true;
            this.rdoStandardDouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoStandardDouble.ForeColor = System.Drawing.Color.Black;
            this.rdoStandardDouble.Location = new System.Drawing.Point(15, 105);
            this.rdoStandardDouble.Text = "Phòng thường đôi";
            this.rdoStandardDouble.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // rdoVipSingle
            //
            this.rdoVipSingle.AutoSize = true;
            this.rdoVipSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoVipSingle.ForeColor = System.Drawing.Color.Black;
            this.rdoVipSingle.Location = new System.Drawing.Point(15, 149);
            this.rdoVipSingle.Text = "Phòng VIP đơn";
            this.rdoVipSingle.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // rdoVipDouble
            //
            this.rdoVipDouble.AutoSize = true;
            this.rdoVipDouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoVipDouble.ForeColor = System.Drawing.Color.Black;
            this.rdoVipDouble.Location = new System.Drawing.Point(15, 192);
            this.rdoVipDouble.Text = "Phòng VIP đôi";
            this.rdoVipDouble.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // rdoAllTypes
            //
            this.rdoAllTypes.AutoSize = true;
            this.rdoAllTypes.Checked = true;
            this.rdoAllTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoAllTypes.ForeColor = System.Drawing.Color.Black;
            this.rdoAllTypes.Location = new System.Drawing.Point(15, 236);
            this.rdoAllTypes.Text = "Tất cả phòng";
            this.rdoAllTypes.TabStop = true;
            this.rdoAllTypes.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // grpCleaning
            //
            this.grpCleaning.Controls.Add(this.lblCleaningTitle);
            this.grpCleaning.Controls.Add(this.rdoClean);
            this.grpCleaning.Controls.Add(this.rdoNotClean);
            this.grpCleaning.Controls.Add(this.rdoAllCleaning);
            this.grpCleaning.BackColor = System.Drawing.Color.FromArgb(173, 255, 47);
            this.grpCleaning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpCleaning.Location = new System.Drawing.Point(12, 595);
            this.grpCleaning.Size = new System.Drawing.Size(246, 188);
            //
            // lblCleaningTitle
            //
            this.lblCleaningTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCleaningTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCleaningTitle.Location = new System.Drawing.Point(18, 9);
            this.lblCleaningTitle.Size = new System.Drawing.Size(216, 31);
            this.lblCleaningTitle.Text = "Tình trạng dọn dẹp";
            //
            // rdoClean
            //
            this.rdoClean.AutoSize = true;
            this.rdoClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoClean.ForeColor = System.Drawing.Color.Black;
            this.rdoClean.Location = new System.Drawing.Point(15, 61);
            this.rdoClean.Text = "Đã dọn dẹp";
            this.rdoClean.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // rdoNotClean
            //
            this.rdoNotClean.AutoSize = true;
            this.rdoNotClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoNotClean.ForeColor = System.Drawing.Color.Black;
            this.rdoNotClean.Location = new System.Drawing.Point(15, 105);
            this.rdoNotClean.Text = "Chưa dọn dẹp";
            this.rdoNotClean.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // rdoAllCleaning
            //
            this.rdoAllCleaning.AutoSize = true;
            this.rdoAllCleaning.Checked = true;
            this.rdoAllCleaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoAllCleaning.ForeColor = System.Drawing.Color.Black;
            this.rdoAllCleaning.Location = new System.Drawing.Point(15, 149);
            this.rdoAllCleaning.Text = "Tất cả";
            this.rdoAllCleaning.TabStop = true;
            this.rdoAllCleaning.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            //
            // pnlToolbar
            //
            this.pnlToolbar.Controls.Add(this.lblChonNgay);
            this.pnlToolbar.Controls.Add(this.dtpDate);
            this.pnlToolbar.Controls.Add(this.lblChonGio);
            this.pnlToolbar.Controls.Add(this.dtpTime);
            this.pnlToolbar.Controls.Add(this.picSearch);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Controls.Add(this.btnDatPhong);
            this.pnlToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
            this.pnlToolbar.Location = new System.Drawing.Point(274, 0);
            this.pnlToolbar.Size = new System.Drawing.Size(990, 74);
            //
            // lblChonNgay
            //
            this.lblChonNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblChonNgay.Location = new System.Drawing.Point(27, 1);
            this.lblChonNgay.Size = new System.Drawing.Size(200, 20);
            this.lblChonNgay.Text = "Chọn ngày";
            this.lblChonNgay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // dtpDate
            //
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(27, 28);
            this.dtpDate.Size = new System.Drawing.Size(200, 27);
            this.dtpDate.ShowCheckBox = true;
            this.dtpDate.Checked = false;
            this.dtpDate.ValueChanged += new System.EventHandler(this.Filter_Changed);
            //
            // lblChonGio
            //
            this.lblChonGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblChonGio.Location = new System.Drawing.Point(265, 1);
            this.lblChonGio.Size = new System.Drawing.Size(200, 20);
            this.lblChonGio.Text = "Chọn giờ";
            this.lblChonGio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // dtpTime
            //
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(265, 28);
            this.dtpTime.Size = new System.Drawing.Size(200, 27);
            this.dtpTime.ShowUpDown = true;
            //
            // picSearch
            //
            this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
            this.picSearch.Location = new System.Drawing.Point(514, 16);
            this.picSearch.Size = new System.Drawing.Size(30, 40);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            //
            // txtSearch
            //
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSearch.Location = new System.Drawing.Point(554, 21);
            this.txtSearch.Size = new System.Drawing.Size(149, 27);
            this.txtSearch.TextChanged += new System.EventHandler(this.Filter_Changed);
            //
            // btnDatPhong
            //
            this.btnDatPhong.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
            this.btnDatPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.btnDatPhong.ForeColor = System.Drawing.Color.Blue;
            this.btnDatPhong.Location = new System.Drawing.Point(757, 10);
            this.btnDatPhong.Size = new System.Drawing.Size(166, 54);
            this.btnDatPhong.Text = "Đặt phòng";
            this.btnDatPhong.UseVisualStyleBackColor = false;
            this.btnDatPhong.Click += new System.EventHandler(this.BtnDatPhong_Click);
            //
            // dgvRooms
            //
            this.dgvRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.MaPH,
                this.Tang,
                this.TenLPH,
                this.TTPH,
                this.TTDD,
                this.GhiChu
            });
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
            this.dgvRooms.AllowUserToResizeRows = false;
            this.dgvRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvRooms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRooms.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvRooms.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dgvRooms.ColumnHeadersHeight = 35;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRooms.EnableHeadersVisualStyles = true;
            this.dgvRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dgvRooms.GridColor = System.Drawing.SystemColors.ControlDark;
            this.dgvRooms.Location = new System.Drawing.Point(274, 74);
            this.dgvRooms.MultiSelect = false;
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.RowHeadersVisible = false;
            this.dgvRooms.RowTemplate.Height = 24;
            this.dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRooms.Size = new System.Drawing.Size(990, 713);
            //
            // MaPH
            //
            this.MaPH.FillWeight = 90F;
            this.MaPH.HeaderText = "Mã phòng";
            this.MaPH.Name = "MaPH";
            //
            // Tang
            //
            this.Tang.FillWeight = 70F;
            this.Tang.HeaderText = "Tầng";
            this.Tang.Name = "Tang";
            //
            // TenLPH
            //
            this.TenLPH.FillWeight = 120F;
            this.TenLPH.HeaderText = "Loại phòng";
            this.TenLPH.Name = "TenLPH";
            //
            // TTPH
            //
            this.TTPH.FillWeight = 130F;
            this.TTPH.HeaderText = "Trạng thái phòng";
            this.TTPH.Name = "TTPH";
            //
            // TTDD
            //
            this.TTDD.FillWeight = 145F;
            this.TTDD.HeaderText = "Tình trạng dọn dẹp";
            this.TTDD.Name = "TTDD";
            //
            // GhiChu
            //
            this.GhiChu.FillWeight = 110F;
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            //
            // searchTimer
            //
            this.searchTimer.Interval = 300;
            this.searchTimer.Tick += new System.EventHandler(this.SearchTimer_Tick);
            //
            // FloorPlanControl
            //
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.dgvRooms);
            this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
            this.Size = new System.Drawing.Size(1000, 650);
            this.Name = "FloorPlanControl";
            this.Load += new System.EventHandler(this.FloorPlanControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            this.grpCleaning.ResumeLayout(false);
            this.grpCleaning.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel grpStatus;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.RadioButton rdoNormal;
        private System.Windows.Forms.RadioButton rdoBooked;
        private System.Windows.Forms.RadioButton rdoOccupied;
        private System.Windows.Forms.RadioButton rdoRepair;
        private System.Windows.Forms.RadioButton rdoAllStatus;
        private System.Windows.Forms.Panel grpType;
        private System.Windows.Forms.Label lblTypeTitle;
        private System.Windows.Forms.RadioButton rdoStandardSingle;
        private System.Windows.Forms.RadioButton rdoStandardDouble;
        private System.Windows.Forms.RadioButton rdoVipSingle;
        private System.Windows.Forms.RadioButton rdoVipDouble;
        private System.Windows.Forms.RadioButton rdoAllTypes;
        private System.Windows.Forms.Panel grpCleaning;
        private System.Windows.Forms.Label lblCleaningTitle;
        private System.Windows.Forms.RadioButton rdoClean;
        private System.Windows.Forms.RadioButton rdoNotClean;
        private System.Windows.Forms.RadioButton rdoAllCleaning;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblChonNgay;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblChonGio;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.Timer searchTimer;
    }
}
