
using HN.Wow.Business.Entities;
using HN.Wow.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HN.Wow.Data
{
    [Export(typeof(IProductRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductRepository : DataRepositoryBase<Product>, IProductRepository
    {
        protected override Product AddEntity(WowContext entityContext, Product entity)
        {
            return entityContext.ProductSet.Add(entity);
        }

        protected override Product UpdateEntity(WowContext entityContext, Product entity)
        {
            return (from e in entityContext.ProductSet
                    where e.ProductId == entity.ProductId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Product> GetEntities(WowContext entityContext)
        {
            return from e in entityContext.ProductSet
                   select e;
        }

        protected override Product GetEntity(WowContext entityContext, int id)
        {
            var query = (from e in entityContext.ProductSet
                         where e.ProductId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        /// <summary>
        /// Custom 
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public Product GetByProductName(string productName)
        {
            using (WowContext entityContext = new WowContext())
            {
                return (from p in entityContext.ProductSet
                        where p.ProductName == productName
                        select p).FirstOrDefault();
            }
        }
       
    }
}
