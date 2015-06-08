using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using Core.Common.Contracts;
using Core.Common.Exceptions;
using HN.Wow.Business.Common;
using HN.Wow.Business.Contracts;
using HN.Wow.Business.Entities;
using HN.Wow.Data.Contracts;

namespace HN.Wow.Business.Managers.Managers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
    ConcurrencyMode = ConcurrencyMode.Multiple,
    ReleaseServiceInstanceOnTransactionComplete = false)]
    public class ProductManager : ManagerBase, IProductService
    {
        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _businessEngineFactory;

        public ProductManager()
        {

        }

        /// <summary>
        /// I want to be able to test this ProductManager class and mock my own version 
        /// of the data repository factory for testing purposes; that's why I'll give 
        /// another constructor; which WCF won't care about.
        /// </summary>
        /// <param name="dataRepositoryFactory"></param>
        public ProductManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        public ProductManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
            _businessEngineFactory = businessEngineFactory;
        }

        #region IProductService operations

        public Product GetProduct(int productId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var productRepositoryFactory = _dataRepositoryFactory.GetDataRepository<IProductRepository>();

                Product productEntity = productRepositoryFactory.Get(productId);

                if (productEntity == null)
                {
                    NotFoundException ex
                        = new NotFoundException(string.Format("Product with Id {0} is not in the database. ", productId));

                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return productEntity;
            });

        }

        public Product[] GetAllProducts()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var accountRepository
                    = _dataRepositoryFactory.GetDataRepository<IProductRepository>();

                IEnumerable<Product> products = accountRepository.Get();

                return products.ToArray();
            });
        }

        public void DeleteProduct(int ProductId)
        {
            ExecuteFaultHandledOperation(() =>
            {
                var productRepository = _dataRepositoryFactory.GetDataRepository<IProductRepository>();

                var accountEntity = productRepository.Get(ProductId);

                if (accountEntity == null)
                {
                    NotFoundException ex
                        = new NotFoundException(string.Format("Product with Id {0} is not in the database. ", ProductId));

                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                productRepository.Remove(ProductId);
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public Product UpdateProdcut(Product product)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var productRepository = _dataRepositoryFactory.GetDataRepository<IProductRepository>();

                Product updatedProduct = null;

                if (product.AccountId == 0)
                    updatedProduct = productRepository.Add(product);
                else
                    updatedProduct = productRepository.Update(product);

                return updatedProduct;
            });
        }

        public Product[] GetAvailableProducts(System.DateTime pickupDate, System.DateTime returnDate)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                IProductRepository productRepository = _dataRepositoryFactory.GetDataRepository<IProductRepository>();

                IProductEngine productEngine = _businessEngineFactory.GetBusinessEngine<IProductEngine>();

                IEnumerable<Product> allProducts = productRepository.Get();

                List<Product> availableProducts = new List<Product>();

                foreach (Product product in allProducts)
                {
                    // Call to the business engine
                    
                    //if (productEngine.isProductAvailable(product.ProductId, pickupDate, returnDate, rentedProducts, reservedProducts))
                    //    availableProducts.Add(product);
                }

                return availableProducts.ToArray();
            });
        }
        #endregion
    }
}
