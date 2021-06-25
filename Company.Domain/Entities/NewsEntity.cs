using System;

namespace Company.Domain
{
    public class NewsEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Updated { get; set; }
    }
}
