using CandyShop.Models.Domains;

namespace CandyShop.Models.Interfaces
{
    public interface IOrderRepo
    {
        void CreateOrder(Order order);
    }
}