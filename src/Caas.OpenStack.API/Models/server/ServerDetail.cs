using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Caas.OpenStack.API.Models.image;

namespace Caas.OpenStack.API.Models.server
{
	/*
        {
            "accessIPv4": "",
            "accessIPv6": "",
            "addresses": {
                "private": [
                    {
                        "addr": "192.168.0.3",
                        "version": 4
                    }
                ]
            },
            "created": "2012-09-07T16:56:37Z",
            "flavor": {
                "id": "1",
                "links": [
                    {
                        "href": "http://openstack.example.com/openstack/flavors/1",
                        "rel": "bookmark"
                    }
                ]
            },
            "hostId": "16d193736a5cfdb60c697ca27ad071d6126fa13baeb670fc9d10645e",
            "id": "05184ba3-00ba-4fbc-b7a2-03b62b884931",
            "image": {
                "id": "70a599e0-31e7-49b7-b260-868f441e862b",
                "links": [
                    {
                        "href": "http://openstack.example.com/openstack/images/70a599e0-31e7-49b7-b260-868f441e862b",
                        "rel": "bookmark"
                    }
                ]
            },
            "links": [
                {
                    "href": "http://openstack.example.com/v2/openstack/servers/05184ba3-00ba-4fbc-b7a2-03b62b884931",
                    "rel": "self"
                },
                {
                    "href": "http://openstack.example.com/openstack/servers/05184ba3-00ba-4fbc-b7a2-03b62b884931",
                    "rel": "bookmark"
                }
            ],
            "metadata": {
                "My Server Name": "Apache1"
            },
            "name": "new-server-test",
            "progress": 0,
            "status": "ACTIVE",
            "tenant_id": "openstack",
            "updated": "2012-09-07T16:56:37Z",
            "user_id": "fake"
        }
    */
	[DataContract]
	public class ServerDetail
	{
		[DataMember(Name = "accessIPv4")]
		public string AccessIPv4 { get; set; }

		[DataMember(Name = "accessIPv6")]
		public string AccessIPv6 { get; set; }

		[DataMember(Name = "addresses")]
		public IPAddressCollection IpAddressCollection { get; set; }

		[DataMember(Name = "created")]
		public string CreatedDate { get; set; }

		[DataMember(Name = "updated")]
		public string UpdatedDate { get; set; }

		[DataMember(Name = "hostId")]
		public string HostId { get; set; }
		
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "image")]
		public image.ServerImage Image { get; set; }

		[DataMember(Name = "links")]
		public RestLink[] Links { get; set; }

		[DataMember(Name = "metadata")]
		public KeyValuePair<string, string> Metadata { get; set; }
 
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "progress")]
		public int Progress { get; set; }

		[DataMember(Name = "status")]
		public string ServerStatusString
		{
			get { return Status.ToString().ToUpper(); }
			set
			{
				ServerStatus status;
				if (Enum.TryParse(value, out status))
				{
					Status = status;
				}
			}
		}

		public ServerStatus Status { get; set; }

		[DataMember(Name = "tenant_id")]
		public string TenantId { get; set; }

		[DataMember(Name = "user_id")]
		public string UserId { get; set; }
	}
}