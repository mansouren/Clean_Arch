using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.ViewModels
{
    public class RegisterViewModel
    {
        [MaxLength(250)]
        [Required]
        public string Username { get; set; }
       
        [MaxLength(250)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(250)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [MaxLength(250)]
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }

    public enum Check
    {
        EmailAndUserNameIsNotValid,
        EmailIsNotValid,
        UserNameIsNotValid,
        Ok
    }
}
