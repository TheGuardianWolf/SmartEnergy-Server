using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartEnergy_Server.Models
{
    public class Data
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        [Required]
        public int Power { get; set; }

        [JsonIgnore]
        public virtual ICollection<Devices> Device { get; set; }

        [JsonIgnore]
        public virtual ICollection<Users> User { get; set; }
    }
}