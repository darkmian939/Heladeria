using Heladeria.Models;

namespace Heladeria.Services
{
    public interface IPurchaseOrdersService
    {
        Task<decimal> CheckUnitPrice(OrderItems detalle);
        Task<decimal> CalculateSubtotalOrderItem(OrderItems item);
        decimal CalcularTotalOrderItems(List<OrderItems> item);
    }
}