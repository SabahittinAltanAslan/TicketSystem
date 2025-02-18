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
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly IValidator<Device> _deviceValidator;

        public DeviceService(IDeviceRepository deviceRepository, UnitOfWork unitOfWork, IValidator<Device> deviceValidator)
        {
            _deviceRepository = deviceRepository;
            _unitOfWork = unitOfWork;
            _deviceValidator = deviceValidator;
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await _deviceRepository.GetAllAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(int id)
        {
            return await _deviceRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Device>> GetDevicesByBranchAsync(int branchId)
        {
            return await _deviceRepository.GetDevicesByBranchAsync(branchId);
        }

        public async Task AddDeviceAsync(Device device)
        {
            var validationResult = await _deviceValidator.ValidateAsync(device);
            if (!validationResult.IsValid)
            {
                throw new Exception(string.Join(" | ", validationResult.Errors));
            }

            await _deviceRepository.AddAsync(device);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateDeviceAsync(Device device)
        {
            _deviceRepository.Update(device);
            await _unitOfWork.CompleteAsync();
        }
    }
}
