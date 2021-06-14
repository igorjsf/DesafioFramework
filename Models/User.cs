using System.Collections.Generic;

namespace Desafio.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
        public string Role {get; set;}

        public List<Album> Albums {get; set;}
    }
}