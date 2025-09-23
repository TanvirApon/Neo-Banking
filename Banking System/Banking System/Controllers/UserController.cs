using BankingSystem.Application.DTOs;
using BankingSystem.Application.Interfaces.Users;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUserDto> _createUserValidator;
        private readonly IValidator<UpdateUserDto> _updateUserValidator;

        public UserController(IUserService userService,IValidator<CreateUserDto> createUser,IValidator<UpdateUserDto> updateUser)
        { 
            this._userService = userService;
            this._createUserValidator = createUser;
            this._updateUserValidator = updateUser;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetUserById(long id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        [ProducesResponseType(typeof(CreateUserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IEnumerable<FluentValidation.Results.ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var validationResult = await _createUserValidator.ValidateAsync(createUserDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _userService.AddUserAsync(createUserDto);

            return NoContent();
        }


        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(UpdateUserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IEnumerable<FluentValidation.Results.ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UpdateUserDto updateUserDto)
        {
            var validationResult = await _updateUserValidator.ValidateAsync(updateUserDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            await _userService.UpdateUserAsync(id, updateUserDto);
            return NoContent();
        }


        [HttpDelete("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IEnumerable<FluentValidation.Results.ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

    }
}
