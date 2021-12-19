using System;
using System.Linq;
using System.Linq.Expressions;


namespace Codebridge.Infrastructure
{
    public static class SortExtension
    {
        public static  IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> q, string Attribute, string Order)
        {         
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, Attribute);
            var exp = Expression.Lambda(prop, param);

            string method = Order.ToLower()=="desc" ? "OrderByDescending" : "OrderBy";

            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var rs = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);      
            
            return  q.Provider.CreateQuery<T>(rs);
        }
    }
}
