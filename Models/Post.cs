using System.Collections.Generic;

namespace Desafio.Models
{
    public class Post
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public List<Comment> Comments {get; set;}
    }
}