using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample_.Controllers
{
    [Route("api/Courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public CoursesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            try
            {
                var cours = _repository.Courses.GetAllCourses();
                _logger.LogInfo($"Returned all courses from database.");
                var coursResult = _mapper.Map<IEnumerable<CourseDto>>(cours);
                return Ok(coursResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllCourses action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
