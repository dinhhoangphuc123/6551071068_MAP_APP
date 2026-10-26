#nullable disable
namespace _6551071068_MAP_APP.Forms
{
    partial class RoomEditorDialog
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
            this.pnlFields = new System.Windows.Forms.Panel();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.cboRoomType = new System.Windows.Forms.ComboBox();
            this.lblCleaning = new System.Windows.Forms.Label();
            this.cboCleaning = new System.Windows.Forms.ComboBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFields.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlFields
            //
            this.pnlFields.Controls.Add(this.lblCode);
            this.pnlFields.Controls.Add(this.txtCode);
            this.pnlFields.Controls.Add(this.lblStatus);
            this.pnlFields.Controls.Add(this.cboStatus);
            this.pnlFields.Controls.Add(this.lblRoomType);
            this.pnlFields.Controls.Add(this.cboRoomType);
            this.pnlFields.Controls.Add(this.lblCleaning);
            this.pnlFields.Controls.Add(this.cboCleaning);
            this.pnlFields.Controls.Add(this.lblNote);
            this.pnlFields.Controls.Add(this.txtNote);
            this.pnlFields.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFields.Location = new System.Drawing.Point(43, 45);
            this.pnlFields.Size = new System.Drawing.Size(509, 433);
            //
            // lblCode
            //
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCode.Location = new System.Drawing.Point(20, 23);
            this.lblCode.Size = new System.Drawing.Size(152, 31);
            this.lblCode.Text = "Mã số phòng";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtCode
            //
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtCode.Location = new System.Drawing.Point(168, 23);
            this.txtCode.Size = new System.Drawing.Size(296, 31);
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.MaxLength = 5;
            //
            // lblStatus
            //
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblStatus.Location = new System.Drawing.Point(20, 81);
            this.lblStatus.Size = new System.Drawing.Size(152, 31);
            this.lblStatus.Text = "Trạng thái phòng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // cboStatus
            //
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cboStatus.Location = new System.Drawing.Point(168, 81);
            this.cboStatus.Size = new System.Drawing.Size(296, 31);
            //
            // lblRoomType
            //
            this.lblRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblRoomType.Location = new System.Drawing.Point(20, 139);
            this.lblRoomType.Size = new System.Drawing.Size(152, 31);
            this.lblRoomType.Text = "Loại phòng";
            this.lblRoomType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // cboRoomType
            //
            this.cboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cboRoomType.Location = new System.Drawing.Point(168, 139);
            this.cboRoomType.Size = new System.Drawing.Size(296, 31);
            //
            // lblCleaning
            //
            this.lblCleaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCleaning.Location = new System.Drawing.Point(20, 197);
            this.lblCleaning.Size = new System.Drawing.Size(152, 31);
            this.lblCleaning.Text = "Tình trạng dọn dẹp";
            this.lblCleaning.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // cboCleaning
            //
            this.cboCleaning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCleaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cboCleaning.Location = new System.Drawing.Point(168, 197);
            this.cboCleaning.Size = new System.Drawing.Size(296, 31);
            this.cboCleaning.Items.AddRange(new object[] {
                "Đã dọn dẹp",
                "Chưa dọn dẹp"});
            //
            // lblNote
            //
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblNote.Location = new System.Drawing.Point(20, 343);
            this.lblNote.Size = new System.Drawing.Size(145, 30);
            this.lblNote.Text = "Ghi chú";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // txtNote
            //
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtNote.Location = new System.Drawing.Point(180, 313);
            this.txtNote.MaxLength = 100;
            this.txtNote.Multiline = true;
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(284, 91);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancel.Location = new System.Drawing.Point(300, 500);
            this.btnCancel.Size = new System.Drawing.Size(137, 59);
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.Moccasin;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(97, 500);
            this.btnSave.Size = new System.Drawing.Size(137, 59);
            this.btnSave.Text = "Thêm mới";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            //
            // RoomEditorDialog
            //
            this.Controls.Add(this.pnlFields);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(595, 588);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm mới phòng";
            this.Name = "RoomEditorDialog";
            this.Load += new System.EventHandler(this.RoomEditorDialog_Load);
            this.pnlFields.ResumeLayout(false);
            this.pnlFields.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlFields;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.ComboBox cboRoomType;
        private System.Windows.Forms.Label lblCleaning;
        private System.Windows.Forms.ComboBox cboCleaning;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}
