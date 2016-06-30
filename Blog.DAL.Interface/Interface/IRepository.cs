using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Blog.DAL.Interface.DTO;


namespace Blog.DAL.Interface.Interface
{
    public interface IRepository<TEntity> where TEntity: IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int entityId);        
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);

        //TEntity GetByPredicate(Expression<Func<TEntity, bool>> f);
    }
}
