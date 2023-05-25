using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vorobyev
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (CurrentUser.Id == 3)
            {
                var btn3 = new Button();
                btn3.Text = "Добавить ингредиент";
                btn3.BackColor = Color.Yellow;
                btn3.FlatStyle = FlatStyle.Flat;
                btn3.Click += Btn3Click;
                btn3.Dock = DockStyle.Top;
                panelButtons.Controls.Add(btn3);
            }

            var btn2 = new Button();
            btn2.Text = "Ингредиенты";
            btn2.BackColor = Color.Yellow;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.Click += Btn2Click;
            btn2.Dock = DockStyle.Top;
            panelButtons.Controls.Add(btn2);

            var btn1 = new Button();
            btn1.Text = "Блюда";
            btn1.BackColor = Color.Yellow;
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Click += Btn1Click;
            btn1.Dock = DockStyle.Top;
            panelButtons.Controls.Add(btn1);

            OpenBluda();
        }

        private void Btn1Click(object sender, EventArgs e)
        {
            OpenBluda();
        }

        private void Btn2Click(object sender, EventArgs e)
        {
            OpenRecept();
        }

        private void Btn3Click(object sender, EventArgs e)
        {
            OpenAddIng();
        }

        private void OpenBluda()
        {
            var page = new BludaPage();
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(page);
        }

        private void OpenRecept()
        {
            var page = new IngrePage();
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(page);
        }

        public void OpenAddIng()
        {
            var page = new AddIngPage();
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(page);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentUser.Clear();
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner?.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var page = new AccountPage();
            page.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(page);
        }
    }
}
