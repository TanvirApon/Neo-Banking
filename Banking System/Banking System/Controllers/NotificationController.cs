using BankingSystem.Application.DTOs;
using BankingSystem.Application.Interfaces.Notifications;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IValidator<CreateNotificationDto> _createNotificationValidator;
        private readonly IValidator<UpdateNotificationDto> _updateNotificationValidator;

        public NotificationController(INotificationService notificationService, 
            IValidator<CreateNotificationDto> createNotification,
            IValidator<UpdateNotificationDto> updateNotification)
        {
            this._notificationService = notificationService;
            this. _createNotificationValidator = createNotification;
            this._updateNotificationValidator = updateNotification;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await _notificationService.GetAllNotificationsAsync();
            return Ok(notifications);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(NotificationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetNotificationById(long id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateNotificationDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IEnumerable<FluentValidation.Results.ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationDto createNotificationDto)
        {
            var validationResult = await _createNotificationValidator.ValidateAsync(createNotificationDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _notificationService.AddNotificationAsync(createNotificationDto);
            return NoContent();
        }

        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(UpdateNotificationDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IEnumerable<FluentValidation.Results.ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateNotification(long id, [FromBody] UpdateNotificationDto updateNotificationDto)
        {
            var validationResult = await _updateNotificationValidator.ValidateAsync(updateNotificationDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _notificationService.UpdateNotificationAsync(id, updateNotificationDto);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IEnumerable<FluentValidation.Results.ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteNotification(long id)
        {
            try
            {
                await _notificationService.DeleteNotificationAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
            return NoContent();
        }
    }
}
