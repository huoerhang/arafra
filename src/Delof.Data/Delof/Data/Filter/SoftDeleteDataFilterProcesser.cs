﻿using Delof.Ddd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Delof.DependencyInjection;

namespace Delof.Data.Filter
{
    [Dependency]
    public class SoftDeleteDataFilterProcesser : IDataFilterProcesser
    {
        public IQueryable<TEntity> Process<TEntity>(IQueryable<TEntity> query, IDataFilter dataFilter)
            where TEntity : IEntity
        {
            if (typeof(TEntity).IsAssignableTo<ISoftDelete>())
            {
                query = query.WhereIf(dataFilter.IsEnabled<ISoftDelete>(), c => ((ISoftDelete)c).IsDeleted == false);
            }

            return query;
        }
    }
}
