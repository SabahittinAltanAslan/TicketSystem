using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using IyasBilgiIslem.Business.Interfaces;
using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Data.Repositories;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Data.Interfaces;

namespace IyasBilgiIslem.Business.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IStatusLogRepository _statusLogRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly IValidator<Ticket> _ticketValidator;

        public TicketService(
            ITicketRepository ticketRepository,
            IStatusLogRepository statusLogRepository,
            IDeviceRepository deviceRepository,
            UnitOfWork unitOfWork,
            IValidator<Ticket> ticketValidator)
        {
            _ticketRepository = ticketRepository;
            _statusLogRepository = statusLogRepository;
            _deviceRepository = deviceRepository;
            _unitOfWork = unitOfWork;
            _ticketValidator = ticketValidator; 
        }
        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _ticketRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId)
        {
            var tickets = await _ticketRepository.GetAllAsync();
            return tickets.Where(t => t.CreatedByUserId == userId);
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            var validationResult = await _ticketValidator.ValidateAsync(ticket);
            if (!validationResult.IsValid)
            {
                throw new Exception(string.Join(" | ", validationResult.Errors));
            }

            // **Kategoriye göre rol atanıyor**
            ticket.AssignedRole = ticket.CategoryId == 1 ? "TechnicalEmployee" : "ITEmployee";

            await _ticketRepository.AddAsync(ticket);
        }

        public async Task UpdateTicketStatusAsync(int ticketId, TicketStatus newStatus, int userId)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket == null)
            {
                throw new Exception("Ticket bulunamadı!");
            }

            var oldStatus = ticket.Status;
            ticket.Status = newStatus;
            _ticketRepository.Update(ticket);
            
            var statusLog = new StatusLog
            {
                TicketId = ticketId,
                OldStatus = oldStatus,
                NewStatus = newStatus,
                ChangedByUserId = userId,
                ChangedAt = DateTime.UtcNow
            };
            await _unitOfWork.StatusLogs.AddAsync(statusLog); 

            if (newStatus == TicketStatus.Completed && ticket.DeviceId.HasValue)
            {
                var device = await _deviceRepository.GetByIdAsync(ticket.DeviceId.Value);
                if (device != null)
                {
                    device.Status = DeviceStatus.Working;
                    _deviceRepository.Update(device);
                }
            }

            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByAssignedRoleAsync(string assignedRole)
        {
            return await _ticketRepository.GetTicketsByAssignedRoleAsync(assignedRole);
        }
    }
}
