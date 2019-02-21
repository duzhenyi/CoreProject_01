/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：接口实现                                                    
*│　作    者：duling                                            
*│　版    本：1.0                                                    
*│　创建时间：2018-12-29 13:58:45                             
*└──────────────────────────────────────────────────────────────┘
*/

using DL.IRepository;
using DL.Models;
using Microsoft.Extensions.Options;
using System;

namespace DL.Repository.SqlServer
{
    public class SysMenuRepository:BaseRepository<SysMenu,Int32>, ISysMenuRepository
    {
 

    }
}