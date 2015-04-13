using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.identity
{
	/// <summary>	A tenant. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class Tenant
	{
		/// <summary>	TODO : Map to organization detail. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="description">	The description. </param>
		/// <param name="name">		  	The name. </param>
		/// <param name="id">		  	The identifier. </param>
		public Tenant(string description, string name, string id)
		{
			Description = description;
			Name = name;
			Id = id;
            Enabled = true;
		}

		/// <summary>	Gets or sets the description. </summary>
		/// <value>	The description. </value>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>	Gets or sets a value indicating whether this object is enabled. </summary>
		/// <value>	true if enabled, false if not. </value>
		[DataMember(Name = "enabled")]
		public bool Enabled { get; set; }

		/// <summary>	Gets or sets the identifier. </summary>
		/// <value>	The identifier. </value>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>	Gets or sets the name. </summary>
		/// <value>	The name. </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}