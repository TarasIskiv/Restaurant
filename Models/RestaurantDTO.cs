using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class RestaurantDTO
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
        public bool HasDelivery { get; set; }

        public string ContactEmail { get; set; }

        public string ContactNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public List<DishDTO> Dishes { get; set; }
    }
}
