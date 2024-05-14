using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample_.Controllers
{
    [Route("api/LessonContent")]
    [ApiController]
    public class LessonContentController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public LessonContentController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllLessonContent()
        {
            try
            {
                var lesCont = _repository.LessonsContent.GetAllLessonContent();
                _logger.LogInfo($"Returned all LessonContent from database.");
                var lesContResult = _mapper.Map<IEnumerable<LessonContentDto>>(lesCont);
                return Ok(lesContResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllLessonContent action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
