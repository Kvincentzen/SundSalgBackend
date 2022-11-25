using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SundSalgBackend.Contracts;

namespace SundSalgBackend.Data
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected IdentityContext IdentityContext;

        public RepositoryBase(IdentityContext identityContext)
        {
            IdentityContext = identityContext;
        }
        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            IdentityContext.Set<T>()
                .AsNoTracking() :
            IdentityContext.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
            !trackChanges ?
              IdentityContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              IdentityContext.Set<T>()
                .Where(expression);

        public void Create(T entity) => IdentityContext.Set<T>().Add(entity);

        public void Update(T entity) => IdentityContext.Set<T>().Update(entity);

        public void Delete(T entity) => IdentityContext.Set<T>().Remove(entity);
        public void Save()
        {
            this.IdentityContext.SaveChanges();
        }

    }
}
