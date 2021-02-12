using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


//isim uzayı
namespace Core.DataAccess
{
    //Core katmanı diğer katmanları referans almaz
    //interface
    //bu yapı generic
    //IEntity  interface  newlenemez
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() newlenenlir olmalıdır
    public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        //generic constraint
        //class 
        //bu 4 özellikler geliyor
        List<T> GelAll(Expression<Func<T,bool>>filter =null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
