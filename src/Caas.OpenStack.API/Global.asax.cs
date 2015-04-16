// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="">
//   
// </copyright>
// <summary>
//   A global.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;

namespace Caas.OpenStack.API
{
	/// <summary>	A global. </summary>
	/// <remarks>	Anthony, 4/13/2015. </remarks>
	/// <seealso cref="T:System.Web.HttpApplication"/>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// 	Event handler. Called by Application for start events. 
		/// </summary>
		/// <remarks>
		/// 	Anthony, 4/13/2015. 
		/// </remarks>
		/// <param name="sender">
		/// 	Source of the event. 
		/// </param>
		/// <param name="e">
		/// 	 	Event information. 
		/// </param>
		protected void Application_Start(object sender, EventArgs e)
		{
		}
	}
}