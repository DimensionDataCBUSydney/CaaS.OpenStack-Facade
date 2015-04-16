// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageNotFoundException.cs" company="">
//   
// </copyright>
// <summary>
//   Exception for signalling image not found errors.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;

namespace Caas.OpenStack.API.Exceptions
{
	/// <summary>	Exception for signalling image not found errors. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	public class ImageNotFoundException :
		Exception
	{
	}
}