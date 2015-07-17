using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.server
{
	/// <summary>	A server volume metadata. </summary>
	/// <remarks>	Anthony, 4/20/2015. </remarks>
	[DataContract]
	public class ServerVolumeMetadata
	{
		/// <summary>	Gets or sets the contents. </summary>
		/// <value>	The contents. </value>
		[DataMember(Name = "contents")]
		public string Contents { get; set; }
	}

	/// <summary>	A server volume. </summary>
	/// <remarks>	Anthony, 4/20/2015. </remarks>
	[DataContract]
	public class ServerVolume
	{
		/// <summary>	Gets or sets the identifier. </summary>
		/// <value>	The identifier. </value>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>	Gets or sets the name of the display. </summary>
		/// <value>	The name of the display. </value>
		[DataMember(Name = "display_name")]
		public string DisplayName { get; set; }

		/// <summary>	Gets or sets information describing the display. </summary>
		/// <value>	Information describing the display. </value>
		[DataMember(Name = "display_description")]
		public string DisplayDescription { get; set; }

		/// <summary>	Gets or sets the size. </summary>
		/// <value>	The size. </value>
		[DataMember(Name = "size")]
		public int Size { get; set; }

		/// <summary>	Gets or sets the type of the volume. </summary>
		/// <value>	The type of the volume. </value>
		[DataMember(Name = "volume_type")]
		public string VolumeType { get; set; }

		/// <summary>	Gets or sets the metadata. </summary>
		/// <value>	The metadata. </value>
		[DataMember(Name = "metadata")]
		public ServerVolumeMetadata Metadata { get; set; }

		/// <summary>	Gets or sets the availability zone. </summary>
		/// <value>	The availability zone. </value>
		[DataMember(Name = "availability_zone")]
		public string AvailabilityZone { get; set; }

		/// <summary>	Gets or sets the identifier of the snapshot. </summary>
		/// <value>	The identifier of the snapshot. </value>
		[DataMember(Name = "snapshot_id")]
		public object SnapshotId { get; set; }

		/// <summary>	Gets or sets the attachments. </summary>
		/// <value>	The attachments. </value>
		[DataMember(Name = "attachments")]
		public List<object> Attachments { get; set; }

		/// <summary>	Gets or sets the created at. </summary>
		/// <value>	The created at. </value>
		[DataMember(Name = "created_at")]
		public string CreatedAt { get; set; }
	}
}