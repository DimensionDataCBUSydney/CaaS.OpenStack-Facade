using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.identity
{
	[DataContract]
	public class TokenIssueRequest
	{
		[DataMember(Name = "auth")]
		public AuthMessage Message { get; set; }

		[DataContract]
		public class AuthMessage
		{
			
			[DataMember(Name = "tenantName")]
			public string TenantName { get; set; }

			[DataMember(Name = "passwordCredentials")]
			public PasswordCredentials Credentials { get; set; }

			[DataMember(Name = "token")]
			public IssuedToken IssuedToken { get; set; }
		}

		[DataContract]
		public class IssuedToken
		{
			[DataMember(Name = "id")]
			public string TokenId { get; set; }}
		}

		[DataContract]
		public class PasswordCredentials
		{
			[DataMember(Name = "username")]
			public string UserName { get; set; }

			[DataMember(Name = "password")]
			public string Password { get; set; }
	}
}