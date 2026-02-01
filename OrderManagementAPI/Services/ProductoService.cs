using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Data;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Services;

public class ProductoService
{
    private readonly ApplicationDbContext _context;

    public ProductoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Producto>> GetAllAsync()
        => await _context.Productos.AsNoTracking().ToListAsync();

    public async Task<string?> CreateAsync(Producto producto)
    {
        if (producto.ProductoId != 0)
            return "ProductoId debe ser 0";

        if (producto.Precio <= 0)
            return "Precio inválido";

        if (producto.Existencia < 0)
            return "Existencia inválida";

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return null;
    }
}
