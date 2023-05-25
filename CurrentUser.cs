using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vorobyev
{
    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Surname { get; set; }
        public static int RoleId { get; set; }
        public static string Img { get; set; }

        public static void Clear()
        {
            Id = 0;
            Surname = string.Empty;
            RoleId = 0;
            Img = string.Empty;
        }
    }
}
