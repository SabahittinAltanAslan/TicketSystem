using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IyasBilgiIslem.Core.Entities;
using IyasBilgiIslem.Business.Interfaces;
using IyasBilgiIslemTicketSystem.IyasBilgiIslem.Business.Interfaces;

namespace IyasBilgiIslem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Genel yetkilendirme (Kimliği doğrulanmış herkes)
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        // ✅ 1. Tüm şubeleri listeleme (ITEmployee ve TechnicalEmployee erişebilir)
        [HttpGet]
        [Authorize(Roles = "ITEmployee,TechnicalEmployee")]
        public async Task<IActionResult> GetAllBranches()
        {
            var branches = await _branchService.GetAllBranchesAsync();
            return Ok(branches);
        }

        // ✅ 2. Belirli bir şubeyi getirme (ITEmployee ve TechnicalEmployee erişebilir)
        [HttpGet("{id}")]
        [Authorize(Roles = "ITEmployee,TechnicalEmployee")]
        public async Task<IActionResult> GetBranchById(int id)
        {
            var branch = await _branchService.GetBranchByIdAsync(id);
            if (branch == null)
                return NotFound("Şube bulunamadı.");
            return Ok(branch);
        }

        // ✅ 3. Yeni şube ekleme (Sadece ITEmployee ekleyebilir)
        [HttpPost]
        [Authorize(Roles = "ITEmployee")]
        public async Task<IActionResult> CreateBranch([FromBody] Branch branch)
        {
            try
            {
                await _branchService.AddBranchAsync(branch);
                return CreatedAtAction(nameof(GetBranchById), new { id = branch.Id }, branch);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ✅ 4. Şube bilgilerini güncelleme (Sadece ITEmployee güncelleyebilir)
        [HttpPut("{id}")]
        [Authorize(Roles = "ITEmployee")]
        public async Task<IActionResult> UpdateBranch(int id, [FromBody] Branch branch)
        {
            try
            {
                branch.Id = id;
                await _branchService.UpdateBranchAsync(branch);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ✅ 5. Şube silme işlemi (Sadece ITEmployee silebilir)
        [HttpDelete("{id}")]
        [Authorize(Roles = "ITEmployee")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            try
            {
                var branch = await _branchService.GetBranchByIdAsync(id);
                if (branch == null)
                    return NotFound("Şube bulunamadı.");

                await _branchService.DeleteBranchAsync(branch);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
