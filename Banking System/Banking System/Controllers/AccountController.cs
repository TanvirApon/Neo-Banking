using BankingSystem.Application.DTOs;
using BankingSystem.Application.Interfaces.Accounts;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;   
        private readonly IValidator<CreateAccountDto> _createAccountValidator;
        private readonly IValidator<UpdateAccountDto> _updateAccountValidator;
        private readonly IValidator<DepostitDto> _depostitValidator;
        private readonly IValidator<WithdrawDto> _withdrawValidator;

        public AccountController(IAccountService accountService, IValidator<CreateAccountDto> createDto, 
            IValidator<UpdateAccountDto> updateDto, IValidator<DepostitDto> depositeDto, IValidator<WithdrawDto> withdrawDto )
        {
            this._accountService = accountService;
            this._createAccountValidator = createDto;
            this._updateAccountValidator = updateDto;
            this._depostitValidator = depositeDto;
            this._withdrawValidator = withdrawDto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAccountById(long id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }


        [HttpPost]
        [ProducesResponseType(typeof(CreateAccountDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IEnumerable<FluentValidation.Results.ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto createAccountDto)
        {
            var validationResult = await _createAccountValidator.ValidateAsync(createAccountDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _accountService.AddAccountAsync(createAccountDto);

            return NoContent();
        }



        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(UpdateAccountDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IEnumerable<FluentValidation.Results.ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateAccount(long id, [FromBody] UpdateAccountDto updateAccountDto)
        {
            var validationResult = await _updateAccountValidator.ValidateAsync(updateAccountDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _accountService.UpdateAccountAsync(id, updateAccountDto);
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
        public async Task<IActionResult> DeleteAccount(long id)
        {
            try
            {
                await _accountService.DeleteAccountAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
            return NoContent();
        }


        [HttpPost("deposit")]
        [ProducesResponseType(typeof(DepostitDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IEnumerable<FluentValidation.Results.ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Deposit([FromBody] DepostitDto depostitDto)
        {
            var validationResult = await _depostitValidator.ValidateAsync(depostitDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _accountService.DepositAsync(depostitDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return NoContent();
        }

        [HttpPost("withdraw")]
        [ProducesResponseType(typeof(WithdrawDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IEnumerable<FluentValidation.Results.ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawDto withdrawDto)
        {
            var validationResult = await _withdrawValidator.ValidateAsync(withdrawDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _accountService.WithdrawAsync(withdrawDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return NoContent();
        }

    }
}
