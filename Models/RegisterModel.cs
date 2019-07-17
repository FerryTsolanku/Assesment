using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assesment.Models
{
    public class RegisterModel
    {
        [Key]
        public int RegNo { get; set; }
        [Required(ErrorMessage = "Name is required. ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required. ")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Conferm password is reqired")]
        public string ConfirmPassword { get; set; }
        public Country Countries { get; set; }
        public string FavouriteColor { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Comments { get; set; }
    }

    public enum Country
    {
        South_Africa = 0,
        Mozambique = 1,
        Malawi = 2,
        Negeria = 3,
        Congo = 4,
        Kenya = 5,
        Egypt = 6,
        Ghana = 7,
        Cameroon = 8,
        Zimbabwe= 9
    }
}