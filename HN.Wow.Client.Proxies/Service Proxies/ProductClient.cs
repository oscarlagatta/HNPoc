using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Core.Common.ServiceModel;
using HN.Wow.Client.Contracts;
using HN.Wow.Client.Entities;


namespace HN.Wow.Client.Proxies
{
    [Export(typeof(IProductService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductClient : UserClientBase<IProductService>, IProductService
    {
        public Product GetProduct(int productId)
        {
            return Channel.GetProduct(productId);
        }

        public Product[] GetAllProducts()
        {
            return Channel.GetAllProducts();
        }

        public Product UpdateProdcut(Product product)
        {
            return Channel.UpdateProdcut(product);
        }

        public void DeleteProduct(int ProductId)
        {
            Channel.DeleteProduct(ProductId);
        }

        #region Async to be implemented

        public Task<Product> GetProductAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product[]> GetAllProductsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteProductAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
