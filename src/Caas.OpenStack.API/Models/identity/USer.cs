using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.identity
{
	[DataContract]
	public class User
	{
		[DataMember(Name = "username")]
		public string UserName { get; set; }

		[DataMember(Name = "roles_links")]
		public string[] RolesLinks { get; set; }

		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "roles")]
		public Role[] Roles { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataContract]
		public class Role
		{
			[DataMember(Name = "name")]
			public string Name { get; set; }
		}
	}
}