using System.Collections.Generic;
using System.Linq;

namespace SamplesData
{
  /// <summary>
  /// View Model for Server-Side Paging and Sorting
  /// </summary>
  public class ProductViewModel4
  {
    #region Constructor
    public ProductViewModel4()
      : base()
    {
      Init();
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the collection of Products
    /// </summary>
    public List<Product> Products { get; set; }
    /// <summary>
    /// Get/Set the Pager object
    /// </summary>
    public WowPager Pager { get; set; }
    /// <summary>
    /// Get/Set whether or not the pager is visible
    /// </summary>
    public bool IsPagerVisible { get; set; }
    /// <summary>
    /// Get/Set the page collection
    /// </summary>
    public WowPagerItemCollection Pages { get; set; }
    /// <summary>
    /// Get/Set the current command executed on the client-side
    /// </summary>
    public string EventCommand { get; set; }
    /// <summary>
    /// Get/Set any parameters for the current command executed. This could be a page number for paging, etc.
    /// </summary>
    public string EventArgument { get; set; }
    #endregion

    #region Init Method
    public void Init()
    {
      Products = new List<Product>();

      EventCommand = string.Empty;
      EventArgument = string.Empty;

      Pager = new WowPager();
      IsPagerVisible = true;
    }
    #endregion

    #region HandleRequest Method
    public void HandleRequest()
    {
      ProductManager mgr = new ProductManager();

      switch (EventCommand)
      {
        case "page":
          // Setup Pager Object
          SetPagerObject(mgr.GetProductsCount());

          // Get Products for the current page
          LoadProducts();

          break;
      }
    }
    #endregion

    #region LoadProducts Method
    public void LoadProducts()
    {
      ProductManager mgr = new ProductManager();

      Products = mgr.GetProducts(Pager.PageIndex, Pager.PageSize);
    }
    #endregion

    #region SetPagerObject Method
    private void SetPagerObject(int totalRecords)
    {
      // Set Pager Information
      Pager.TotalRecords = totalRecords;
      Pager.SetPagerProperties(EventArgument);

      // Build paging collection
      Pages = new WowPagerItemCollection(Pager.TotalRecords, Pager.PageSize, Pager.PageIndex);
      // Set total pages
      Pager.TotalPages = Pages.PageCount;
    }
    #endregion

  }
}
