using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartEnergy_Server.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
    }
}