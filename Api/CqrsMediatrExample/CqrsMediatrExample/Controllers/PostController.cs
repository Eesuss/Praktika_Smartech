using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample_.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public PostController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllPost()
        {
            try
            {
                var posts = _repository.Post.GetAllPost();
                _logger.LogInfo($"Returned all posts from database.");
                var postsResult = _mapper.Map<IEnumerable<PostDto>>(posts);
                return Ok(postsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPosts action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("testpost")]
        public IActionResult GetPostAdmin(int id)
        {
            try
            {
                var posts = _repository.Post.GetPostAdmin(id);
                _logger.LogInfo($"Returned all posts from database.");
                var postsResult = _mapper.Map<PostDto>(posts);
                return Ok(postsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllPosts action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
