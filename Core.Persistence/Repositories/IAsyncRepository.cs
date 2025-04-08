using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IAsyncRepository<TEntity, TEntityId>:IQuery<TEntity>
    where TEntity : Entity<TEntityId>
{
    
    /*  Expression<Func<TEntity,bool>> predicate
        bu kısım filtre vermeye yarar. istediğimiz filtreye göre
        veri çekebiliriz. await GetAsync(x => x.Id == 5);  */

    Task<TEntity?> GetAsync(
        Expression<Func<TEntity,bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include=null, //join
        bool withDeleted=false, //get soft deleted entities or not
        bool enableTracking=true, // Ef Core tracking
        CancellationToken cancellationToken=default
        ); 
    
    //Sayfalama yapısı
    Task<Paginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate=null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy=null,//order by
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include=null,//join
        int index=0, //ilk sayfa
        int size=10, //10 veri
        bool withDeleted=false,
        bool enableTracking=true,
        CancellationToken cancellationToken=default
        );
    
    Task<Paginate<TEntity>> GetListByDynamicAsync(
        DynamicQuery dynamic,   
        Expression<Func<TEntity, bool>>? predicate=null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include=null,
        int index=0, //ilk sayfa
        int size=10, //10 veri
        bool withDeleted=false,
        bool enableTracking=true,
        CancellationToken cancellationToken=default
    );

    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate=null,
        bool withDeleted=false,
        bool enableTracking=true,
        CancellationToken cancellationToken=default
        );
    Task<TEntity> AddAsync(TEntity entity);
    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities); //çoklu veri ekleme
    
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities);//çoklu veri güncelleme
    
    Task<TEntity> DeleteAsync(TEntity entity,bool permanent=false);//soft delete, kalıcı silmez silindi diye işaretler.
    Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities,bool permanent=false);//çoklu veri silme
    
    
    
}
     
