using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Business.Interfaces;
using System.Security.Claims;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;

namespace IyasBilgiIslem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ITEmployee, TechnicalEmployee")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound("Ticket bulunamadı.");
            return Ok(ticket);
        }


        [HttpGet("it-tickets")]
        [Authorize(Roles = "ITEmployee")]
        public async Task<IActionResult> GetITTickets()
        {
            var tickets = await _ticketService.GetTicketsByAssignedRoleAsync("ITEmployee");
            return Ok(tickets);
        }

        [HttpGet("technical-tickets")]
        [Authorize(Roles = "TechnicalEmployee")]
        public async Task<IActionResult> GetTechnicalTickets()
        {
            var tickets = await _ticketService.GetTicketsByAssignedRoleAsync("TechnicalEmployee");
            return Ok(tickets);
        }

        [HttpPost]
        [Authorize(Roles = "TechnicalEmployee,ITEmployee,BranchEmployee")]
        public async Task<IActionResult> CreateTicket([FromBody] Ticket ticket)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                ticket.CreatedByUserId = userId;
                await _ticketService.AddTicketAsync(ticket);
                return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Id }, ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
