using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Data;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Services;

public class ClienteService
{
    private readonly ApplicationDbContext _context;

    public ClienteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
        => await _context.Clientes.AsNoTracking().ToListAsync();

    public async Task<Cliente?> GetByIdAsync(long id)
        => await _context.Clientes.FindAsync(id);

    public async Task<string?> CreateAsync(Cliente cliente)
    {
        if (cliente.ClienteId != 0)
            return "El ClienteId debe ser 0";

        if (string.IsNullOrWhiteSpace(cliente.Nombre) || cliente.Nombre.Length < 3)
            return "Nombre inválido";

        if (await _context.Clientes.AnyAsync(c => c.Identidad == cliente.Identidad))
            return "Identidad duplicada";

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return null;
    }
}
