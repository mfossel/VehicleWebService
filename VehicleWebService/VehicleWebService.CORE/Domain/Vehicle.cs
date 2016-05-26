
using System.ComponentModel.DataAnnotations;

namespace VehicleWebService.CORE

{
    public class Vehicle
    {

        public int Id { get; set; }

        [Range(1950,2050,ErrorMessage = "The year must be between 1950 and 2050")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Vehicle name is required")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

    }

}
