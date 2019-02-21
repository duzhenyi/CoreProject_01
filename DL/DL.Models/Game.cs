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
	[Table("Game")]
	public class Game
	{
		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int32 Id {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Name {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Image {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Url {get;set;}

		/// <summary>
		///  
		/// </summary>
		public DateTime? CreateTime {get;set;}


	}
}
