using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;

namespace DynamoDB.Models
{
    [DynamoDBTable("user")]
    public class User
    {
        [DynamoDBHashKey]

        public string Id { get; set; }
        [DynamoDBRangeKey]
        public string Name { get; set; }
        [DynamoDBProperty]
        public string Surname {get;set;}
        [DynamoDBProperty]
        public string Gender { get; set; }
    }
}
