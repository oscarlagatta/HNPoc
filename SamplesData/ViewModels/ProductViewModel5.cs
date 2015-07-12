using System.Collections.Generic;
using System.Linq;

namespace SamplesData
{
  /// <summary>
  /// View Model for Paging and Sorting using C#
  /// </summary>
  public class ProductViewModel5 : ViewModelBaseSimple
  {
    #region Constructor
    public ProductViewModel5()
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
          // Get all products
          LoadProducts();

          // Setup Pager Object
          SetPagerObject(Products.Count);

          // Get Products just within this one page
          GetProductsByPage();

          break;

        default:
          break;
      }
    }
    #endregion
    
    #region LoadProducts Method
    public void LoadProducts()
    {
      ProductManager mgr = new ProductManager();

      // Get list of products
      // TODO: Put some caching in here
      Products = mgr.GetProducts(SortExpression, SortDirection);
    }
    #endregion

    #region GetProductsByPage Method
    private void GetProductsByPage()
    {
      IQueryable<Product> query;

      // Convert Products to IQueryable
      query = Products.AsQueryable<Product>();

      // Get to the page requested using LINQ
      query = query.Skip(Pager.StartingRow).Take(Pager.PageSize);
      
      // Convert 'query' back to List<Product>
      Products = new List<Product>(query.ToList<Product>());
    }
    #endregion
  }
}
