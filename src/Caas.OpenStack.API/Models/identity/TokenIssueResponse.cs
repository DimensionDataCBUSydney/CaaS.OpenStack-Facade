using System.Runtime.Serialization;
namespace Caas.OpenStack.API.Models.identity
{
	/// <summary>	A token issue response. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class TokenIssueResponse
	{
		/// <summary>	Gets or sets the access token. </summary>
		/// <value>	The access token. </value>
		[DataMember(Name = "access")]
		public AccessToken AccessToken { get; set; }
	}
}