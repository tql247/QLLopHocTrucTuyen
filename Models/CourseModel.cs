using System;
using System.Collections.Generic; 
using System.ComponentModel;  
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace QLLopHocTrucTuyen.Models
{
    public class Course
    {
        public int ID {get; set; }

        [Required]
        public string Name {get; set; }
    
        [Required]
        public string Fee {get; set; }
        public string Description {get; set; }
        public string Teacher {get; set; }
    }
}