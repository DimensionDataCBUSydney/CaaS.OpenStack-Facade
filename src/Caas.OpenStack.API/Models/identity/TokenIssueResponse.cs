using System.Runtime.Serialization;
namespace Caas.OpenStack.API.Models.identity
{
	[DataContract]
	public class TokenIssueResponse
	{
		[DataMember(Name = "access")]
		public AccessToken AccessToken { get; set; }
	}
}