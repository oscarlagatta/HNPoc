using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using HN.Wow.Business.Common;
using HN.Wow.Business.Entities;
using HN.Wow.Data.Contracts;

namespace HN.Wow.Business
{
    [Export(typeof(IProductEngine))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ProductEngine
    {
        [ImportingConstructor]
        public ProductEngine(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        IDataRepositoryFactory _dataRepositoryFactory;

        public bool isProductAvailable(int productId)
        {
            bool available = false;

            IProductRepository productRepository = _dataRepositoryFactory.GetDataRepository<IProductRepository>();

            var currentProdcut = productRepository.Get(productId);

            if (currentProdcut != null && currentProdcut.Stock > 0)
                available = true;

            return available;
        }

        public bool isProductAvailable(int productId, DateTime createdOn, DateTime currentDateTime,
            IEnumerable<Product> products)
        {
            bool available = true;
            /*
             * We write all the business logic necessary to obtain the value for "available"
             * 
             * 1.- Check the Stock 
             
             * 2.- Check additional logic
             */

            Product product = products.Where(item => item.ProductId == productId).FirstOrDefault();
            if (product != null && product.Stock == 0)
                available = false;

            /*
             * Example 2
             * The method could receive also a list of Reserved products
             * 
             * Reservation reservation = reservedProducts.Where( item => item.ProductId == productId).FirstOrDefault();
             * if( reservation != null && ( 
             *      ( createdOn >= reservation.ReservedDate && pickupDate <= reservation.ReturnDate))
             *      available = false;
             */

            return available;
        }

        public bool isProductCurrentlyReserved(int productId)
        {
            throw new NotImplementedException();
        }

        public bool isProductCurrentlyDispatched(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
