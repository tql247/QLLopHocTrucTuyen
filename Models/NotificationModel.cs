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
    public class Notification
    {
        public int ID {get; set; }

        [Required]
        public string Title {get; set; }
    
        [Required]
        public string Content {get; set; }
    }
}