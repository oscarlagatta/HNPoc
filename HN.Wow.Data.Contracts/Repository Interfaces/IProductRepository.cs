using Core.Common.Contracts;
using HN.Wow.Business.Entities;

namespace HN.Wow.Data.Contracts
{
    public interface IProductRepository : IDataRepository<Product>
    {
        Product GetByProductName(string productName);
    }
}
