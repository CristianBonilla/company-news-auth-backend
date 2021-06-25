using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Company.Domain
{
    public interface INewsService
    {
        Task<NewsEntity> FindNews(Expression<Func<NewsEntity, bool>> expression);
        IAsyncEnumerable<NewsEntity> GetNews();
    }
}
