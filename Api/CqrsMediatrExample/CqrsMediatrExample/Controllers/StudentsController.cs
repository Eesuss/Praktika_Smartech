using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample_.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public StudentsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            try
            {
                var st = _repository.Student.GetAllStudent();
                _logger.LogInfo($"Returned all students from database.");
                var stResult = _mapper.Map<IEnumerable<StudentDto>>(st);
                return Ok(stResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllStudent action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

    }
}
