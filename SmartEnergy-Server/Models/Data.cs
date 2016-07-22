using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartEnergy_Server.Models
{
    public class Data
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Power { get; set; }

        [JsonIgnore]
        public virtual Devices Device { get; set; }

        [JsonIgnore]
        public virtual Users User { get; set; }
    }
}