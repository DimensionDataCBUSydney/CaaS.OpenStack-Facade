// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extension.cs" company="">
//   
// </copyright>
// <summary>
//   An extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.api
{
	/// <summary>	An extension. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class Extension
	{
		/// <summary>	Gets or sets the alias. </summary>
		/// <value>	The alias. </value>
		[DataMember(Name = "alias")]
		public string Alias { get; set; }

		/// <summary>	Gets or sets the description. </summary>
		/// <value>	The description. </value>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>	Gets or sets the links. </summary>
		/// <value>	The links. </value>
		[DataMember(Name = "links")]
		public RestLink[] Links { get; set; }

		/// <summary>	Gets or sets the name. </summary>
		/// <value>	The name. </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>	Gets or sets the namespace. </summary>
		/// <value>	The namespace. </value>
		[DataMember(Name = "namespace")]
		public string Namespace { get; set; }

		/// <summary>	Gets or sets the updated. </summary>
		/// <value>	The updated. </value>
		[DataMember(Name = "updated")]
		public string Updated { get; set; }

		/// <summary>	Gets the key pair extension type. </summary>
		/// <value>	The key pair extension. </value>
		public static Extension KeyPairExtension
		{
			get
			{
				return new Extension
				{
					Alias = "os-keypairs", 
					Description = "Keypair Support.", 
					Links = new RestLink[0], 
					Name = "Keypairs", 
					Namespace = "http://docs.openstack.org/compute/ext/keypairs/api/v1.1", 
					Updated = "2011-08-08T00:00:00+00:00"
				};
			}
		}
	}
}