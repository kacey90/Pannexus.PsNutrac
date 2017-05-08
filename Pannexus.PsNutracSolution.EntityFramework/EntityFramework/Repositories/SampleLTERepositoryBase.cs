using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Pannexus.PsNutrac.EntityFramework.Repositories
{
    public abstract class SampleLTERepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SampleLTEDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SampleLTERepositoryBase(IDbContextProvider<SampleLTEDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class SampleLTERepositoryBase<TEntity> : SampleLTERepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SampleLTERepositoryBase(IDbContextProvider<SampleLTEDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
