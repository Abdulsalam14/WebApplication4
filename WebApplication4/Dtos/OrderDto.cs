using WebApplication4.Entities;

namespace WebApplication4.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ProductName { get; set; }
        public string? CustomerName { get; set; }
    }
}
