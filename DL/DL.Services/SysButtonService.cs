/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：接口实现                                                    
*│　作    者：duling                                            
*│　版    本：1.0                                                    
*│　创建时间：2019-02-24 23:20:39                             
*└──────────────────────────────────────────────────────────────┘
*/

using DL.IRepository;
using DL.IServices;
using DL.Models;
using Microsoft.Extensions.Options;
using System;

namespace DL.Services
{
    public class SysButtonServices:BaseServices<SysButton,Int32>, ISysButtonServices
    {
		private ISysButtonRepository dal;
		public SysButtonServices(ISysButtonRepository _dal)
		{
			this.dal = _dal;
			base.baseDal = dal;
		}
    }
}