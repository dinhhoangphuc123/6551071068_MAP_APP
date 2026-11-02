using System;
using System.Windows.Forms;

namespace HotelManagement.SoDoPhong
{
    public class FormSoDoPhong : Form
    {
        public FormSoDoPhong()
        {
            Text = "Sơ đồ phòng";
        }

        public string? MaPhongDangChon()
        {
            return null;
        }

        public void TaiLaiDanhSach()
        {
        }

        public void btnDatPhong_Click(object? sender, EventArgs e)
        {
            string? maPhong = MaPhongDangChon();
            using (var fDatPhong = new FormDatPhong())
            {
                fDatPhong.ShowDialog();
            }
            TaiLaiDanhSach();
        }
    }
}

