using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Manager.Services.Interfaces;
using AutoMapper;
using Manager.Services.DTO;
using Manager.API.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace Manager.API.Controller
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserServices _userService;

        public UserController(IMapper mapper, IUserServices userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        [Route("api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody]CreateUserViewModel userViewModel) 
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                                
                var userCreated = await _userService.Create (userDTO);
                
                return Ok(new ResultViewModel
                {
                    Success = true,
                    Message = "User created successfully",
                    Data = userCreated
                });
            } 
            
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainError(ex.Message, ex.Errors));
            }
            
            catch (Exception)
            {                
                return StatusCode(500, Responses.ApliccationError());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("api/v1/users/update")]
        
        public async Task<IActionResult> Update([FromBody]UpdateUserViewModel userViewModel) 
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                                
                var userUpdated = await _userService.Update (userDTO);
                
                if (userUpdated == null)
                {
                    return NotFound(new ResultViewModel
                    {
                        Success = false,
                        Message = "User not found",
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Success = true,
                    Message = "User updated successfully",
                    Data = userUpdated
                });
            } 
            
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainError(ex.Message, ex.Errors));
            }
            
            catch (Exception)
            {                
                return StatusCode(500, Responses.ApliccationError());
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("api/v1/users/delete/{id}")]
        
        public async Task<IActionResult> Delete(long id) 
        {
            try
            {
                await _userService.Remove (id);
                
                return Ok(new ResultViewModel
                {
                    Success = true,
                    Message = "User deleted successfully",
                    Data = null
                });
            } 
            
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainError(ex.Message, ex.Errors));
            }
            
            catch (Exception)
            {                
                return StatusCode(500, Responses.ApliccationError());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/get/{id}")]

        public async Task<IActionResult> Get(long id) 
        {
            try
            {
                var user = await _userService.Get (id);
                
                if (user == null)
                {
                    return NotFound(new ResultViewModel
                    {
                        Success = false,
                        Message = "User not found",
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Success = true,
                    Message = "User found successfully",
                    Data = user
                });
            } 
            
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainError(ex.Message, ex.Errors));
            }
            
            catch (Exception)
            {                
                return StatusCode(500, Responses.ApliccationError());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/get-all")]

        public async Task<IActionResult> Get() 
        {
            try
            {
                var users = await _userService.Get();
                
                return Ok(new ResultViewModel
                {
                    Success = true,
                    Message = "Users found successfully",
                    Data = users
                });
            } 
            
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainError(ex.Message, ex.Errors));
            }
            
            catch (Exception)
            {                
                return StatusCode(500, Responses.ApliccationError());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/get-by-email/")]

        public async Task<IActionResult> GetByEmail([FromQuery]string email) 
        {
            try
            {
                var user = await _userService.GetByEmail(email);
                
                if (user == null)
                {
                    return NotFound(new ResultViewModel
                    {
                        Success = false,
                        Message = "No user found with this email",
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Success = true,
                    Message = "User found successfully",
                    Data = user
                });
            } 
            
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainError(ex.Message, ex.Errors));
            }
            
            catch (Exception)
            {                
                return StatusCode(500, Responses.ApliccationError());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/search-by-name/")]

        public async Task<IActionResult> SearchByName([FromQuery]string name) 
        {
            try
            {
                var users = await _userService.SearchByName(name);
                
                if (users == null)
                {
                    return NotFound(new ResultViewModel
                    {
                        Success = false,
                        Message = "No user found with this name",
                        Data = null
                    });
                }
                
                return Ok(new ResultViewModel
                {
                    Success = true,
                    Message = "Users found successfully",
                    Data = users
                });
            } 
            
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainError(ex.Message, ex.Errors));
            }
            
            catch (Exception)
            {                
                return StatusCode(500, Responses.ApliccationError());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("api/v1/users/search-by-email/")]

        public async Task<IActionResult> SearchByEmail([FromQuery]string email) 
        {
            try
            {
                var users = await _userService.SearchByEmail(email);
                
                if (users == null)
                {
                    return NotFound(new ResultViewModel
                    {
                        Success = false,
                        Message = "No user found with this email",
                        Data = null
                    });
                }
                
                return Ok(new ResultViewModel
                {
                    Success = true,
                    Message = "Users found successfully",
                    Data = users
                });
            } 
            
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainError(ex.Message, ex.Errors));
            }
            
            catch (Exception)
            {                
                return StatusCode(500, Responses.ApliccationError());
            }
        }
    }
}