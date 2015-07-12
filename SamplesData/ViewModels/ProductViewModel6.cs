using System.Collections.Generic;
using System.Linq;

namespace SamplesData
{
  /// <summary>
  /// View Model for Server-Side Paging and Sorting
  /// </summary>
  public class ProductViewModel6 : ViewModelBaseSimple
  {
    #region Constructor
    public ProductViewModel6()
      : base()
    {
      Products = new List<Product>();
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// Get/Set the collection of Products
    /// </summary>
    public List<Product> Products { get; set; }
   
    #endregion

    #region HandleRequest Method
    public override void HandleRequest()
    {
      ProductManager mgr = new ProductManager();

      base.HandleRequest();

      if (EventCommand == "sort")
      {
        // Check to see if we need to change the sort order 
        // because the sort expression changed
        SetSortDirection();
      }

      switch (EventCommand)
      {
        case "page":
        case "sort":
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

      Products = mgr.GetProducts(Pager.PageIndex, Pager.PageSize,
                                 SortExpression, 
                                 SortDirection);
    }
    #endregion
  }
}
