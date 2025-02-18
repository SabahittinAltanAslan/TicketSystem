using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Business.Interfaces;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;

namespace IyasBilgiIslem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, TeknikDestek")] // Sadece Admin ve Teknik Destek cihazları yönetebilir
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await _deviceService.GetAllDevicesAsync();
            return Ok(devices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceById(int id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null)
                return NotFound("Cihaz bulunamadı.");
            return Ok(device);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice([FromBody] Device device)
        {
            try
            {
                await _deviceService.AddDeviceAsync(device);
                return CreatedAtAction(nameof(GetDeviceById), new { id = device.Id }, device);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
