using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudBlazor.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "First Name cannot contain numbers")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Last Name cannot contain numbers")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage ="Wrong phone format")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
 

    }
}
