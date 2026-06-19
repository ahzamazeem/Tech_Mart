using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name is mandatory.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        [Display(Name = "Employee Name")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address cannot be empty.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Display(Name = "Official Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select or type a designation.")]
        public string Designation { get; set; }

        [Required]
        [Range(10000, 500000, ErrorMessage = "Salary must be between 10,000 and 500,000.")]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime JoinDate { get; set; } = DateTime.Now;

    }
}
