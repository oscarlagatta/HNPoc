using System.Collections.Generic;
using System.Linq;

namespace SamplesData
{
  public class PagerViewModel
  {
    #region Constructor
    public PagerViewModel()
      : base()
    {
      Init();
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the Pager object
    /// </summary>
    public WowPager Pager { get; set; }
    /// <summary>
    /// Get/Set the page collection
    /// </summary>
    public WowPagerItemCollection Pages { get; set; }
    #endregion

    #region Init Method
    public void Init()
    {
      Pager = new WowPager();

      SetPagerObject(11);
    }
    #endregion

    #region SetPagerObject Method
    private void SetPagerObject(int totalRecords)
    {
      // Set Pager Information
      Pager.TotalRecords = totalRecords;
      Pager.PageSize = 5;
      Pager.SetPagerProperties(string.Empty);

      // Build paging collection
      Pages = new WowPagerItemCollection(
        Pager.TotalRecords,
        Pager.PageSize, 
        Pager.PageIndex);

      // Set total pages
      Pager.TotalPages = Pages.PageCount;
    }
    #endregion
  }
}
