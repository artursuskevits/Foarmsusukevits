using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
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
        System.Windows.Forms.TextBox tb1, tb2;
        System.Windows.Forms.Label lbl1, lbl2,lbl3;
        public Kolmnurk2()
        {
            this.Height = 1000;
            this.Width = 1000;
            this.Text = "Kolmnurk";
            lbl3 = new System.Windows.Forms.Label();
            lbl3.Location = new Point(650, 280);
            lbl3.Size = new Size(220, 220);
            lbl3.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(lbl3);
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
            lbl1.Text = "Square: ";
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
            lbl2.Text = "Side: ";
            lbl2.Height = 30;
            lbl2.Width = 80;
            lbl2.Location = new Point(70, lbl1.Location.Y + 40);
            this.Controls.Add(lbl2);

            
        }

        private void Btn_Click(object? sender, EventArgs e)
        {

            lw.Clear();
            lw.View = View.Details;
            lw.TabIndex = 2;
            lw.Columns.Add("Название столбца 1", 150);
            lw.Columns.Add("Название столбца 2", 150);
            this.Controls.Add(lw);
            double a;
           
                a = Convert.ToDouble(tb1.Text);
            
            
            double S = Convert.ToDouble(tb2.Text);
            string formula = $"h = 2 * {S} / {a}"; ;
            lbl3.Text = formula;
            lbl3.TextAlign = ContentAlignment.MiddleCenter;
            lbl3.Font = new Font("Arial", 16);
            string Sstr=S.ToString();
               Triangle triangle = new Triangle(a,0,0);
                lw.Items.Add("Side");
                lw.Items.Add("Triangle S");
                lw.Items.Add("Height to Side ");

                lw.Items[0].SubItems.Add(triangle.ShowASide());
                lw.Items[1].SubItems.Add(Sstr);
                lw.Items[2].SubItems.Add(triangle.foundTriangleHbySnadoneside(S));
                
                triangle_pilt();
        }

        private void triangle_pilt()
        {

        }
        private void Txt_box_AcceptsTabChanged(object? sender, KeyEventArgs e)
        {



        }
    }
    
}