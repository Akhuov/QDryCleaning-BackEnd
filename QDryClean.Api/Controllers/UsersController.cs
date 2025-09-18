using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QDryClean.Application.UseCases.Users.Commands;
using QDryClean.Application.UseCases.Users.Quarries;
using QDryClean.Domain.Enums;

namespace QDryClean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> CreateUserAsync(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("User created successfully.", result);
        }


        [HttpDelete]
        [Authorize(Roles = nameof(UserRole.Admin))]

        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            var command = new DeleteUserCommand
            {
                Id = userId
            };
            var result = await _mediator.Send(command);
            return Ok("User deleted successfully.");
        }


        [HttpPut]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _mediator.Send(new GetAllUsersCommand());
            return Ok(users);
        }


        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetUserByIdAsync(int userId)
        {
            var query = new GetByIdUserCommand { Id = userId };
            var user = await _mediator.Send(query);
            return Ok(user);
        }
    }
}
