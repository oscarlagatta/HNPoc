using System;
using System.Collections.Generic;
using System.Linq;

namespace SamplesData
{
  public class ProductViewModel3
  {
    #region Constructor
    public ProductViewModel3()
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
      switch (EventCommand)
      {
        case "page":
          // Get all products
          LoadProducts();

          // Setup Pager Object
          SetPagerObject(Products.Count);

          // Get Products just within this one page
          GetProductsByPage();

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
      Products = mgr.GetProducts();
    }
    #endregion

    #region SetPagerObject Method
    private void SetPagerObject(int totalRecords)
    {
      // Set Pager Information
      Pager.TotalRecords = totalRecords;
      // Set Pager Properties
      Pager.SetPagerProperties(EventArgument);

      // Build paging collection
      Pages = new WowPagerItemCollection(Pager.TotalRecords, Pager.PageSize, Pager.PageIndex);
      // Set total pages
      Pager.TotalPages = Pages.PageCount;
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
