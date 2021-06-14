using System.Linq;
using System.Collections.Generic;
using Desafio.Models;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System;
using Dapper;
using System.Threading.Tasks;

namespace Desafio.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new
                ArgumentNullException(nameof(configuration));
        }

        // Testando autenticação via Jwt
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "admin", Password = "admin", Role = "admin"});
            users.Add(new User { Id = 2, Username = "user", Password = "user", Role = "employee"});
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault<User>();
        }

        private NpgsqlConnection GetConnectionPostgreSql()
        {
            return new NpgsqlConnection
                (_configuration.GetValue<string>("ConnectionStrings:MyApiConnection"));
        }

        public async Task<User> Get(int id)
        {
            NpgsqlConnection connection = GetConnectionPostgreSql();

            var user = await connection.QueryFirstOrDefaultAsync<User>
                ("SELECT * FROM user WHERE Id = @id", 
                    new {Id = id});
            if (user == null)
                return new User
                    { Id = 0, Username = "No User", Password = "", Role = "" };
            return user;
        }

        public async Task<User> GetUser(string username, string password)
        {
            NpgsqlConnection connection = GetConnectionPostgreSql();

            var user = await connection.QueryFirstOrDefaultAsync<User>
                ("SELECT * FROM user WHERE username = @Username AND password = @Password", 
                    new {Username = username, Password = password});
            if (user == null)
                return new User
                    { Id = 0, Username = "No User", Password = "", Role = "" };
            return user;
        }

        Task<IEnumerable<User>> IUserRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.Add(User user)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}