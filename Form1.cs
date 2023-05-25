using System;
using System.Windows.Forms;

namespace Vorobyev
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            if (String.IsNullOrWhiteSpace(login) ||
                String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            var query = $"SELECT id, surname, roleId, img FROM Users WHERE login = '{login}' and password='{password}'";
            var db = new DataBase();
            var response = db.SelectQuery(query);

            if (response.Rows.Count < 1)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            var row = response.Rows[0];

            var id = (int)row[0];
            var surname = (string)row[1];
            var roleId = (int)row[2];
            var img = (string)row[3];

            CurrentUser.Id = id;
            CurrentUser.Img = img;
            CurrentUser.Surname = surname;
            CurrentUser.RoleId = roleId;

            var fr = new MainForm();
            fr.Owner = this;
            fr.Show();
            this.Hide();
        }
    }
}
