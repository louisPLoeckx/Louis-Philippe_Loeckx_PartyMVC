using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Louis_Philippe_Loeckx_PartyMVC.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Needs to be valid email")]
        public string Email { get; set; }

        [Required]
        public string Tel { get; set; }

        [Required]
        [Range(18, 60, ErrorMessage = "Age has to be between 18 and 60")]

        public int Age { get; set; }
        [Required]
        public string Adress { get; set; }

        [Required]
        [Range(1000,1500,ErrorMessage ="Postal code has to be between 1000 and 1500")]
        public int PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public bool IsFamily { get; set; }

        public Visitor() 
        {
            Id++;
        }       
        
    }
}
