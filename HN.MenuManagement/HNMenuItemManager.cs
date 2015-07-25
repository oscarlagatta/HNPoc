using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN.MenuManagement
{
    public class HNMenuItemManager
    {
        public HNMenuItemManager(HNMenuBase injector)
        {
            MenuReader = injector;
        }

        public HNMenuBase MenuReader { get; set; }

        public List<HNMenuItem>  Menus { get; set; }

        public List<HNMenuItem> Load()
        {
            Menus = MenuReader.Load();

            return Menus;
        }
    }
}
