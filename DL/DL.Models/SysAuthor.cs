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
	[Table("SysAuthor")]
	public class SysAuthor
	{
		[Key]
		public Int32 Id {get;set;}

		[Required]
		public Int32 MenuId {get;set;}

		[Required]
		public Int32 RoleId {get;set;}


	}
}
