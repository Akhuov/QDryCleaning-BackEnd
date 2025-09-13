using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Users.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;
        private IMapper _mapper;
        public CreateUserCommandHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    LogIn = request.LogIn,
                    Password = request.Password,
                    UserRole = request.UserRole,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = _currentUserService.UserId
                };
                var ExistUser = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.LogIn == request.LogIn);
                if (ExistUser is not null)
                    throw new BadRequestExeption("User with this login already exists.");

                await _applicationDbContext.Users.AddAsync(user, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return _mapper.Map<UserDto>(user);
            }
            catch (BadRequestExeption)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
