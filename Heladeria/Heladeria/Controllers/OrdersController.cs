using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Heladeria.Data;
using Heladeria.Services;
using Heladeria.Models;

namespace Heladeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPurchaseOrdersService _purchaseOrdersService;

        public OrdersController(ApplicationDbContext context, IPurchaseOrdersService purchaseOrdersService)
        {
            _context = context;
            _purchaseOrdersService = purchaseOrdersService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            return await _context.Orders.Include(oi => oi.OrderItems).ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
          
            var order = await _context.Orders.Include(oi => oi.OrderItems)
                                     .FirstOrDefaultAsync(o => o.Id == id); 

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Orders order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrder(Orders order)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }

            // Recorremos cada detalle en la orden de compra
            foreach (var detalle in order.OrderItems)
            {
                // Asignar el precio unitario del producto al detalle
                detalle.UnitPrice = await _purchaseOrdersService.CheckUnitPrice(detalle);

                // Calcular el subtotal
                detalle.Subtotal = await _purchaseOrdersService.CalculateSubtotalOrderItem(detalle);
            }

            // Asignar el total calculado a la orden de compra (si tienes una propiedad explicita para el total en tu modelo)
            order.TotalAmount = _purchaseOrdersService.CalcularTotalOrderItems((List<OrderItems>)order.OrderItems);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}