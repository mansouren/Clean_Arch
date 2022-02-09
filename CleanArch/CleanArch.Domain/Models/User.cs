using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Username { get; set; }

        [MaxLength(250)]
        [Required]
        public string Email { get; set; }

        [MaxLength(250)]
        [Required]
        public string Password { get; set; }
    }
}
