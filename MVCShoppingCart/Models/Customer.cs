using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCShoppingCart.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street Address is required")]
        [Display(Name = "Street Address")]
        [StringLength(160)]
        public string StreetAddress1 { get; set; }

       
        [StringLength(75)]
        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50)]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [Display(Name = "Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage="Phone Number is required")]
        [StringLength(50)]
        public string Phone { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}