using System;

namespace Company.API
{
    public class NewsResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Updated { get; set; }
    }
}
