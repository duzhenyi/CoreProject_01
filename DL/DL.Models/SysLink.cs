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
	[Table("SysLink")]
	public class SysLink
	{
		public DateTime? CreateTime {get;set;}

		public String Icon {get;set;}

		[Key]
		public Int32 Id {get;set;}

		public Int32? IsVerify {get;set;}

		public Int32? LocationType {get;set;}

		public String Name {get;set;}

		public Int32? Sort {get;set;}

		public String Url {get;set;}


	}
}
