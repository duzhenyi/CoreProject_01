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
	[Table("SysManager")]
	public class SysManager
	{
		public String HeadPortrait {get;set;}

		[Key]
		public Int32 Id {get;set;}

		[Required]
		public Int32 IsDel {get;set;}

		[Required]
		public Int32 IsLock {get;set;}

		public String LastLoginIp {get;set;}

		public DateTime? LastLoginTime {get;set;}

		public Int32? LoginCount {get;set;}

		public String MailBox {get;set;}

		public String NickName {get;set;}

		public String Phone {get;set;}

		public String QQ {get;set;}


	}
}
