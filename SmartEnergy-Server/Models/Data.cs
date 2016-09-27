using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SmartEnergy_Server.Models
{
    [DataContract]
    public class Data
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public int DeviceId { get; set; }

        [DataMember]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        [DataMember]
        [Required]
        public string Label { get; set; }

        [DataMember]
        [Required]
        public decimal Value { get; set; }

        public virtual Device Device { get; set; }
    }
}