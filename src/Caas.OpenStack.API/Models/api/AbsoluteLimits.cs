using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.api
{
	/// <summary>	An absolute limits. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class AbsoluteLimits
	{
		/// <summary>	Gets or sets the maximum image meta. </summary>
		/// <value>	The maximum image meta. </value>
		[DataMember(Name = "maxImageMeta")]
		public int MaxImageMeta { get; set; }

		/// <summary>	Gets or sets the maximum personality. </summary>
		/// <value>	The maximum personality. </value>
		[DataMember(Name = "maxPersonality")]
		public int MaxPersonality { get; set; }

		/// <summary>	Gets or sets the size of the maximum personality. </summary>
		/// <value>	The size of the maximum personality. </value>
		[DataMember(Name = "maxPersonalitySize")]
		public int MaxPersonalitySize { get; set; }

		/// <summary>	Gets or sets the maximum security group rules. </summary>
		/// <value>	The maximum security group rules. </value>
		[DataMember(Name = "maxSecurityGroupRules")]
		public int MaxSecurityGroupRules { get; set; }

		/// <summary>	Gets or sets the groups the maximum security belongs to. </summary>
		/// <value>	The maximum security groups. </value>
		[DataMember(Name = "maxSecurityGroups")]
		public int MaxSecurityGroups { get; set; }

		/// <summary>	Gets or sets the maximum server meta. </summary>
		/// <value>	The maximum server meta. </value>
		[DataMember(Name = "maxServerMeta")]
		public int MaxServerMeta { get; set; }

		/// <summary>	Gets or sets the maximum total cores. </summary>
		/// <value>	The maximum total cores. </value>
		[DataMember(Name = "maxTotalCores")]
		public int MaxTotalCores { get; set; }

		/// <summary>	Gets or sets the maximum total floating ips. </summary>
		/// <value>	The maximum total floating ips. </value>
		[DataMember(Name = "maxTotalFloatingIps")]
		public int MaxTotalFloatingIps { get; set; }

		/// <summary>	Gets or sets the maximum total instances. </summary>
		/// <value>	The maximum total instances. </value>
		[DataMember(Name = "maxTotalInstances")]
		public int MaxTotalInstances { get; set; }

		/// <summary>	Gets or sets the maximum total key pairs. </summary>
		/// <value>	The maximum total key pairs. </value>
		[DataMember(Name = "maxTotalKeypairs")]
		public int MaxTotalKeypairs { get; set; }

		/// <summary>	Gets or sets the size of the maximum total ram. </summary>
		/// <value>	The size of the maximum total ram. </value>
		[DataMember(Name = "maxTotalRAMSize")]
		public int MaxTotalRamSize { get; set; }

		/// <summary>	Gets or sets the groups the maximum server belongs to. </summary>
		/// <value>	The maximum server groups. </value>
		[DataMember(Name = "maxServerGroups")]
		public int MaxServerGroups { get; set; }

		/// <summary>	Gets or sets the maximum server group members. </summary>
		/// <value>	The maximum server group members. </value>
		[DataMember(Name = "maxServerGroupMembers")]
		public int MaxServerGroupMembers { get; set; }
	}
}