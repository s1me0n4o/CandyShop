using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models.Domains
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

        [Required(ErrorMessage ="Please enter your first name")]
        [Display(Name ="First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Address line 1")]
        [StringLength(75)]
        public string Adress1 { get; set; }
        
        [StringLength(75)]
        [Display(Name = "Address line 2")]
        public string Adress2 { get; set; }

        [Required(ErrorMessage = "Please enter your ZIP Code")]
        [Display(Name = "Zip Code")]
        [StringLength(10, MinimumLength =4)]
        public string ZipCode { get; set; }
        
        [StringLength(50)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        [StringLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [Display(Name = "Phone Number")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
            ErrorMessage = "The email is not entered or in a correct format")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public string OrderTotal { get; set; }
        
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }
    }
}
