using AutoMapper.QueryableExtensions;
using MyWoodenHouse.Client.Web.App_Start;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MyWoodenHouse.Client.Web.Infrastructure
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> MapTo<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}