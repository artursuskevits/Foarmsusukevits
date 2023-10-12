using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
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
        TextBox txt_box,txt_box2,txt_box3;
        RadioButton r1, r2;
        CheckBox c1, c2;
        PictureBox pb,pb2;
        ListBox lb;
        public TreeForm()
        {

            this.Height = 1000;
            this.Width = 1000;
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
            //
            treeNode.Nodes.Add(new TreeNode("Listbox"));
            lb = new ListBox();
            lb.Height = 80;
            lb.Width = 85;
            lb.Items.Add("RoheLine");
            lb.Items.Add("Sinine");
            lb.Items.Add("Hall");
            lb.Items.Add("Kollane");
            lb.Location = new Point(150, pb.Location.Y + pb.Height);
            this.Controls.Add(lb);
            lb.Visible = false;
            txt_box2 = new TextBox();
            txt_box2.BorderStyle = BorderStyle.Fixed3D;
            txt_box2.Height = 50;
            txt_box2.Width = 100;
            txt_box2.Text = "Lisa sõna";
            txt_box2.Location = new Point(175+lb.Height, pb.Location.Y + pb.Height);
            txt_box2.KeyDown += new KeyEventHandler(Txt_box_AcceptsTabChanged2);
            this.Controls.Add(txt_box2);
            txt_box2.Visible = false;
            txt_box3 = new TextBox();
            txt_box3.BorderStyle = BorderStyle.Fixed3D;
            txt_box3.Height = 50;
            txt_box3.Width = 100;
            txt_box3.Text = "Kustuta sõna";
            txt_box3.Location = new Point(txt_box2.Location.Y + txt_box2.Height+45  , pb.Location.Y + pb.Height);
            txt_box3.KeyDown += new KeyEventHandler(Txt_box_AcceptsTabChanged3);
            this.Controls.Add(txt_box3);
            txt_box3.Visible = false;
            DataSet ds = new DataSet("Xml faill Mune");
            ds.ReadXml(@"..\..\..\sample_CustomersOrders.xml");
            DataGridView dataGrid = new DataGridView();
            dataGrid.Location = new Point(tree.Width + pb.Width, pb.Location.Y);
            dataGrid.Height = 200;
            dataGrid.Width = 300;
            dataGrid.DataSource = ds;
            //dataGrid.AutoSize = true;
            //dataGrid.AutoGenerateColumns = true;
            //dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            dataGrid.DataMember = "order";

            this.Controls.Add(dataGrid);




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
                else
                {
                    string tekst = Interaction.InputBox("Sisseta peakiri", "Uus peakiri", "Uuspeakirii");
                    if (tekst.Length>0)
                    {
                        this.Text = tekst;
                    }
                }
            }
            
        }
        private void Txt_box_AcceptsTabChanged2(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int itemCount = lb.Items.Count;
                    string tekst = txt_box2.Text;
                    if (tekst.Length>0 && !lb.Items.Contains(tekst) && itemCount<11 )
                    {
                        lb.Items.Add(tekst);
                        lb.Height += 20;
                    }
                    
                }
                
            }

        }
        private void Txt_box_AcceptsTabChanged3(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string tekst = txt_box3.Text;
                    if (lb.Items.Contains(tekst))
                    {
                        lb.Items.Remove(tekst);
                        lb.Height -= 5;
                    }

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
            
            else if (e.Node.Text == "Listbox")
            { lb.Visible = !lb.Visible;
                txt_box2.Visible = !txt_box2.Visible;
                txt_box3.Visible = !txt_box3.Visible;
            }
            else if (e.Node.Text == "Xml faill Mune") 
            { }
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
