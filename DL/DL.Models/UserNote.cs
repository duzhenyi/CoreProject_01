/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：duling                                              
*│　版    本：1.0                                                 
*│　创建时间：2019-02-24 23:20:39                            
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Models
{
	/// <summary>
	/// duling
	/// 2019-02-24 23:20:39
	/// 
	/// </summary>
	[Table("UserNote")]
	public class UserNote
	{
		[Required]
		public String Contents {get;set;}

		[Required]
		public DateTime CreateTime {get;set;}

		[Required]
		public Int32 CreateType {get;set;}

		[Key]
		public Int32 Id {get;set;}

		public String Image {get;set;}

		[Required]
		public Int32 IsVerify {get;set;}

		public String QQ {get;set;}

		[Required]
		public Int32 SiteMenuId {get;set;}

		public String Tel {get;set;}

		[Required]
		public String Title {get;set;}

		[Required]
		public Int32 UserId {get;set;}


	}
}
