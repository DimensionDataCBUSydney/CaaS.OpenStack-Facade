using System;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.api
{
	/// <summary>	An API version. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	[DataContract]
	public class ApiVersion
	{
		/// <summary> Initializes a new instance of the ApiVersion class. </summary>
		/// <remarks>	Anthony, 4/13/2015. </remarks>
		/// <param name="baseUrl">	URL of the base. </param>
		/// <param name="status"> 	The status. </param>
		/// <param name="id">	  	The identifier. </param>
		public ApiVersion(string baseUrl, string status, string id)
		{
			Status = status;
			Id = id;
			Updated = DateTime.UtcNow.ToString("s");
			Links  = new[]
			{
				new RestLink(
					String.Format("{0}{1}/", baseUrl, Constants.CurrentApiVersion), RestLink.Self), 
			};
		}

		/// <summary>	Gets or sets the status. </summary>
		/// <value>	The status. </value>
		[DataMember(Name = "status")]
		public string Status { get; set; }

		/// <summary>	Gets or sets the updated. </summary>
		/// <value>	The updated. </value>
		[DataMember(Name = "updated")]
		public string Updated { get; set; }

		/// <summary>	Gets or sets the identifier. </summary>
		/// <value>	The identifier. </value>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>	Gets or sets the links. </summary>
		/// <value>	The links. </value>
		[DataMember(Name = "links")]
		public RestLink[] Links { get; set; }
	}
}