using System.Linq.Expressions;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IRepository<TEntity, TEntityId>:IQuery<TEntity>
    where TEntity : Entity<TEntityId>
{
    /*  Expression<Func<TEntity,bool>> predicate
        bu kısım filtre vermeye yarar. istediğimiz filtreye göre
        veri çekebiliriz. await GetAsync(x => x.Id == 5);  */

    TEntity Get(
        Expression<Func<TEntity,bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include=null, //join
        bool withDeleted=false, //get soft deleted entities or not
        bool enableTracking=true // Ef Core tracking
        ); 
    
    //Sayfalama yapısı
    Paginate<TEntity> GetList(
        Expression<Func<TEntity, bool>>? predicate=null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy=null,//order by
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include=null,
        int index=0, //ilk sayfa
        int size=10, //10 veri
        bool withDeleted=false,
        bool enableTracking=true);
    
    Paginate<TEntity> GetListByDynamic(
        //DynamicQuery dynamic,   
        Expression<Func<TEntity, bool>>? predicate=null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include=null,
        int index=0, //ilk sayfa
        int size=10, //10 veri
        bool withDeleted=false,
        bool enableTracking=true);

    bool Any(
        Expression<Func<TEntity, bool>>? predicate=null,
        bool withDeleted=false,
        bool enableTracking=true);

    TEntity Add(TEntity entity);
    Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entities); //çoklu veri ekleme
    
    TEntity Update(TEntity entity);
    ICollection<TEntity> UpdateRange(ICollection<TEntity> entities);//çoklu veri güncelleme
    
    TEntity Delete(TEntity entity,bool permanent=false);//soft delete, kalıcı silmez silindi diye işaretler.
    ICollection<TEntity> DeleteRange(ICollection<TEntity> entities,bool permanent=false);//çoklu veri silme
    
    
    
}