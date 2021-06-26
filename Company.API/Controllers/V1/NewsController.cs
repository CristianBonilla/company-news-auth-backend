using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Company.Domain;

namespace Company.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        readonly IMapper mapper;
        readonly INewsService newsService;

        public NewsController(IMapper mapper, INewsService newsService) =>
            (this.mapper, this.newsService) = (mapper, newsService);

        [HttpGet]
        public async IAsyncEnumerable<NewsResponse> Get()
        {
            var newsList = newsService.GetNews();
            await foreach (NewsEntity news in newsList)
                yield return mapper.Map<NewsResponse>(news);
        }

        [HttpGet("{newsId:guid}")]
        public async Task<IActionResult> Get(Guid newsId)
        {
            NewsEntity newsFound = await newsService.FindNews(news => news.Id == newsId);
            if (newsFound == null)
                return NotFound();
            NewsResponse news = mapper.Map<NewsResponse>(newsFound);

            return Ok(news);
        }
    }
}
