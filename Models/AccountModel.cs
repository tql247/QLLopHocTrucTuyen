using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLLopHocTrucTuyen.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [StringLength(100)]
        //[Required]
        public string FullName { get; set; }
        public string RoleName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
