using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartEnergy_Server.Models
{
    /// <summary>
    /// A set of endpoints relating to user data.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [JsonIgnore]
        public virtual ICollection<Device> Device { get; set; }

        [JsonIgnore]
        public virtual ICollection<Data> Data { get; set; }
    }
}