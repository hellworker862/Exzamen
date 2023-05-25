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
    public partial class IngrePage : UserControl
    {
        public IngrePage()
        {
            InitializeComponent();
            var query = @"SELECT i.Name as 'Наименование ингредиента', CONCAT(i.Cost, ' руб. за ', i.CostForCount, ' ', u.Name) as 'Цена' FROM Ingredient i 
                        join Unit u on u.Id = i.UnitId";
            var db = new DataBase();
            var response = db.SelectQuery(query);
            dataGridView1.DataSource = response;
        }
    }
}
