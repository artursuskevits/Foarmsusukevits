using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Foarmsusukevits
{
    public partial class Kolmnurk : Form
    {
        System.Windows.Forms.Button btn,closebtn, teiseformava;
        System.Windows.Forms.ListView lw = new System.Windows.Forms.ListView();
        PictureBox pb;
        System.Windows.Forms.TextBox tb1, tb2, tb3;
        System.Windows.Forms.Label lbl1, lbl2, lbl3;
        public Kolmnurk()
        {
            this.Height = 850;
            this.Width = 750;
            this.Text = "Kolmnurk";
            pb = new PictureBox();
            pb.Location = new Point(500,280);
            pb.Image = new Bitmap("../../../triangle.png");
            pb.Size = new Size(220, 220);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(pb);
            lw.Size = new Size(400, 400);
            lw.Location = new Point(30, 30);
            lw.View = View.Details;
            lw.TabIndex = 2;
            lw.Columns.Add("Väli", 150);
            lw.Columns.Add("Tähtsus", 150);
            this.Controls.Add(lw);
            btn = new System.Windows.Forms.Button();
            btn.Height =200;
            btn.Width = 200;
            btn.Text = "Alusta!";
            btn.Location = new Point(510, 50);
            btn.Click += Btn_Click;
            this.Controls.Add(btn);
            closebtn = new System.Windows.Forms.Button();
            closebtn.Height = 100;
            closebtn.Width = 100;
            closebtn.Text = "Sulge form";
            closebtn.Location = new Point(550, pb.Location.X+10);
            this.Controls.Add(closebtn);
            closebtn.Click += Closebtn_Click;
            teiseformava = new System.Windows.Forms.Button();
            teiseformava.Height = 100;
            teiseformava.Width = 100;
            teiseformava.Text = "Ava uue form";
            teiseformava.Location = new Point(550, closebtn.Location.X+closebtn.Height+10-20);
            this.Controls.Add(teiseformava);
            teiseformava.Click += Teiseformava_Click;

            tb1 = new System.Windows.Forms.TextBox();
            tb1.BorderStyle = BorderStyle.Fixed3D;
            tb1.Height = 30;
            tb1.Width = 100;
            tb1.Text = "1";
            tb1.Location = new Point(150, 450);
            tb1.KeyDown += new KeyEventHandler(Txt_box_AcceptsTabChanged);
            this.Controls.Add(tb1);


            lbl1 = new System.Windows.Forms.Label();
            lbl1.Text = "Külg A: ";
            lbl1.Height = 30;
            lbl1.Width = 80;
            lbl1.Location = new Point(70, 450);
            this.Controls.Add(lbl1);

            

            tb2 = new System.Windows.Forms.TextBox();
            tb2.BorderStyle = BorderStyle.Fixed3D;
            tb2.Height = 50;
            tb2.Width = 100;
            tb2.Text = "2";
            tb2.Location = new Point( 150, tb1.Location.Y + 40);
            tb2.KeyDown += new KeyEventHandler(Txt_box_AcceptsTabChanged);
            this.Controls.Add(tb2);

            lbl2 = new System.Windows.Forms.Label();
            lbl2.Text = "Külg B: ";
            lbl2.Height = 30;
            lbl2.Width = 80;
            lbl2.Location = new Point(70, lbl1.Location.Y+40);
            this.Controls.Add(lbl2);

            tb3 = new System.Windows.Forms.TextBox();
            tb3.BorderStyle = BorderStyle.Fixed3D;
            tb3.Height = 50;
            tb3.Width = 100;
            tb3.Text = "3";
            tb3.Location = new Point(150, tb2.Location.Y  + 40);
            tb3.KeyDown += new KeyEventHandler(Txt_box_AcceptsTabChanged);
            this.Controls.Add(tb3);

            lbl3 = new System.Windows.Forms.Label();
            lbl3.Text = "Külg C: ";
            lbl3.Height = 30;
            lbl3.Width = 80;
            lbl3.Location = new Point(70, lbl1.Location.Y + 85);
            this.Controls.Add(lbl3);
        }

        private void Teiseformava_Click(object? sender, EventArgs e)
        {
            Kolmnurk2 kolmnurk2 = new Kolmnurk2();
            kolmnurk2.ShowDialog();
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            
                lw.Clear();
                lw.View = View.Details;
                lw.TabIndex = 2;
                lw.Columns.Add("Väli", 150);
                lw.Columns.Add("Tähtsus", 150);
                this.Controls.Add(lw);
                double a, b, c;
            if (double.TryParse(tb1.Text, out a) && double.TryParse(tb2.Text, out b) && double.TryParse(tb3.Text, out c))
            {
                a = Convert.ToDouble(tb1.Text);
                b = Convert.ToDouble(tb2.Text);
                c = Convert.ToDouble(tb3.Text);
                Triangle triangle = new Triangle(a, b, c);
                lw.Items.Add("Külg a");
                lw.Items.Add("Külg b");
                lw.Items.Add("Külg c");
                lw.Items.Add("Kolmnurk P ");
                lw.Items.Add("Kolmnurk S ");
                lw.Items.Add("Täpsustaja ");
                lw.Items.Add("Kõrgus a külg");
                lw.Items.Add("See on? ");

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
                    lw.Items[7].SubItems.Add("Yah");
                }
                else
                {
                    
                    lw.Items[7].SubItems.Add("Ei");
                    for (int i = 0; i < 7; i++) // Loop through the first four items
                    {
                        
                        lw.Items[i].SubItems.Add("Ei");
                        lw.Items[i].SubItems[1] = lw.Items[i].SubItems[2];
                    }
                    lw.Items[5].SubItems[0].Name = "0";
                }

                triangle_pilt();

            }
        }

        private void triangle_pilt()
        {
            if (lw.Items[5].SubItems[0].Name == "Võrdkülgne kolmnurk")
            {
                pb.Image = new Bitmap("../../../EquilateralTriangle.png");
            }
            else if (lw.Items[5].SubItems[0].Name == "Tasakülgne kolmnurk")
            {
                pb.Image = new Bitmap("../../../Isoscelestriangle.png");
            }
            else if (lw.Items[5].SubItems[0].Name == "Skaleeni kolmnurk")
            {
                pb.Image = new Bitmap("../../../Sclanetriangle.png");
            }
            else
            {
                pb.Image = new Bitmap("../../../Ei.png");
            }

        }
        private void Txt_box_AcceptsTabChanged(object? sender, KeyEventArgs e)
        {
            
            

        }
        private void Closebtn_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
