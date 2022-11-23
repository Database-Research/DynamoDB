using DynamoDB.Interfaces;
using DynamoDB.Models;
using DynamoDB.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace DynamoDB.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DynamoDBController : ControllerBase
    {
        private IConfiguration _configuration;
        private IDynamoDBRepository _repository;
        public DynamoDBController(IDynamoDBRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> getAllPostsById(string Id)
        {
            return await _repository.All(Id);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePost(UserInputModel model)
        {
            await _repository.Add(model);
            return Ok(model);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> Delete(UserInputModel model)
        {
            await _repository.Remove(model);
            return NoContent();
        }

    }
}