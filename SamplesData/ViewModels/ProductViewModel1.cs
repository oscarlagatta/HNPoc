using System.Collections.Generic;

namespace SamplesData
{
  public class ProductViewModel1
  {
    #region Constructor
    public ProductViewModel1()
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
    public void HandleRequest()
    {
      ProductManager mgr = new ProductManager();

      // Get list of products
      Products = mgr.GetProducts();
    }
    #endregion
  }
}
