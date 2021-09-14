using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManagementSystem.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(13)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string SaIdNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [StringLength(10)]
        public string CellNumber { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string ComplexName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public int PostalCode { get; set; }
    }
}
