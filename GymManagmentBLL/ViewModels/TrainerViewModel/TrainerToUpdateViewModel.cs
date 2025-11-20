using GymManagmentDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.TrainerViewModel
{
    internal class TrainerToUpdateViewModel
    {
        public string Name { get; set; } = null;

        [Required(ErrorMessage = "email required")]
        [EmailAddress(ErrorMessage = "invalid Email Format")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 100")]

        public string Email { get; set; } = null;

        [Required(ErrorMessage = "phone is required")]
        [Phone(ErrorMessage = "invalid phone format")]
        [RegularExpression(@"(010|011|012|015)\d{8}$")]

        public string Phone { get; set; } = null;

        [Required(ErrorMessage = "Building number is required")]
        [Range(1, 9000, ErrorMessage = "Building number should be between 1 and 9000")]

        public int BuildingNumber { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "City between 1 and 30")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City Must contain letters and spaces only")]

        public string City { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Street between 1 and 30")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "street Must contain letters and spaces only")]
        public string Street { get; set; } = null;

        [Required(ErrorMessage = "Speciality is required")]
        [EnumDataType(typeof(speciality))]
        public speciality Speciality { get; set; }

    }
}
