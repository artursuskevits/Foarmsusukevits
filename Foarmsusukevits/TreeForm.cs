using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foarmsusukevits
{
    public partial class TreeForm: Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
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
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            btn.Visible = false; 
            lbl.Visible = false;
            tree.Nodes.Add(treeNode);
            this.Controls.Add(tree);
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
            if (e.Node.Text=="Nupp-Button")
            {
                
                
                
                if (btn.Visible == true)
                {
                    btn.Visible = false;
                }
                else
                {
                    btn.Visible = true;
                }


            }
            else if(e.Node.Text == "Silt-Label")
            {
                lbl.BackColor = Color.Pink;
                if (lbl.Visible == true)
                {
                    lbl.Visible = false;
                }
                else
                {
                    lbl.Visible = true;
                }



            }
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
