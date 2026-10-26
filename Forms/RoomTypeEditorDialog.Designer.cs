#nullable disable
namespace _6551071068_MAP_APP.Forms
{
    partial class RoomTypeEditorDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBeds = new System.Windows.Forms.Label();
            this.txtBeds = new System.Windows.Forms.TextBox();
            this.lblMaximumGuests = new System.Windows.Forms.Label();
            this.txtMaximumGuests = new System.Windows.Forms.TextBox();
            this.lblDailyPrice = new System.Windows.Forms.Label();
            this.txtDailyPrice = new System.Windows.Forms.TextBox();
            this.lblHourlyPrice = new System.Windows.Forms.Label();
            this.txtHourlyPrice = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFields.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Orange;
            this.lblTitle.Location = new System.Drawing.Point(72, 31);
            this.lblTitle.Size = new System.Drawing.Size(420, 34);
            this.lblTitle.Text = "Thêm mới thông tin loại phòng";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // pnlFields
            //
            this.pnlFields.Controls.Add(this.lblCode);
            this.pnlFields.Controls.Add(this.txtCode);
            this.pnlFields.Controls.Add(this.lblName);
            this.pnlFields.Controls.Add(this.txtName);
            this.pnlFields.Controls.Add(this.lblBeds);
            this.pnlFields.Controls.Add(this.txtBeds);
            this.pnlFields.Controls.Add(this.lblMaximumGuests);
            this.pnlFields.Controls.Add(this.txtMaximumGuests);
            this.pnlFields.Controls.Add(this.lblDailyPrice);
            this.pnlFields.Controls.Add(this.txtDailyPrice);
            this.pnlFields.Controls.Add(this.lblHourlyPrice);
            this.pnlFields.Controls.Add(this.txtHourlyPrice);
            this.pnlFields.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFields.Location = new System.Drawing.Point(21, 101);
            this.pnlFields.Size = new System.Drawing.Size(506, 439);
            //
            // lblCode
            //
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCode.Location = new System.Drawing.Point(10, 29);
            this.lblCode.Size = new System.Drawing.Size(159, 30);
            this.lblCode.Text = "Mã loại phòng";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtCode
            //
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtCode.Location = new System.Drawing.Point(177, 29);
            this.txtCode.MaxLength = 5;
            this.txtCode.Size = new System.Drawing.Size(275, 30);
            //
            // lblName
            //
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblName.Location = new System.Drawing.Point(10, 95);
            this.lblName.Size = new System.Drawing.Size(159, 30);
            this.lblName.Text = "Tên loại phòng";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtName
            //
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtName.Location = new System.Drawing.Point(177, 95);
            this.txtName.MaxLength = 20;
            this.txtName.Size = new System.Drawing.Size(275, 30);
            //
            // lblBeds
            //
            this.lblBeds.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblBeds.Location = new System.Drawing.Point(10, 160);
            this.lblBeds.Size = new System.Drawing.Size(159, 30);
            this.lblBeds.Text = "Số giường";
            this.lblBeds.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtBeds
            //
            this.txtBeds.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtBeds.Location = new System.Drawing.Point(177, 160);
            this.txtBeds.MaxLength = 5;
            this.txtBeds.Size = new System.Drawing.Size(275, 30);
            this.txtBeds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitsOnly);
            //
            // lblMaximumGuests
            //
            this.lblMaximumGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblMaximumGuests.Location = new System.Drawing.Point(10, 229);
            this.lblMaximumGuests.Size = new System.Drawing.Size(159, 30);
            this.lblMaximumGuests.Text = "Số người tối đa";
            this.lblMaximumGuests.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtMaximumGuests
            //
            this.txtMaximumGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtMaximumGuests.Location = new System.Drawing.Point(177, 229);
            this.txtMaximumGuests.MaxLength = 5;
            this.txtMaximumGuests.Size = new System.Drawing.Size(275, 30);
            this.txtMaximumGuests.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitsOnly);
            //
            // lblDailyPrice
            //
            this.lblDailyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblDailyPrice.Location = new System.Drawing.Point(10, 294);
            this.lblDailyPrice.Size = new System.Drawing.Size(159, 30);
            this.lblDailyPrice.Text = "Giá ngày";
            this.lblDailyPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtDailyPrice
            //
            this.txtDailyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtDailyPrice.Location = new System.Drawing.Point(177, 294);
            this.txtDailyPrice.MaxLength = 18;
            this.txtDailyPrice.Size = new System.Drawing.Size(275, 30);
            this.txtDailyPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalInput);
            //
            // lblHourlyPrice
            //
            this.lblHourlyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblHourlyPrice.Location = new System.Drawing.Point(10, 358);
            this.lblHourlyPrice.Size = new System.Drawing.Size(159, 30);
            this.lblHourlyPrice.Text = "Giá giờ";
            this.lblHourlyPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtHourlyPrice
            //
            this.txtHourlyPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtHourlyPrice.Location = new System.Drawing.Point(177, 358);
            this.txtHourlyPrice.MaxLength = 18;
            this.txtHourlyPrice.Size = new System.Drawing.Size(275, 30);
            this.txtHourlyPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalInput);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Location = new System.Drawing.Point(297, 548);
            this.btnCancel.Size = new System.Drawing.Size(137, 59);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.Moccasin;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(97, 548);
            this.btnSave.Size = new System.Drawing.Size(137, 59);
            this.btnSave.Text = "Thêm mới";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            //
            // RoomTypeEditorDialog
            //
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlFields);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(548, 639);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm mới loại phòng";
            this.Name = "RoomTypeEditorDialog";
            this.pnlFields.ResumeLayout(false);
            this.pnlFields.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBeds;
        private System.Windows.Forms.TextBox txtBeds;
        private System.Windows.Forms.Label lblMaximumGuests;
        private System.Windows.Forms.TextBox txtMaximumGuests;
        private System.Windows.Forms.Label lblDailyPrice;
        private System.Windows.Forms.TextBox txtDailyPrice;
        private System.Windows.Forms.Label lblHourlyPrice;
        private System.Windows.Forms.TextBox txtHourlyPrice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
