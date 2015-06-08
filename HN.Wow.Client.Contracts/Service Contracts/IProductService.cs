using System.ServiceModel;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Exceptions;
using HN.Wow.Client.Entities;

namespace HN.Wow.Client.Contracts
{
    [ServiceContract]
    public interface IProductService : IServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product GetProduct(int productId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product[] GetAllProducts();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product UpdateProdcut(Product product);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteProduct(int ProductId);


        #region Async Operations

        [OperationContract]
        Task<Product> GetProductAsync(int productId);

        [OperationContract]
        Task<Product[]> GetAllProductsAsync();

        [OperationContract]
        Task<Product> UpdateProductAsync(Product product);

        [OperationContract]
        Task DeleteProductAsync(int productId);

        #endregion
    }
}