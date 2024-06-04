using System.ComponentModel.DataAnnotations;

namespace LearnBlazorV1.Types
{
    public class UserType
    {
        public string Email { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class UserFilter
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    public class UserForm
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(40, ErrorMessage = "Name must be less than 40 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
    }
}
