using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SmartEnergy_Server.Models
{
    [DataContract]
    public class Device
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public int UserId { get; set; }

        [DataMember]
        [Required]
        public string HardwareId { get; set; }

        [DataMember]
        [Required]
        public string Alias { get; set; }

        public virtual User User { get; set; }

        public ICollection<Data> Data { get; set; }

    }
}