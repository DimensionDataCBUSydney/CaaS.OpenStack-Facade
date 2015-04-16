// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerImage.cs" company="">
//   
// </copyright>
// <summary>
//   A server image.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;

namespace Caas.OpenStack.API.Models.image
{
	/// <summary>	A server image. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	/// <seealso cref="T:Caas.OpenStack.API.Models.image.BaseServerImage"/>
	[DataContract]
	public class ServerImage : BaseServerImage
	{
		/// <summary>	Gets or sets the created date. </summary>
		/// <value>	The created date. </value>
		[DataMember(Name = "created")]
		public string CreatedDate { get; set; }

		/// <summary>	Gets or sets the metadata. </summary>
		/// <value>	The metadata. </value>
		[DataMember(Name = "metadata")]
		public dynamic Metadata { get; set; }

		/// <summary>	Gets or sets the minimum disk. </summary>
		/// <value>	The minimum disk. </value>
		[DataMember(Name = "minDisk")]
		public int MinDisk { get; set; }

		/// <summary>	Gets or sets the minimum ram. </summary>
		/// <value>	The minimum ram. </value>
		[DataMember(Name = "minRam")]
		public int MinRam { get; set; }

		/// <summary>	This has no related attribute. </summary>
		[DataMember(Name = "progress")] 
		public int Progress = 100;

		/// <summary>	No related status. </summary>
		[DataMember(Name = "status")] 
		public string Status = "ACTIVE";

		/// <summary>	Gets or sets the updated date. </summary>
		/// <value>	The updated date. </value>
		[DataMember(Name = "updated")]
		public string UpdatedDate { get; set; }
	}
}