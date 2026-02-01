using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Data;
using OrderManagementAPI.DTOs;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Services;

public class OrdenService
{
    private readonly ApplicationDbContext _context;

    public OrdenService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<Orden>> CrearOrdenAsync(OrdenDto dto)
    {
        using var tx = await _context.Database.BeginTransactionAsync();

        try
        {
            var cliente = await _context.Clientes.FindAsync(dto.ClienteId);
            if (cliente == null)
                return Error("El cliente no existe");

            var orden = new Orden { ClienteId = dto.ClienteId };
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();

            foreach (var item in dto.Detalle)
            {
                var producto = await _context.Productos.FindAsync(item.ProductoId);
                if (producto == null)
                    return Error("Producto no existe");

                if (producto.Existencia < item.Cantidad)
                    return Error($"Stock insuficiente: {producto.Nombre}");

                var subtotal = producto.Precio * item.Cantidad;
                var impuesto = subtotal * 0.15m;
                var total = subtotal + impuesto;

                producto.Existencia -= item.Cantidad;

                _context.DetallesOrden.Add(new DetalleOrden
                {
                    OrdenId = orden.OrdenId,
                    ProductoId = producto.ProductoId,
                    Cantidad = item.Cantidad,
                    Subtotal = subtotal,
                    Impuesto = impuesto,
                    Total = total
                });

                orden.Subtotal += subtotal;
                orden.Impuesto += impuesto;
                orden.Total += total;
            }

            await _context.SaveChangesAsync();
            await tx.CommitAsync();

            return new ApiResponse<Orden>
            {
                Success = true,
                Message = "Orden creada exitosamente",
                Data = orden
            };
        }
        catch
        {
            await tx.RollbackAsync();
            return Error("Error al procesar la orden");
        }
    }

    private ApiResponse<Orden> Error(string message) =>
        new() { Success = false, Message = message };
}
