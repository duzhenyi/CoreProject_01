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
	[Table("UserRecruit")]
	public class UserRecruit
	{
		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int32 Id {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? UserId {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Title {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Contents {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Money {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Tel {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String WorkTime {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? WorkTrade {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? WorkType {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? WorkCount {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? IsVerify {get;set;}

		/// <summary>
		///  
		/// </summary>
		public DateTime? CreateTime {get;set;}


	}
}
