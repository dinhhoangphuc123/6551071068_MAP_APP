#nullable disable
namespace _6551071068_MAP_APP.Forms
{
    partial class RoomTypeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomTypeControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRoomTypes = new System.Windows.Forms.DataGridView();
            this.IconLoaiPhong = new System.Windows.Forms.DataGridViewImageColumn();
            this.MaLPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGiuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNguoiToiDa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaGio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienNghi = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSua = new System.Windows.Forms.DataGridViewImageColumn();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomTypes)).BeginInit();
            this.SuspendLayout();
            //
            // dgvRoomTypes
            //
            this.dgvRoomTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.IconLoaiPhong,
                this.MaLPH,
                this.TenLPH,
                this.SoGiuong,
                this.SoNguoiToiDa,
                this.GiaNgay,
                this.GiaGio,
                this.colTienNghi,
                this.colSua
            });
            this.dgvRoomTypes.AllowUserToAddRows = false;
            this.dgvRoomTypes.AllowUserToDeleteRows = false;
            this.dgvRoomTypes.AllowUserToResizeRows = false;
            this.dgvRoomTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRoomTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoomTypes.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvRoomTypes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRoomTypes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvRoomTypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dgvRoomTypes.ColumnHeadersHeight = 35;
            this.dgvRoomTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoomTypes.EnableHeadersVisualStyles = true;
            this.dgvRoomTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dgvRoomTypes.GridColor = System.Drawing.SystemColors.ControlDark;
            this.dgvRoomTypes.Location = new System.Drawing.Point(12, 66);
            this.dgvRoomTypes.MultiSelect = false;
            this.dgvRoomTypes.ReadOnly = true;
            this.dgvRoomTypes.RowHeadersVisible = false;
            this.dgvRoomTypes.RowTemplate.Height = 40;
            this.dgvRoomTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoomTypes.Size = new System.Drawing.Size(924, 605);
            this.dgvRoomTypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            this.dgvRoomTypes.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvRoomTypes_DataBindingComplete);
            //
            // IconLoaiPhong
            //
            this.IconLoaiPhong.Description = "Hình loại phòng";
            this.IconLoaiPhong.FillWeight = 35F;
            this.IconLoaiPhong.HeaderText = "";
            this.IconLoaiPhong.Image = ((System.Drawing.Image)(resources.GetObject("IconLoaiPhong.Image")));
            this.IconLoaiPhong.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.IconLoaiPhong.Name = "IconLoaiPhong";
            this.IconLoaiPhong.ValuesAreIcons = false;
            //
            // MaLPH
            //
            this.MaLPH.DataPropertyName = "MaLPH";
            this.MaLPH.FillWeight = 80F;
            this.MaLPH.HeaderText = "Mã loại phòng";
            this.MaLPH.Name = "MaLPH";
            //
            // TenLPH
            //
            this.TenLPH.DataPropertyName = "TenLPH";
            this.TenLPH.FillWeight = 110F;
            this.TenLPH.HeaderText = "Tên loại phòng";
            this.TenLPH.Name = "TenLPH";
            //
            // SoGiuong
            //
            this.SoGiuong.DataPropertyName = "SoGiuong";
            this.SoGiuong.FillWeight = 70F;
            this.SoGiuong.HeaderText = "Số giường";
            this.SoGiuong.Name = "SoGiuong";
            //
            // SoNguoiToiDa
            //
            this.SoNguoiToiDa.DataPropertyName = "SoNguoiToiDa";
            this.SoNguoiToiDa.FillWeight = 90F;
            this.SoNguoiToiDa.HeaderText = "Số người tối đa";
            this.SoNguoiToiDa.Name = "SoNguoiToiDa";
            //
            // GiaNgay
            //
            this.GiaNgay.DataPropertyName = "GiaNgay";
            this.GiaNgay.FillWeight = 90F;
            this.GiaNgay.HeaderText = "Giá ngày";
            this.GiaNgay.Name = "GiaNgay";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.GiaNgay.DefaultCellStyle = dataGridViewCellStyle1;
            //
            // GiaGio
            //
            this.GiaGio.DataPropertyName = "GiaGio";
            this.GiaGio.FillWeight = 90F;
            this.GiaGio.HeaderText = "Giá giờ";
            this.GiaGio.Name = "GiaGio";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.GiaGio.DefaultCellStyle = dataGridViewCellStyle2;
            //
            // colTienNghi
            //
            this.colTienNghi.Description = "Chi tiết tiện nghi";
            this.colTienNghi.FillWeight = 50F;
            this.colTienNghi.HeaderText = "Tiện nghi";
            this.colTienNghi.Image = ((System.Drawing.Image)(resources.GetObject("colTienNghi.Image")));
            this.colTienNghi.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colTienNghi.Name = "colTienNghi";
            this.colTienNghi.ValuesAreIcons = false;
            //
            // colSua
            //
            this.colSua.Description = "Cập nhật loại phòng";
            this.colSua.FillWeight = 55F;
            this.colSua.HeaderText = "Cập nhật";
            this.colSua.Image = ((System.Drawing.Image)(resources.GetObject("colSua.Image")));
            this.colSua.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colSua.Name = "colSua";
            this.colSua.ValuesAreIcons = false;
            //
            // picSearch
            //
            this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
            this.picSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.picSearch.Location = new System.Drawing.Point(60, 12);
            this.picSearch.Size = new System.Drawing.Size(39, 37);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            //
            // txtSearch
            //
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtSearch.Location = new System.Drawing.Point(105, 17);
            this.txtSearch.Size = new System.Drawing.Size(187, 32);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            //
            // btnExport
            //
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Location = new System.Drawing.Point(546, 12);
            this.btnExport.Size = new System.Drawing.Size(167, 37);
            this.btnExport.Text = "Xuất file Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.ExportExcel_Click);
            //
            // btnAdd
            //
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.LightPink;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(747, 12);
            this.btnAdd.Size = new System.Drawing.Size(167, 37);
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            //
            // searchTimer
            //
            this.searchTimer.Interval = 300;
            this.searchTimer.Tick += new System.EventHandler(this.SearchTimer_Tick);
            //
            // RoomTypeControl
            //
            this.Controls.Add(this.dgvRoomTypes);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnAdd);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Size = new System.Drawing.Size(948, 683);
            this.Name = "RoomTypeControl";
            this.Load += new System.EventHandler(this.RoomTypeControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoomTypes;
        private System.Windows.Forms.DataGridViewImageColumn IconLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGiuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNguoiToiDa;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaGio;
        private System.Windows.Forms.DataGridViewImageColumn colTienNghi;
        private System.Windows.Forms.DataGridViewImageColumn colSua;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Timer searchTimer;
    }
}
