using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/statistics")]
[ApiController]
public class StatisticsController : ControllerBase
{
    [HttpGet("problems")]
    [AllowAnonymous] // 📌 Yetkilendirme olmadan herkese açalım (Test için)
    public IActionResult GetProblemStatistics()
    {
        var data = new
        {
            labels = new List<string> { "Ağ Sorunları", "Donanım", "Yazılım", "Elektrik" },
            values = new List<int> { 16, 12, 10, 14 } // Örnek veriler, database ile değiştirebiliriz
        };

        return Ok(data);
    }

    [HttpGet("branches")]
    [AllowAnonymous] // 📌 Yetkilendirme olmadan herkese açalım (Test için)
    public IActionResult GetBranchStatistics()
    {
        var data = new
        {
            labels = new List<string> { "Iyaş Merkez", "Fatih Şubesi", "Gülistan Şubesi" },
            values = new List<int> { 30, 40, 30 } // Örnek yüzdelik veriler
        };

        return Ok(data);
    }
}
