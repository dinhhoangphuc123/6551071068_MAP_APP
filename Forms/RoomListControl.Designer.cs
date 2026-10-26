#nullable disable
namespace _6551071068_MAP_APP.Forms
{
    partial class RoomListControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomListControl));
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.IconPhong = new System.Windows.Forms.DataGridViewImageColumn();
            this.MaPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSua = new System.Windows.Forms.DataGridViewImageColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewImageColumn();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.SuspendLayout();
            //
            // dgvRooms
            //
            this.dgvRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.IconPhong,
                this.MaPH,
                this.TTPH,
                this.TTDD,
                this.TenLPH,
                this.GhiChu,
                this.colSua,
                this.colXoa
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
            this.dgvRooms.Location = new System.Drawing.Point(12, 72);
            this.dgvRooms.MultiSelect = false;
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.RowHeadersVisible = false;
            this.dgvRooms.RowTemplate.Height = 40;
            this.dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRooms.Size = new System.Drawing.Size(1015, 615);
            this.dgvRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            this.dgvRooms.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvRooms_DataBindingComplete);
            //
            // IconPhong
            //
            this.IconPhong.Description = "Hình phòng";
            this.IconPhong.FillWeight = 30F;
            this.IconPhong.HeaderText = "";
            this.IconPhong.Image = ((System.Drawing.Image)(resources.GetObject("IconPhong.Image")));
            this.IconPhong.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.IconPhong.Name = "IconPhong";
            this.IconPhong.ValuesAreIcons = false;
            //
            // MaPH
            //
            this.MaPH.DataPropertyName = "MaPH";
            this.MaPH.FillWeight = 72F;
            this.MaPH.HeaderText = "Mã phòng";
            this.MaPH.Name = "MaPH";
            //
            // TTPH
            //
            this.TTPH.DataPropertyName = "TTPH";
            this.TTPH.FillWeight = 120F;
            this.TTPH.HeaderText = "Tình trạng phòng";
            this.TTPH.Name = "TTPH";
            //
            // TTDD
            //
            this.TTDD.DataPropertyName = "TTDD";
            this.TTDD.FillWeight = 115F;
            this.TTDD.HeaderText = "Dọn dẹp";
            this.TTDD.Name = "TTDD";
            //
            // TenLPH
            //
            this.TenLPH.DataPropertyName = "TenLPH";
            this.TenLPH.FillWeight = 100F;
            this.TenLPH.HeaderText = "Loại phòng";
            this.TenLPH.Name = "TenLPH";
            //
            // GhiChu
            //
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.FillWeight = 100F;
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            //
            // colSua
            //
            this.colSua.Description = "Cập nhật phòng";
            this.colSua.FillWeight = 35F;
            this.colSua.HeaderText = "Sửa";
            this.colSua.Image = ((System.Drawing.Image)(resources.GetObject("colSua.Image")));
            this.colSua.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colSua.Name = "colSua";
            this.colSua.ValuesAreIcons = false;
            //
            // colXoa
            //
            this.colXoa.Description = "Xóa phòng";
            this.colXoa.FillWeight = 35F;
            this.colXoa.HeaderText = "Xóa";
            this.colXoa.Image = ((System.Drawing.Image)(resources.GetObject("colXoa.Image")));
            this.colXoa.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colXoa.Name = "colXoa";
            this.colXoa.ValuesAreIcons = false;
            //
            // picSearch
            //
            this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
            this.picSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.picSearch.Location = new System.Drawing.Point(85, 7);
            this.picSearch.Size = new System.Drawing.Size(39, 37);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            //
            // txtSearch
            //
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtSearch.Location = new System.Drawing.Point(130, 12);
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
            this.btnExport.Location = new System.Drawing.Point(560, 12);
            this.btnExport.Size = new System.Drawing.Size(167, 37);
            this.btnExport.Text = "Xuất file Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.ExportExcel_Click);
            //
            // btnAdd
            //
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(803, 12);
            this.btnAdd.Size = new System.Drawing.Size(188, 37);
            this.btnAdd.Text = "Thêm mới phòng";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            //
            // searchTimer
            //
            this.searchTimer.Interval = 300;
            this.searchTimer.Tick += new System.EventHandler(this.SearchTimer_Tick);
            //
            // RoomListControl
            //
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnAdd);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Size = new System.Drawing.Size(1039, 699);
            this.Name = "RoomListControl";
            this.Load += new System.EventHandler(this.RoomListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.DataGridViewImageColumn IconPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewImageColumn colSua;
        private System.Windows.Forms.DataGridViewImageColumn colXoa;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Timer searchTimer;
    }
}
