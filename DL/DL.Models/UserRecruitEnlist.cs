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
	[Table("UserRecruitEnlist")]
	public class UserRecruitEnlist
	{
		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int32 Id {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? RecruitId {get;set;}

		/// <summary>
		///  
		/// </summary>
		public Int32? UserId {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Name {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String Phone {get;set;}

		/// <summary>
		///  
		/// </summary>
		public String IDCard {get;set;}

		/// <summary>
		///  
		/// </summary>
		public DateTime? CreatTime {get;set;}


	}
}
