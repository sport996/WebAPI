using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the Salary.")]
        public int Salary { get; set; }

    }
}
