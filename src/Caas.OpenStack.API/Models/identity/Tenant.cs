using System;
using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.identity
{
	[DataContract]
	public class Tenant
	{
		// TODO : Map to organization detail.
		public Tenant(string description, string name, string id)
		{
			Description = description;
			Name = name;
			Id = id;
            Enabled = true;
		}

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "enabled")]
		public bool Enabled { get; set; }

		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}