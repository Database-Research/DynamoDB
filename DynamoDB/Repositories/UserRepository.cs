using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DynamoDB.Interfaces;
using DynamoDB.Models;
using Microsoft.Extensions.Hosting;

namespace DynamoDB.Repositories
{
    public class UserRepository : IDynamoDBRepository
    {
        private readonly AmazonDynamoDBClient _client;
        private readonly DynamoDBContext _context;

        public UserRepository()
        {
            _client = new AmazonDynamoDBClient(RegionEndpoint.EUCentral1);
            _context = new DynamoDBContext(_client);
        }
        
        public async Task<IEnumerable<User>> All(string Id)
        {
            return await _context.QueryAsync<User>(Id).GetRemainingAsync();
        }

        public async Task Add(UserInputModel entity)
        {


            var user = new User
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Gender = entity.Gender
            };
            await _context.SaveAsync(user);
        }

        public async Task Remove(UserInputModel entity)
        {
            var user = new User
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Gender = entity.Gender
            };
            var _user = await _context.LoadAsync<User>(user);
            await _context.DeleteAsync(_user);
        }

        public async Task<User> Single(string Id)
        {
            return await _context.LoadAsync<User>(Id); //.QueryAsync<Follower>(FollowerId.ToString()).GetRemainingAsync();
        }

    }
}
