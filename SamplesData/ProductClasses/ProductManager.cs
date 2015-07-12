using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SamplesData
{
  public class ProductManager
  {
    #region GetProducts Method
    /// <summary>
    /// Get all Products from Product table
    /// </summary>
    /// <returns>A List of Product objects</returns>
    public List<Product> GetProducts()
    {
      DataTable dt = new DataTable();
      SqlDataAdapter da = null;

      da = new SqlDataAdapter("SELECT * FROM Product",
                              AppSettings.Instance.ConnectString);

      da.Fill(dt);

      var query =
        (from dr in dt.AsEnumerable()
         select new Product
         {
           ProductId = Convert.ToInt32(dr["ProductId"]),
           ProductName = dr["ProductName"].ToString(),
           IntroductionDate = dr.GetDataAs<DateTime>("IntroductionDate", default(DateTime)),
           Cost = dr.GetDataAs<decimal>("Cost", default(decimal)),
           Price = dr.GetDataAs<decimal>("Price", default(decimal)),
           IsDiscontinued = dr.GetDataAs<bool>("IsDiscontinued", default(bool))
         });

      return query.ToList();
    }
    #endregion

    #region GetProducts (Sorted) Method
    /// <summary>
    /// Get all Products from Product table
    /// </summary>
    /// <returns>A List of Product objects</returns>
    public List<Product> GetProducts(string sortOrder, string sortDirection)
    {
      return GetProducts(sortOrder, sortDirection, null);
    }

    public List<Product> GetProducts(string sortOrder, SortDirection sortDirection)
    {
      return GetProducts(sortOrder,
        (sortDirection == SamplesData.SortDirection.Ascending ? "ASC" : "DESC").ToString(), null);
    }

    /// <summary>
    /// Get all Products from Product table
    /// </summary>
    /// <returns>A List of Product objects</returns>
    public List<Product> GetProducts(string sortOrder, string sortDirection, Product entity)
    {
      DataTable dt = new DataTable();
      SqlCommand cmd;
      SqlDataAdapter da = null;
      string sql;

      sql = "SELECT * FROM Product";
      cmd = new SqlCommand();
      if (entity != null)
      {
        if (!string.IsNullOrEmpty(entity.ProductName))
        {
          sql += " WHERE ProductName LIKE @ProductName ";
          cmd.Parameters.Add(new SqlParameter("@ProductName", entity.ProductName + "%"));
        }
      }

      if (!string.IsNullOrEmpty(sortOrder))
      {
        sql += " ORDER BY " + sortOrder + " " + sortDirection;
      }

      cmd.CommandText = sql;
      cmd.Connection = new SqlConnection(AppSettings.Instance.ConnectString);
      da = new SqlDataAdapter(cmd);

      da.Fill(dt);

      var query =
        (from dr in dt.AsEnumerable()
         select new Product
         {
           ProductId = Convert.ToInt32(dr["ProductId"]),
           ProductName = dr["ProductName"].ToString(),
           IntroductionDate = dr.GetDataAs<DateTime>("IntroductionDate", default(DateTime)),
           Cost = dr.GetDataAs<decimal>("Cost", default(decimal)),
           Price = dr.GetDataAs<decimal>("Price", default(decimal)),
           IsDiscontinued = dr.GetDataAs<bool>("IsDiscontinued", default(bool))
         });

      cmd.Connection.Close();
      cmd.Connection.Dispose();
      cmd.Dispose();

      return query.ToList();
    }
    #endregion

    #region GetProducts (Server-Side Paging) Method
    /// <summary>
    /// Get all Products from Product table
    /// </summary>
    /// <returns>A List of Product objects</returns>
    public List<Product> GetProducts(int pageIndex,
      int pageSize)
    {
      return GetProducts(pageIndex, pageSize, "ProductName", " ASC");
    }

    public List<Product> GetProducts(int pageIndex,
      int pageSize,
      string sortOrder,
      SortDirection sortDirection)
    {
      return GetProducts(pageIndex, pageSize,
        sortOrder,
        (sortDirection == SamplesData.SortDirection.Ascending ? "ASC" : "DESC").ToString());
    }

    /// <summary>
    /// Get all Products from Product table
    /// </summary>
    /// <returns>A List of Product objects</returns>
    public List<Product> GetProducts(int pageIndex,
      int pageSize,
      string sortOrder,
      string sortDirection)
    {
      DataTable dt = new DataTable();
      SqlDataAdapter da = null;
      int startingRow = (pageIndex * pageSize);
      int endingRow = startingRow + pageSize;
      string sql;

      if (string.IsNullOrEmpty(sortOrder))
      {
        sortOrder = "ProductName";
      }
      if (string.IsNullOrEmpty(sortDirection))
      {
        sortDirection = "ASC";
      }

      sql = "SELECT * FROM ( ";
      sql += " SELECT *, ROW_NUMBER() OVER (ORDER BY "
              + sortOrder + " " + sortDirection + ") ";
      sql += " AS ResultSetRowNumber FROM Product)";
      sql += " AS ResultSet ";
      sql += " WHERE ResultSetRowNumber > " + startingRow;
      sql += " AND ResultSetRowNumber <= " + endingRow;

      da = new SqlDataAdapter(sql,
        AppSettings.Instance.ConnectString);

      da.Fill(dt);

      var query =
        (from dr in dt.AsEnumerable()
         select new Product
         {
           ProductId = Convert.ToInt32(dr["ProductId"]),
           ProductName = dr["ProductName"].ToString(),
           IntroductionDate = dr.GetDataAs<DateTime>("IntroductionDate", default(DateTime)),
           Cost = dr.GetDataAs<decimal>("Cost", default(decimal)),
           Price = dr.GetDataAs<decimal>("Price", default(decimal)),
           IsDiscontinued = dr.GetDataAs<bool>("IsDiscontinued", default(bool))
         });

      return query.ToList();
    }
    #endregion

    #region GetProductsCount Method
    public int GetProductsCount()
    {
      DataTable dt = new DataTable();
      SqlCommand cmd = null;
      int ret = 0;

      cmd = new SqlCommand("SELECT Count(*) FROM Product");
      cmd.Connection = new SqlConnection(AppSettings.Instance.ConnectString);
      cmd.Connection.Open();
      ret = Convert.ToInt32(cmd.ExecuteScalar());
      cmd.Connection.Close();
      cmd.Connection.Dispose();

      return ret;
    }
    #endregion
  }
}
