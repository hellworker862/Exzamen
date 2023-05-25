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
    public partial class BludaPage : UserControl
    {
        public BludaPage()
        {
            InitializeComponent();
            var query = "Select Name From Dish";
            var db = new DataBase();
            var response = db.SelectQuery(query);

            foreach (DataRow item in response.Rows)
            {
                var row = new RowBluda((string)item[0]);
                row.Dock = DockStyle.Top;
                panel1.Controls.Add(row);
            }
        }
    }
}
