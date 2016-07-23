using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEnergy_Server.Models
{
    public class Devices
    {
        public int Id { get; set; }
        public string HardwareId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Users> User { get; set; }

    }
}