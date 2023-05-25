using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Vorobyev
{
    public partial class AccountPage : UserControl
    {
        private readonly string imgHref = Path.Combine(Environment.CurrentDirectory, "..\\..\\Images\\");

        public AccountPage()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = Path.Combine(imgHref, CurrentUser.Img);
            textBox1.Text = CurrentUser.Surname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "Файлы изображений (*.jpg, *.png)|*.jpg;*.png";

            if (openDialog.ShowDialog() == DialogResult.Cancel) return;
            var type = openDialog.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{type[type.Length - 1]}";

            var path = Path.Combine(imgHref, fileName);
            pictureBox1.Image = Image.FromFile(openDialog.FileName);
            pictureBox1.Image.Save(path);

            var query = $"UPDATE Users SET Img = '{fileName}' WHERE id = {CurrentUser.Id}";
            var db = new DataBase();
            db.UpdateQuery(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = false;

            if (textBox1.Text == CurrentUser.Surname && string.IsNullOrWhiteSpace(textBox2.Text))
                return;

            if (textBox2.Text.Any(x => x == ' '))
                result = false;

            string pattern = @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9 !@#$%^&*()-_+=;:,./?\\|`~^{}<>""[]{8,20})$";
            result = Regex.IsMatch(textBox2.Text, pattern);

            if (!textBox2.Text.Any(x => char.IsUpper(x)))
                result = false;

            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (result == false)
                {
                    errorProvider1.SetError(textBox2, "Некорректный пароль");
                    return;
                }
                else
                {
                    errorProvider1.SetError(textBox2, "");
                }

                if (result)
                {
                    var query = $"UPDATE Users SET password = '{textBox2.Text}' WHERE Id = {CurrentUser.Id}";
                    var db = new DataBase();
                    db.UpdateQuery(query);
                }
            }

            if(textBox1.Text != CurrentUser.Surname)
            {
                var query = $"UPDATE Users SET Surname = '{textBox1.Text}' WHERE Id = {CurrentUser.Id}";
                var db = new DataBase();
                db.UpdateQuery(query);
            }
        }
    }
}
