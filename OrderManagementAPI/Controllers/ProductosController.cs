using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.DTOs;
using OrderManagementAPI.Models;
using OrderManagementAPI.Services;

namespace OrderManagementAPI.Controllers;

[ApiController]
[Route("api/productos")]
public class ProductosController : ControllerBase
{
    private readonly ProductoService _service;

    public ProductosController(ProductoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await _service.GetAllAsync();
        return Ok(new ApiResponse<List<Producto>> { Success = true, Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductoDto dto)
    {
        var producto = new Producto
        {
            ProductoId = dto.ProductoId,
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Precio = dto.Precio,
            Existencia = dto.Existencia
        };

        var error = await _service.CreateAsync(producto);
        if (error != null)
            return BadRequest(new ApiResponse<object> { Success = false, Errors = { error } });

        return Ok(new ApiResponse<Producto> { Success = true, Data = producto });
    }
}
