using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectIt1Business

{
    public class Author
    {
        public int AuthorId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string AuthorName { get; set; }

        public TeamPage TeamPage { get; set; }
    }
}
