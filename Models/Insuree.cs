using System; 
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 
 
namespace InsuranceApp.Models 
{ 
    public class Insuree 
    { 
        public int Id { get; set; } 
 
        [Required] 
        [Display(Name = "First Name")] 
        public string? FirstName { get; set; } 
 
        [Required] 
        [Display(Name = "Last Name")] 
        public string? LastName { get; set; } 
 
        [Required] 
        [EmailAddress] 
        public string? Email { get; set; } 
 
        [Required] 
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")] 
        public int Age { get; set; } 
 
        [Required] 
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")] 
        [Display(Name = "Car Year")] 
        public int CarYear { get; set; } 
 
        [Required] 
        [Display(Name = "Car Make")] 
        public string? CarMake { get; set; } 
 
        [Required] 
        [Display(Name = "Car Model")] 
        public string? CarModel { get; set; } 
 
        [Required] 
        [Range(0, 100, ErrorMessage = "Number of tickets must be between 0 and 100")] 
        [Display(Name = "Speeding Tickets")] 
        public int SpeedingTickets { get; set; } 
 
        [Required] 
        [Display(Name = "Has DUI")] 
        public bool HasDUI { get; set; } 
 
        [Required] 
        [Display(Name = "Full Coverage")] 
        public bool IsFullCoverage { get; set; } 
 
        [Display(Name = "Quote")] 
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Quote { get; set; } 
    } 
} 
