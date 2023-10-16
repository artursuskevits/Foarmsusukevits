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
    public partial class Kolmnurk2 : Form
    {
        System.Windows.Forms.Button btn;
        System.Windows.Forms.ListView lw = new System.Windows.Forms.ListView();
        PictureBox pb;
        System.Windows.Forms.TextBox tb1, tb2, tb3;
        System.Windows.Forms.Label lbl1, lbl2, lbl3;
        public Kolmnurk2()
        {
            this.Height = 1000;
            this.Width = 1000;
            this.Text = "Kolmnurk";
            pb = new PictureBox();
            pb.Location = new Point(650, 280);
            pb.Image = new Bitmap("../../../triangle.png");
            pb.Size = new Size(220, 220);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(pb);
            lw.Size = new Size(400, 400);
            lw.Location = new Point(30, 30);
            lw.View = View.Details;
            lw.TabIndex = 2;
            lw.Columns.Add("Название столбца 1", 150);
            lw.Columns.Add("Название столбца 2", 150);
            this.Controls.Add(lw);
            btn = new System.Windows.Forms.Button();
            btn.Height = 200;
            btn.Width = 200;
            btn.Text = "Start!";
            btn.Location = new Point(650, 50);
            btn.Click += Btn_Click;
            this.Controls.Add(btn);


            tb1 = new System.Windows.Forms.TextBox();
            tb1.BorderStyle = BorderStyle.Fixed3D;
            tb1.Height = 30;
            tb1.Width = 100;
            tb1.Text = "1";
            tb1.Location = new Point(150, 450);
            tb1.KeyDown += new KeyEventHandler(Txt_box_AcceptsTabChanged);
            this.Controls.Add(tb1);


            lbl1 = new System.Windows.Forms.Label();
            lbl1.Text = "A side: ";
            lbl1.Height = 30;
            lbl1.Width = 80;
            lbl1.Location = new Point(70, 450);
            this.Controls.Add(lbl1);



            tb2 = new System.Windows.Forms.TextBox();
            tb2.BorderStyle = BorderStyle.Fixed3D;
            tb2.Height = 50;
            tb2.Width = 100;
            tb2.Text = "2";
            tb2.Location = new Point(150, tb1.Location.Y + 40);
            tb2.KeyDown += new KeyEventHandler(Txt_box_AcceptsTabChanged);
            this.Controls.Add(tb2);

            lbl2 = new System.Windows.Forms.Label();
            lbl2.Text = "B side: ";
            lbl2.Height = 30;
            lbl2.Width = 80;
            lbl2.Location = new Point(70, lbl1.Location.Y + 40);
            this.Controls.Add(lbl2);

            tb3 = new System.Windows.Forms.TextBox();
            tb3.BorderStyle = BorderStyle.Fixed3D;
            tb3.Height = 50;
            tb3.Width = 100;
            tb3.Text = "3";
            tb3.Location = new Point(150, tb2.Location.Y + 40);
            tb3.KeyDown += new KeyEventHandler(Txt_box_AcceptsTabChanged);
            this.Controls.Add(tb3);

            lbl3 = new System.Windows.Forms.Label();
            lbl3.Text = "C side: ";
            lbl3.Height = 30;
            lbl3.Width = 80;
            lbl3.Location = new Point(70, lbl1.Location.Y + 85);
            this.Controls.Add(lbl3);
        }

        private void Btn_Click(object? sender, EventArgs e)
        {

            lw.Clear();
            lw.View = View.Details;
            lw.TabIndex = 2;
            lw.Columns.Add("Название столбца 1", 150);
            lw.Columns.Add("Название столбца 2", 150);
            this.Controls.Add(lw);
            double a, b, c;
            if (double.TryParse(tb1.Text, out a) && double.TryParse(tb2.Text, out b) && double.TryParse(tb3.Text, out c))
            {
                a = Convert.ToDouble(tb1.Text);
                b = Convert.ToDouble(tb2.Text);
                c = Convert.ToDouble(tb3.Text);
                Triangle triangle = new Triangle(a, b, c);
                lw.Items.Add("Side a");
                lw.Items.Add("Side b");
                lw.Items.Add("Side c");
                lw.Items.Add("Triangle P ");
                lw.Items.Add("Triangle S ");
                lw.Items.Add("Specifier ");
                lw.Items.Add("Height a Side ");
                lw.Items.Add("It iS? ");

                lw.Items[0].SubItems.Add(triangle.ShowASide());
                lw.Items[1].SubItems.Add(triangle.ShowBSide());
                lw.Items[2].SubItems.Add(triangle.ShowCSide());
                lw.Items[3].SubItems.Add(triangle.foundTrinagleP(triangle.a, triangle.b, triangle.c));
                lw.Items[4].SubItems.Add(triangle.foundTraingleS(triangle.a, triangle.b, triangle.c));
                lw.Items[5].SubItems.Add(triangle.foundtype(triangle.a, triangle.b, triangle.c));
                lw.Items[5].SubItems[0].Name = triangle.foundtype(triangle.a, triangle.b, triangle.c);
                lw.Items[6].SubItems.Add(triangle.foundTriangleHa());
                if (triangle.ItIsTriangle)
                {
                    lw.Items[7].SubItems.Add("Yes");
                }
                else
                {
                    lw.Items[7].SubItems.Clear();
                    lw.Items[7].SubItems.Add("No");
                    for (int i = 0; i < 7; i++) // Loop through the first four items
                    {
                        lw.Items[i].SubItems.Clear();
                        lw.Items[i].SubItems.Add("No");
                        lw.Items[i].SubItems[0].Name = "NO";
                    }
                }
                triangle_pilt();

            }
        }

        private void triangle_pilt()
        {
            if (lw.Items[5].SubItems[0].Name == "Equilateral triangle")
            {
                pb.Image = new Bitmap("../../../EquilateralTriangle.png");
            }
            else if (lw.Items[5].SubItems[0].Name == "Isosceles triangle")
            {
                pb.Image = new Bitmap("../../../Isoscelestriangle.png");
            }
            else if (lw.Items[5].SubItems[0].Name == "Scalene triangle")
            {
                pb.Image = new Bitmap("../../../Sclanetriangle.png");
            }
            else
            {
                pb.Image = new Bitmap("../../../No.jpg");
            }

        }
        private void Txt_box_AcceptsTabChanged(object? sender, KeyEventArgs e)
        {



        }
    }
    
}