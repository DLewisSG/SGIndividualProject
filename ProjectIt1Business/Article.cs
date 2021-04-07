using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProjectIt1Business
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int TeamPageId { get; set; }

        public TeamPage TeamPage { get; set; }
    }
}
