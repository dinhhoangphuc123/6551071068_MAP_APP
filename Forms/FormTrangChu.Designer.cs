#nullable disable
namespace _6551071068_MAP_APP.Forms
{
    partial class FormTrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrangChu));
            this.picTrangChu = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            //
            // picTrangChu
            //
            this.picTrangChu.Image = ((System.Drawing.Image)(resources.GetObject("picTrangChu.Image")));
            this.picTrangChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTrangChu.Location = new System.Drawing.Point(0, 0);
            this.picTrangChu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTrangChu.Size = new System.Drawing.Size(800, 600);
            //
            // FormTrangChu
            //
            this.Controls.Add(this.picTrangChu);
            this.BackColor = System.Drawing.Color.FromArgb(240, 255, 240);
            this.Size = new System.Drawing.Size(800, 600);
            this.Name = "FormTrangChu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picTrangChu;
    }
}
