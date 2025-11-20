using GymManagmentDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.TrainerViewModel
{
    internal class CreateTrainerViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "name must be between 2,50")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "must conatin letters and spaces only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "invalid email format")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "email must be between 5 and 1000")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [EmailAddress(ErrorMessage = "invalid Phone format")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

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
