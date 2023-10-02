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


            tree.Nodes.Add(treeNode);
            this.Controls.Add(tree);
        }

        private void Btn_MouseDown(object? sender, MouseEventArgs e)
        {
            btn.BackColor = Color.Pink;
        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text=="Nupp-Button")
            {
                this.Controls.Add(btn);
                
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
