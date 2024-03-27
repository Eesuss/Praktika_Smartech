using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample_.Controllers
{
    [Route("api/Lessons")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public LessonsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllLessons()
        {
            try
            {
                var les = _repository.Lessons.GetAllLessons();
                _logger.LogInfo($"Returned all lessons from database.");
                var lesResult = _mapper.Map<IEnumerable<LessonDto>>(les);
                return Ok(lesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllLessons action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
