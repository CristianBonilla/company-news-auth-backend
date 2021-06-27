using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Company.Domain
{
    public class NewsService : INewsService
    {
        readonly INewsRepository newsRepository;

        public NewsService(INewsRepository newsRepository) => (this.newsRepository) = (newsRepository);

        public Task<NewsEntity> FindNews(Expression<Func<NewsEntity, bool>> expression)
        {
            NewsEntity news = newsRepository.Find(expression);

            return Task.FromResult(news);
        }

        public IAsyncEnumerable<NewsEntity> GetNews()
        {
            var news = newsRepository.Get(null, order => order.OrderByDescending(news => news.Updated)
                .ThenBy(news => news.Title))
                .ToAsyncEnumerable();

            return news;
        }
    }
}
