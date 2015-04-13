using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.identity
{
	/// <summary>	A token issue request. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class TokenIssueRequest
	{
		/// <summary>	Gets or sets the message. </summary>
		/// <value>	The message. </value>
		[DataMember(Name = "auth")]
		public AuthMessage Message { get; set; }

		/// <summary>	An authentication message. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		[DataContract]
		public class AuthMessage
		{
			/// <summary>	Gets or sets the name of the tenant. </summary>
			/// <value>	The name of the tenant. </value>
			[DataMember(Name = "tenantName")]
			public string TenantName { get; set; }

			/// <summary>	Gets or sets the credentials. </summary>
			/// <value>	The credentials. </value>
			[DataMember(Name = "passwordCredentials")]
			public PasswordCredentials Credentials { get; set; }

			/// <summary>	Gets or sets the issued token. </summary>
			/// <value>	The issued token. </value>
			[DataMember(Name = "token")]
			public IssuedToken IssuedToken { get; set; }
		}

		/// <summary>	An issued token. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		[DataContract]
		public class IssuedToken
		{
			/// <summary>	Gets or sets the identifier of the token. </summary>
			/// <value>	The identifier of the token. </value>
			[DataMember(Name = "id")]
			public string TokenId { get; set; }
		}
	}

	/// <summary>	A password credentials. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class PasswordCredentials
	{
		/// <summary>	Gets or sets the name of the user. </summary>
		/// <value>	The name of the user. </value>
		[DataMember(Name = "username")]
		public string UserName { get; set; }

		/// <summary>	Gets or sets the password. </summary>
		/// <value>	The password. </value>
		[DataMember(Name = "password")]
		public string Password { get; set; }
	}
}