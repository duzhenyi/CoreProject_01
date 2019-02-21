/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：接口实现                                                    
*│　作    者：duling                                            
*│　版    本：1.0                                                    
*│　创建时间：2018-12-29 14:04:25                             
*└──────────────────────────────────────────────────────────────┘
*/

using DL.IRepository;
using DL.IServices;
using DL.Models;
using Microsoft.Extensions.Options;
using System;

namespace DL.Services
{
    public class SysMenuServices:BaseServices<SysMenu,Int32>, ISysMenuServices
    {
		private ISysMenuRepository dal;
		public SysMenuServices(ISysMenuRepository _dal)
		{
			this.dal = _dal;
			base.baseDal = dal;
		}
    }
}