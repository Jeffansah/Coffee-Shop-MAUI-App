using System.ComponentModel.DataAnnotations;
namespace ApiMAUI.Data.Entities
{

    public class OrderItem
    {
        [Key]

        public long Id { get; set; }

        public long OrderId { get; set; }

        public int CoffeeId { get; set; }

        [Required, MaxLength(100)]

        public string Name { get; set; }

        [Range(0.1, double.MaxValue)]

        public double Price { get; set; }

        [Range(0.1, 100)]

        public int Quantity { get; set; }

        [Required, MaxLength(50)]

        public string Type { get; set; }

        [Required, MaxLength(50)]

        public string MilkOption { get; set; }

        [Range(0.1, double.MaxValue)]

        public double TotalPrice { get; set; }

        public virtual Order Order { get; set; }
    }
}