using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels
{
    internal class HealthRecordViewModel
    {
        [Required(ErrorMessage ="Height is required")]
        [Range(0.1,300,ErrorMessage ="height must be between 0.1 and 300 cm")]
        public Decimal Height { get; set; }

        [Required(ErrorMessage ="Weight is required")]
        [Range(1,350,ErrorMessage ="weight must be between 1 and 350 kg")]
        public Decimal Weight { get; set; }

        [Required(ErrorMessage = "blood type is required")]
        [StringLength(3, ErrorMessage = "Blood Type is max 3")]
        public string BloodType { get; set; } = null;

        public string? note { get; set; }
    }
}
