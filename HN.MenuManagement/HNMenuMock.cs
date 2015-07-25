using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN.MenuManagement
{
    public class HNMenuMock : HNMenuBase
    {
        public HNMenuMock() : base()
        {

        }

        public override List<HNMenuItem> Load()
        {
            HNMenuItem MenuEntity = new HNMenuItem();
            List<HNMenuItem> Menus = new List<HNMenuItem>();

            MenuEntity.MenuID = 1;
            MenuEntity.MenuTitle = "HOME";
            MenuEntity.DisplayOrder = 10;
            MenuEntity.MenuAction = "/Home/Home";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 2;
            MenuEntity.MenuTitle = "WOMAN";
            MenuEntity.DisplayOrder = 20;
            MenuEntity.MenuAction = string.Empty;
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 3;
            MenuEntity.MenuTitle = "MAN";
            MenuEntity.DisplayOrder = 30;
            MenuEntity.MenuAction = string.Empty;
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 4;
            MenuEntity.MenuTitle = "ACCESSORIES";
            MenuEntity.DisplayOrder = 40;
            MenuEntity.MenuAction = "/Accessories/Accessories";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 5;
            MenuEntity.MenuTitle = "BEAUTY";
            MenuEntity.DisplayOrder = 50;
            MenuEntity.MenuAction = "/Beauty/Beauty";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 6;
            MenuEntity.MenuTitle = "FOOD & WINE";
            MenuEntity.DisplayOrder = 60;
            MenuEntity.MenuAction = "/FoodWine/FoodWine";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID =7;
            MenuEntity.MenuTitle = "GIFTS";
            MenuEntity.DisplayOrder = 60;
            MenuEntity.MenuAction = "/Gifts/Gifts";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 8;
            MenuEntity.MenuTitle = "BRANDS";
            MenuEntity.DisplayOrder = 70;
            MenuEntity.MenuAction = "/Brands/Brands";
            Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 9;
            MenuEntity.ParentMenuID = 2;
            MenuEntity.MenuTitle = "ALL CLOTHING";
            MenuEntity.DisplayOrder = 10;
            MenuEntity.MenuAction = "/Woman/AllClothes";
            Menus.Find(  m => m.MenuID == 2).Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 10;
            MenuEntity.ParentMenuID = 2;
            MenuEntity.MenuTitle = "ALL SHOES";
            MenuEntity.DisplayOrder = 20;
            MenuEntity.MenuAction = "/Woman/AllShoes";
            Menus.Find(m => m.MenuID == 2).Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 11;
            MenuEntity.ParentMenuID = 2;
            MenuEntity.MenuTitle = "ALL ACCESSORIES";
            MenuEntity.DisplayOrder = 20;
            MenuEntity.MenuAction = "/Woman/AllAccessories";
            Menus.Find(m => m.MenuID == 2).Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 12;
            MenuEntity.ParentMenuID = 3;
            MenuEntity.MenuTitle = "ALL CLOTHING";
            MenuEntity.DisplayOrder = 10;
            MenuEntity.MenuAction = "/Man/AllClothes";
            Menus.Find(m => m.MenuID == 3).Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 13;
            MenuEntity.ParentMenuID = 3;
            MenuEntity.MenuTitle = "ALL SHOES";
            MenuEntity.DisplayOrder = 20;
            MenuEntity.MenuAction = "/Man/AllShoes";
            Menus.Find(m => m.MenuID == 3).Menus.Add(MenuEntity);

            MenuEntity = new HNMenuItem();
            MenuEntity.MenuID = 14;
            MenuEntity.ParentMenuID = 3;
            MenuEntity.MenuTitle = "ALL ACCESSORIES";
            MenuEntity.DisplayOrder = 20;
            MenuEntity.MenuAction = "/Man/AllAccessories";
            Menus.Find(m => m.MenuID == 3).Menus.Add(MenuEntity);

            return Menus;
        }
    }
}
