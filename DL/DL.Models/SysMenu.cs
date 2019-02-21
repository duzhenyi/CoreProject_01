/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：duling                                              
*│　版    本：1.0                                                 
*│　创建时间：2018-12-28 09:42:34                            
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Models
{
	/// <summary>
	/// duling
	/// 2018-12-28 09:42:34
	/// 
	/// </summary>
	[Table("SysMenu")]
	public class SysMenu
	{
		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int32 Id {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? ParentId {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Name {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Icon {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Url {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String ButtonIds {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? Sort {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Remarks {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? IsShow {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? IsDefault {get;set;}


	}
}
