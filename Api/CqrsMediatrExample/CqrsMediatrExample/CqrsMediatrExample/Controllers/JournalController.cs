using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample_.Controllers
{
    [Route("api/Journal")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public JournalController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllJournals()
        {
            try
            {
                var journals = _repository.Journal.GetAllJournal();
                _logger.LogInfo($"Returned all journal from database.");
                var journalsResult = _mapper.Map<IEnumerable<JournalDto>>(journals);
                return Ok(journalsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllJournal action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
