using _6551071068_MAP_APP.UI;

namespace _6551071068_MAP_APP.Forms;

/// <summary>Màn hình chào ở trang chủ.</summary>
public sealed class FormTrangChu : UserControl
{
    public FormTrangChu()
    {
        Dock = DockStyle.Fill;
        BackColor = ClassicUi.Honeydew;
        Controls.Add(new PictureBox
        {
            Dock = DockStyle.Fill,
            Image = ClassicUi.Image("pictureIcon.png"),
            SizeMode = PictureBoxSizeMode.StretchImage
        });
    }
}
