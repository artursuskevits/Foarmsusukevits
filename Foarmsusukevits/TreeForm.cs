using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foarmsusukevits
{
    public partial class TreeForm: Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        TextBox txt_box;
        RadioButton r1, r2;
        CheckBox c1, c2;
        PictureBox pb,pb2;
        public TreeForm()
        {

            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm põhielementiga";
            tree = new TreeView();
            tree: Dock = DockStyle.Left;
            tree.BorderStyle = BorderStyle.Fixed3D;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode treeNode = new TreeNode("Elemendid");
            treeNode.Nodes.Add(new TreeNode("Nupp-Button"));
            tree.Height = 400;
            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Valjutada mind";
            btn.Location = new Point(150, 50);
            btn.Click += Btn_Click;
            btn.MouseDown += Btn_MouseDown;
            btn.MouseHover += Btn_MouseHover;
            btn.MouseLeave += Btn_MouseLeave;
            treeNode.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(tree.Width, 0);
            lbl.Size = new Size(this.Width,btn.Location.Y );
            lbl.Font = new Font("Tahoma",24);
            lbl.BackColor = Color.Pink;
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            btn.Visible = false; 
            lbl.Visible = false;
            tree.Nodes.Add(treeNode);
            this.Controls.Add(tree);
            //Tekstikast
            treeNode.Nodes.Add(new TreeNode("Tekstikast-textbox"));
            txt_box = new TextBox();
            txt_box.BorderStyle = BorderStyle.Fixed3D;
            txt_box.Height = 50;
            txt_box.Width = 100;
            txt_box.Text = "....";
            txt_box.Location = new Point(150, btn.Top+btn.Height+10);
            txt_box.KeyDown += new KeyEventHandler(Txt_box_AcceptsTabChanged);
            
            this.Controls.Add(txt_box);
            txt_box.Visible = false;
            //Radiobutton
            treeNode.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            r1 = new RadioButton();
            r1.Text = "Valik1";
            r1.Width = r1.Width - 20;
            r1.Location = new Point(150,txt_box.Location.Y+txt_box.Height+10) ;
            r1.CheckedChanged += new EventHandler(RadioButtons_Changed);
            r2 = new RadioButton();
            r2.Text = "Valik2";
            r2.Location = new Point(r1.Location.X+r1.Width, txt_box.Location.Y + txt_box.Height + 10);
            r2.CheckedChanged += new EventHandler(RadioButtons_Changed);
            this.Controls.Add(r1);
            this.Controls.Add(r2);
            r1.Visible = false;
            r2.Visible = false;
            //CheckBox
            treeNode.Nodes.Add(new TreeNode("Checkkast-Chechkbox"));
            c1 = new CheckBox();
            c1.Text = "White lbl color";
            c1.Width = c1.Width;
            c1.Location = new Point(150, r1.Location.Y + r1.Height + 10);
            c1.CheckedChanged += new EventHandler(Checkbox_Changed);
            c2 = new CheckBox();
            c2.Text = "Green lbl color";
            c2.Location = new Point(c1.Location.X + c1.Width, r1.Location.Y + r1.Height + 10);
            c2.CheckedChanged += new EventHandler(Checkbox_Changed);
            this.Controls.Add(c1);
            this.Controls.Add(c2);
            c1.Visible = false;
            c2.Visible = false;
            //Picturebox
            treeNode.Nodes.Add(new TreeNode("Image-Pilt"));
            pb = new PictureBox();
            pb.Location = new Point(150,c2.Location.Y+c2.Height);
            pb.Image = new Bitmap("../../../image.jpg");
            pb.Size = new Size(120, 120);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;
            pb2 = new PictureBox();
            pb2.Location = new Point(pb.Location.X + pb.Width + 10, c2.Location.Y + c2.Height);
            pb2.Image = new Bitmap("../../../image3.jpg");
            pb2.Size = new Size(120, 120);
            pb2.SizeMode = PictureBoxSizeMode.Zoom;
            pb2.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(pb);
            this.Controls.Add(pb2);
            pb.Visible = false;
            pb2.Visible = false;
        }

       

        private void Txt_box_AcceptsTabChanged(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo);
                if (result==DialogResult.Yes)
                {
                    lbl.Text = txt_box.Text;
                }
                
            }
            
        }

        private void Checkbox_Changed(object? sender, EventArgs e)
        {
            if (c1.Checked==true && c2.Checked==false)
            {
                pb.Image = new Bitmap("../../../image4.jpg");
                pb2.Visible = false;
            }
            else if (c2.Checked == true && c1.Checked == false)
            {
                pb.Image = new Bitmap("../../../image3.jpg");
                pb2.Visible = false;
            }
            else if (c1.Checked == true && c2.Checked == true)
            {
                pb.Image = new Bitmap("../../../image4.jpg");
                
                pb2.Visible = true;
            }
            else
            {
                pb.Image = new Bitmap("../../../image.jpg");
                pb2.Visible = false;
            }
        }

        private void RadioButtons_Changed(object? sender, EventArgs e)
        {
            if (r1.Checked==true)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.BackColor = Color.White;
                    tree.BackColor = Color.White;

                }
                
            }
            else if (r2.Checked == true)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.BackColor = Color.Gray;
                    tree.BackColor = Color.Gray;
                }
            }
        }

        private void Btn_MouseLeave(object? sender, EventArgs e)
        {
            btn.Height = 40;
        }

        private void Btn_MouseHover(object? sender, EventArgs e)
        {
            btn.Height = 100;
        }

        private void Btn_MouseDown(object? sender, MouseEventArgs e)
        {
            btn.BackColor = Color.Pink;
        }


        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {

            if (e.Node.Text == "Nupp-Button")
            {
        btn.Visible = !btn.Visible;
            }
            else if (e.Node.Text == "Silt-Label")
            {
        lbl.Visible = !lbl.Visible;
            }
            else if (e.Node.Text== "Tekstikast-textbox")
            {
                txt_box.Visible = !txt_box.Visible;
            }
            else if(e.Node.Text== "Radionupp-Radiobutton")
            {
                r1.Visible = !r1.Visible;
                r2.Visible = !r2.Visible;
            }
            else if(e.Node.Text== "Checkkast-Chechkbox")
            {
                c1.Visible = !c1.Visible;
                c2.Visible = !c2.Visible;
            }
            else if (e.Node.Text== "Image-Pilt")
            {
                pb.Visible = !pb.Visible;
            }
            tree.SelectedNode = null;
        }
        
        
        private void Btn_Click(object? sender, EventArgs e)
        {
            if (btn.BackColor == Color.Aqua) 
            {
                btn.BackColor = Color.Chocolate;
            }
            else
            {
                btn.BackColor = Color.Aqua;
            }

        }
    }
}
