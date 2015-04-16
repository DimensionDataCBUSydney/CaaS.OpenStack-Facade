// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="">
//   
// </copyright>
// <summary>
//   An user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.identity
{
	/// <summary>	An user. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class User
	{
		/// <summary>	Gets or sets the name of the user. </summary>
		/// <value>	The name of the user. </value>
		[DataMember(Name = "username")]
		public string UserName { get; set; }

		/// <summary>	Gets or sets the roles links. </summary>
		/// <value>	The roles links. </value>
		[DataMember(Name = "roles_links")]
		public string[] RolesLinks { get; set; }

		/// <summary>	Gets or sets the identifier. </summary>
		/// <value>	The identifier. </value>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>	Gets or sets the roles. </summary>
		/// <value>	The roles. </value>
		[DataMember(Name = "roles")]
		public Role[] Roles { get; set; }

		/// <summary>	Gets or sets the name. </summary>
		/// <value>	The name. </value>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>	A role. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		[DataContract]
		public class Role
		{
			/// <summary>	Gets or sets the name. </summary>
			/// <value>	The name. </value>
			[DataMember(Name = "name")]
			public string Name { get; set; }
		}
	}
}