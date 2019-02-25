/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：duling                                              
*│　版    本：1.0                                                 
*│　创建时间：2019-02-24 23:20:39                           
*└──────────────────────────────────────────────────────────────┘
*/

using DL.Models;
using System;

namespace DL.IRepository
{
    public interface IUserInfoRepository : IBaseRepository<UserInfo, Int32>
    {
    }
}