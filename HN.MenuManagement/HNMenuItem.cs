using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN.MenuManagement
{
    public class HNMenuItem
    {
        public HNMenuItem()
        {
            ParentMenuID = 0;
            Menus = new List<HNMenuItem>();
        }

        public int MenuID { get; set; }
        public int ParentMenuID { get; set; }

        public string MenuTitle { get; set; }
        public int DisplayOrder { get; set; }
        public string MenuAction { get; set; }

        public List<HNMenuItem> Menus { get; set; }
        public override string ToString()
        {
            return MenuTitle;
        }

    }
}
