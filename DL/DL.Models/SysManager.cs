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
	[Table("SysManager")]
	public class SysManager
	{
		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int32 Id {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String QQ {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Phone {get;set;}

		/// <summary>
		///  
		/// </summary>
		[Required]
		public String MailBox {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String NickName {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String HeadPortrait {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? LoginCount {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String LastLoginIp {get;set;}

		/// <summary>
		///  
		/// </summary>
		public DateTime? LastLoginTime {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? IsDel {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? IsLock {get;set;}


	}
}
