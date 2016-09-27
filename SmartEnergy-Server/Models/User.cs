using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SmartEnergy_Server.Models
{
    /// <summary>
    /// A set of endpoints relating to user data.
    /// </summary>
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [RegularExpression(@"^(?!.*[._-]{2})[a-z][a-z0-9._-]*[a-z0-9]$")]
        public string Username { get; set; }

        public ICollection<Device> Device { get; set; }

        public ICollection<Data> Data { get; set; }
    }
}