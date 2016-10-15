using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SmartEnergy_Server.Models
{
	/// <summary>
    /// A set of endpoints relating to device data.
    /// </summary>
    [DataContract]
    public class Device
    {
		/// <summary>
        /// The device ID.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

		/// <summary>
        /// The userID for the device.
        /// </summary>
        [DataMember]
        [Required]
        public int UserId { get; set; }

		/// <summary>
        /// The hardwareID for the device.
        /// </summary>
        [DataMember]
        [Required]
        public string HardwareId { get; set; }

		/// <summary>
        /// The name of the device.
        /// </summary>
        [DataMember]
        [Required]
        public string Alias { get; set; }

		/// <summary>
        /// The user of the device.
        /// </summary>
        public virtual User User { get; set; }

		/// <summary>
        /// The data the device has.
        /// </summary>
        public ICollection<Data> Data { get; set; }

    }
}