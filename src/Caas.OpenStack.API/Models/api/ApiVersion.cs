using System;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.api
{
	[DataContract]
	public class ApiVersion
	{
		private string _baseUrl;

		public ApiVersion(string baseUrl, string status, string id)
		{
			Status = status;
			Id = id;
			_baseUrl = baseUrl;
			Updated = DateTime.UtcNow.ToString("s");
			Links  = new RestLink[]
			{
				new RestLink(_baseUrl + "v2/", RestLink.Self), 
			};
		}

		[DataMember(Name = "status")]
		public string Status { get; set; }

		[DataMember(Name = "updated")]
		public string Updated { get; set; }

		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "links")]
		public RestLink[] Links { get; set; }

	}
}