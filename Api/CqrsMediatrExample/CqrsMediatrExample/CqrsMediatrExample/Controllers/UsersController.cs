using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample_.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public UsersController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                var us = _repository.User.GetAllUser();
                _logger.LogInfo($"Returned all Users from Db.");

                var userResult = _mapper.Map<IEnumerable<UserDto>>(us);
                return Ok(userResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUsers action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _repository.User.GetUserById(id);
                if (user is null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    var userResult = _mapper.Map<UserDto>(user);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{lstname} {pass}")]
        public IActionResult GetByLogUser(string lstname, string pass)
        {
            try
            {
                var user = _repository.User.GetByLogUser(lstname, pass);
                if (user is null)
                {
                    _logger.LogError($"User with lastname: {lstname}, hasn't been.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned user with lastname: {lstname}");
                    var userResult = _mapper.Map<UserDto>(user);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetByLogUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Get admin users")]
        public IActionResult GetAdminUsers()
        {
            try
            {
                var us = _repository.User.GetAdminUsers();
                _logger.LogInfo($"Returned all admin Users from Db.");

                var userResult = _mapper.Map<IEnumerable<UserDto>>(us);
                return Ok(userResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdminUsers action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("PostUser")]
        public IActionResult CreateUser([FromBody] UserCreateDto user)
        {
            try
            {
                if (user is null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid User object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var userEntity = _mapper.Map<User>(user);
                _repository.User.CreateUser(userEntity);
                _repository.Save();
                var createdUser = _mapper.Map<UserCreateDto>(userEntity);
                return CreatedAtRoute("GetUserById", new { id = createdUser.LastName }, createdUser);
            }
            catch (AutoMapperMappingException ex)
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
