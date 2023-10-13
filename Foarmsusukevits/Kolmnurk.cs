using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foarmsusukevits
{
    public partial class Kolmnurk : Form
    {
        PictureBox pb;
        public Kolmnurk()
        {
            this.Height = 1000;
            this.Width = 1000;
            this.Text = "Kolmnurk";
            pb = new PictureBox();
            pb.Location = new Point(0,0);
            pb.Image = new Bitmap("../../../triangle.png");
            pb.Size = new Size(220, 220);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(pb);
        }
    }
}
