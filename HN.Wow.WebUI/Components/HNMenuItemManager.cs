using System.Collections.Generic;

namespace HN.Wow.WebUI.Components
{
    public class HNMenuItemManager
    {

        public HNMenuItemManager()
        {
            Menus = new List<HNMenuItem>();
        }

        public List<HNMenuItem> Menus { get; set; }


        public void Load()
        {

            HNMenuItem MenuEntity = new HNMenuItem();

            MenuEntity.MenuID = 1;
            MenuEntity.MenuTitle = "HOME";
            MenuEntity.DisplayOrder = 10;
            MenuEntity.MenuAction = "/Home/Home";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 2;
            MenuEntity.MenuTitle = "WOMAN";
            MenuEntity.DisplayOrder = 20;
            MenuEntity.MenuAction = "/Woman/Woman";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 2;
            MenuEntity.MenuTitle = "MAN";
            MenuEntity.DisplayOrder = 30;
            MenuEntity.MenuAction = "/Man/Man";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 3;
            MenuEntity.MenuTitle = "ACCESSORIES";
            MenuEntity.DisplayOrder = 40;
            MenuEntity.MenuAction = "/Accessories/Accessories";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 4;
            MenuEntity.MenuTitle = "BEAUTY";
            MenuEntity.DisplayOrder = 50;
            MenuEntity.MenuAction = "/Beauty/Beauty";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 5;
            MenuEntity.MenuTitle = "FOOD & WINE";
            MenuEntity.DisplayOrder = 60;
            MenuEntity.MenuAction = "/FoodWine/FoodWine";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 5;
            MenuEntity.MenuTitle = "GIFTS";
            MenuEntity.DisplayOrder = 60;
            MenuEntity.MenuAction = "/Gifts/Gifts";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 6;
            MenuEntity.MenuTitle = "BRANDS";
            MenuEntity.DisplayOrder = 70;
            MenuEntity.MenuAction = "/Brands/Brands";
            Menus.Add(MenuEntity); 

        }
    }
}