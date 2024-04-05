﻿using System.ComponentModel.DataAnnotations;
namespace ApiMAUI.Data.Entities
{

    public class Coffee
    {
        [Key]

        public int Id { get; set; }

        [Required, MaxLength(100)]

        public string Name { get; set; }

        [Range(0.1, double.MaxValue)]

        public double Price { get; set; }

        [Required, MaxLength(180)]

        public string Image { get; set; }

        public virtual ICollection<CoffeeOption> Options { get; set; }
    }
}