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
	[Table("SysMenu")]
	public class SysMenu
	{
		public String ButtonIds {get;set;}

		[Required]
		public String Icon {get;set;}

		[Key]
		public Int32 Id {get;set;}

		[Required]
		public Int32 IsDefault {get;set;}

		[Required]
		public Int32 IsShow {get;set;}

		[Required]
		public String Name {get;set;}

		[Required]
		public Int32 ParentId {get;set;}

		public String Remarks {get;set;}

		[Required]
		public Int32 Sort {get;set;}


	}
}
