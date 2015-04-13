using System.Runtime.Serialization;
using Caas.OpenStack.API.Models.serviceCatalog;

namespace Caas.OpenStack.API.Models.identity
{
	/// <summary>	The access token. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class AccessToken
	{
		/// <summary>	Gets or sets the token. </summary>
		/// <value>	The token. </value>
		[DataMember(Name = "token")]
		public Token Token { get; set; }

		/// <summary>	Gets or sets the catalogue. </summary>
		/// <value>	The catalogue. </value>
		[DataMember(Name = "serviceCatalog")]
		public ServiceCatalogEntry[] Catalog { get; set; }

		/// <summary>	Gets or sets the user. </summary>
		/// <value>	The user. </value>
		[DataMember(Name = "user")]
		public User User { get; set; }

		/// <summary>	A metadata. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		[DataContract]
		public class Metadata
		{
			/// <summary>	Gets or sets the is admin. </summary>
			/// <value>	The is admin. </value>
			[DataMember(Name = "is_admin")]
			public int IsAdmin { get; set; }

			/// <summary>	Gets or sets the roles. </summary>
			/// <value>	The roles. </value>
			[DataMember(Name = "roles")]
			public string[] Roles { get; set; }
		}
	}
}