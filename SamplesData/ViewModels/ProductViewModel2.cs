using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace SamplesData
{
  public class ProductViewModel2
  {
    #region Constructor
    public ProductViewModel2()
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
    /// Get/Set the current sort direction
    /// </summary>
    public SortDirection SortDirection { get; set; }
    /// <summary>
    /// Get/Set the new sort direction
    /// </summary>
    public SortDirection SortDirectionNew { get; set; }
    /// <summary>
    /// Get/Set the current column you wish to sort on
    /// </summary>
    public string SortExpression { get; set; }
    /// <summary>
    /// Get/Set the last column you sorted on
    /// </summary>
    public string LastSortExpression { get; set; }
    /// <summary>
    /// Get/Set the current command executed on the client-side
    /// </summary>
    public string EventCommand { get; set; }
    #endregion

    #region Init Method
    public void Init()
    {
      Products = new List<Product>();

      EventCommand = string.Empty;

      // Set initial sort expression
      SortExpression = "ProductName";
      SortDirection = SamplesData.SortDirection.Ascending;
      LastSortExpression = string.Empty;
      SortDirectionNew = SamplesData.SortDirection.Ascending;
    }
    #endregion

    #region HandleRequest Method
    public void HandleRequest()
    {
      switch (EventCommand)
      {
        case "sort":
          // Check to see if we need to change the sort order 
          // because the sort expression changed
          SetSortDirection();

          LoadProducts();

          // Sort the data if SortExpression is filled in
          if (!string.IsNullOrEmpty(SortExpression))
            Products = Sort<Product>(Products.AsQueryable<Product>());

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

    #region SetSortDirection Method
    protected virtual void SetSortDirection()
    {
      if (SortExpression == LastSortExpression)
      {
        if (SortDirection == SamplesData.SortDirection.Ascending)
          SortDirection = SamplesData.SortDirection.Descending;
        else
          SortDirection = SamplesData.SortDirection.Ascending;
      }
      else
      {
        SortDirection = SortDirectionNew;
      }
    }
    #endregion

    #region Sort Method
    protected virtual List<T> Sort<T>(IQueryable<T> list)
    {
      // NOTE: Using System.Linq.Dynamic DLL
      list = list.OrderBy(SortExpression +
        (SortDirection ==
          SortDirection.Ascending ? " ASC" : " DESC"));

      return list.ToList();
    }
    #endregion
  }
}
