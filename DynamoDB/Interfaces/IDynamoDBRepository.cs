using DynamoDB.Models;

namespace DynamoDB.Interfaces
{
    public interface IDynamoDBRepository
    {
        Task<IEnumerable<User>> All(string Id);
        Task Add(UserInputModel entity);
        Task Remove(UserInputModel entity);
    }
}
