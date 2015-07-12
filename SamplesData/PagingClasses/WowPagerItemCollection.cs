using System;
using System.Collections.Generic;

namespace SamplesData
{
  /// <summary>
  /// Class to hold a collection of pager items to display on a page
  /// </summary>
  public class WowPagerItemCollection : List<WowPagerItem>
  {
    #region Constructor
    public WowPagerItemCollection(int rowCount, int pageSize, int pageIndex)
    {
      // Calculate total pages based on RowCount and PageSize
      int pageCount = 0;
      
      pageCount = Convert.ToInt32(
                    Math.Ceiling(
                       Convert.ToDecimal(rowCount) /
                       Convert.ToDecimal(pageSize)));

      // Initialize the collection of pager items
      Init(pageCount, pageIndex);
    }
    #endregion

    #region Public Properties
    public int PageCount { get; set; }
    #endregion

    #region Init Method
    private void Init(int pageCount, int pageIndex)
    {
      int itemIndex = 0;

      PageCount = pageCount;

      Add(new WowPagerItem(WowPagerCommands.FirstText, 
                            WowPagerCommands.First,
                            (pageIndex == 0), WowPagerCommands.FirstTooltipText));
      itemIndex++;
      Add(new WowPagerItem(WowPagerCommands.PreviousText, 
                            WowPagerCommands.Previous,
                            (pageIndex == 0), WowPagerCommands.PreviousTooltipText));
      itemIndex++;

      for (int i = 0; i < PageCount; i++)
      {
        Add(new WowPagerItem(i, pageIndex, 
                              WowPagerCommands.PageText + " " + (i + 1).ToString()));
        itemIndex++;
      }

      Add(new WowPagerItem(WowPagerCommands.NextText, 
                            WowPagerCommands.Next,
                            (PageCount - 1 == pageIndex), WowPagerCommands.NextTooltipText));
      itemIndex++;
      Add(new WowPagerItem(WowPagerCommands.LastText, 
                            WowPagerCommands.Last,
                            (PageCount - 1 == pageIndex), WowPagerCommands.LastTooltipText));
    }
    #endregion
  }
}
