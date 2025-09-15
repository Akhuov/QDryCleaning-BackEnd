using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QDryClean.Application.UseCases.ItemCategories.Commands;
using QDryClean.Application.UseCases.ItemCategories.Querries;

namespace QDryClean.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemCategiriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemCategiriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPost]
        public async Task<IActionResult> CreateItemCategoryAsync(CreateItemCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("User created successfully.", result);
        }

        //[Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteItemCategoryAsync(DeleteItemCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPut]
        public async Task<IActionResult> UpdateItemCategoryAsync(UpdateItemCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemCategoriesAsync()
        {
            var command = new GetAllItemCategoriesQuerry();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdItemCategoryAsync(int id)
        {
            var command = new GetByIdItemCategoryQuerry() { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
