namespace Foarmsusukevits
{
    public partial class myform : Form
    {
        Button btn;
        public myform()
        {

            //InitializeComponent();
            this.Height = 200;
            this.Width = 200;
            btn = new Button();
            btn.Height = 40;
            btn.Width = 40;
            btn.Text = "Valjutada mind";
            btn.Location = new Point(10, 20);
            this.Controls.Add(btn);
        }
        public myform(int x, int y,string nimetus)
        {

            //InitializeComponent();
            this.Height = y;
            this.Width = x;
            btn = new Button();
            btn.Text = nimetus;
            btn.Location = new Point(10, 20);
            this.Controls.Add(btn);
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            myform form = new myform();
            form.ShowDialog();
        }
    }
    
}