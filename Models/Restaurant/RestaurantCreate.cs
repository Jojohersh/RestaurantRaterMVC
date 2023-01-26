
using System.ComponentModel.DataAnnotations;

public class RestaurantCreate
    {
        [Required]
        [StringLength(100)]
        public string Name {get; set;}
        [Required]
        [StringLength(100)]
        public string Location {get; set;}
    }
