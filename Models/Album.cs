using System.Collections.Generic;
using Desafio.Models; 

namespace Desafio.Models
{
    public class Album
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public List<Photo> Photos {get; set;}
    }
}
