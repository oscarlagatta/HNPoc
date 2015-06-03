using Core.Common.Contracts;
using Core.Common.Data;

namespace HN.Wow.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, WowContext>
       where T : class, IIdentifiableEntity, new()
    {
    }
}
