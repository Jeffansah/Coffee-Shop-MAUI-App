using System.ComponentModel.DataAnnotations;
namespace ApiMAUI.Data.Entities
{

    public class CoffeeOption
    {
        public int CoffeeId { get; set; }

        [Required, MaxLength(50)]

        public string Type { get; set; }

        [Required, MaxLength(50)]

        public string MilkOption { get; set; }

        public virtual Coffee Coffee { get; set; }
    }
}