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

        public int DeviceId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public decimal Value { get; set; }

        [JsonIgnore]
        public virtual Device Device { get; set; }
    }
}