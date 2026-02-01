using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.DTOs;
using OrderManagementAPI.Services;

namespace OrderManagementAPI.Controllers;

[ApiController]
[Route("api/ordenes")]
public class OrdenesController : ControllerBase
{
    private readonly OrdenService _service;

    public OrdenesController(OrdenService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post(OrdenDto dto)
    {
        var result = await _service.CrearOrdenAsync(dto);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
