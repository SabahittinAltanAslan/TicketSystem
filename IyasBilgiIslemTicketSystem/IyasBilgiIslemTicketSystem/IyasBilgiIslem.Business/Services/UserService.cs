using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Data.Repositories;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces;

namespace IyasBilgiIslem.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly IValidator<User> _userValidator;

        public UserService(IUserRepository userRepository, UnitOfWork unitOfWork, IValidator<User> userValidator)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _userValidator = userValidator;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task AddUserAsync(User user)
        {
            var validationResult = await _userValidator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                throw new Exception(string.Join(" | ", validationResult.Errors));
            }

            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
    }
}
