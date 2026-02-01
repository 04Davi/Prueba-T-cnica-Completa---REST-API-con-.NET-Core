using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.DTOs;
using OrderManagementAPI.Models;
using OrderManagementAPI.Services;

namespace OrderManagementAPI.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    private readonly ClienteService _service;

    public ClientesController(ClienteService service)
    {
        _service = service;
    }

    [HttpGet]
public async Task<IActionResult> Get()
{
    try
    {
        var data = await _service.GetAllAsync();

        return Ok(new ApiResponse<List<Cliente>>
        {
            Success = true,
            Data = data
        });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new ApiResponse<object>
        {
            Success = false,
            Errors = { ex.Message }
        });
    }
}
}
