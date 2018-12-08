﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DL.Common.Config;
using DL.Common.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DL.Common.Net
{
    /// <summary>
    /// Web操作扩展
    /// </summary>
    public static class WebExtension
    {
        #region 获取线程内唯一的EF上下文对象

        /// <summary>
        /// 获取线程内唯一的EF上下文对象，.NetCore中获取EF数据上下文对象，需要通过依赖注入的方式，请考虑在自己的项目中通过DL.Common提供的CallContext对象实现获取线程内唯一的EF上下文对象，示例代码：
        /// <para>public static DataContext GetDbContext()</para>
        /// <para>{</para>
        /// <para>    DataContext db;</para>
        /// <para>    if (CallContext&lt;DataContext>.GetData("db") is null)</para>
        /// <para>    {</para>
        /// <para>        DbContextOptions&lt;DataContext> dbContextOption = new DbContextOptions&lt;DataContext>();</para>
        /// <para>        DbContextOptionsBuilder&lt;DataContext> dbContextOptionBuilder = new DbContextOptionsBuilder&lt;DataContext>(dbContextOption);</para>
        /// <para>        db = new DataContext(dbContextOptionBuilder.UseSqlServer(CommonHelper.ConnectionString).Options);</para>
        /// <para>        CallContext&lt;DataContext>.SetData("db", db);</para>
        /// <para>    }</para>
        /// <para>    db = CallContext&lt;DataContext>.GetData("db");</para>
        /// <para>    return db;</para>
        /// <para>}</para>
        /// </summary>
        /// <typeparam name="T">EF上下文容器对象</typeparam>
        /// <returns>EF上下文容器对象</returns>
        [Obsolete(@".NetCore中获取EF数据上下文对象，需要通过依赖注入的方式，请考虑在自己的项目中通过DL.Common提供的CallContext对象实现获取线程内唯一的EF上下文对象，示例代码：
        public static DataContext GetDbContext()
        {
            DataContext db;
            if (CallContext<DataContext>.GetData(""db"") is null)
            {
                DbContextOptions<DataContext> dbContextOption = new DbContextOptions<DataContext>();
                DbContextOptionsBuilder<DataContext> dbContextOptionBuilder = new DbContextOptionsBuilder<DataContext>(dbContextOption);
                db = new DataContext(dbContextOptionBuilder.UseSqlServer(CommonHelper.ConnectionString).Options);
                CallContext<DataContext>.SetData(""db"", db);
            }
            db = CallContext<DataContext>.GetData(""db"");
            return db;
        }")]
        public static T GetDbContext<T>() where T : new()
        {
            throw new Exception(@".NetCore中获取EF数据上下文对象，需要通过依赖注入的方式，请考虑在自己的项目中通过DL.Common提供的CallContext对象实现获取线程内唯一的EF上下文对象，示例代码：
                                        public static DataContext GetDbContext()
                                        {
                                            DataContext db;
                                            if (CallContext<DataContext>.GetData(""db"") is null)
                                            {
                                                DbContextOptions<DataContext> dbContextOption = new DbContextOptions<DataContext>();
                                                DbContextOptionsBuilder<DataContext> dbContextOptionBuilder = new DbContextOptionsBuilder<DataContext>(dbContextOption);
                                                db = new DataContext(dbContextOptionBuilder.UseSqlServer(CommonHelper.ConnectionString).Options);
                                                CallContext<DataContext>.SetData(""db"", db);
                                            }
                                            db = CallContext<DataContext>.GetData(""db"");
                                            return db;
                                        }
        ");
        }

        #endregion

        #region 获取客户端IP地址信息

        /// <summary>
        /// 根据IP地址获取详细地理信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static async Task<Tuple<string, List<string>>> GetIPAddressInfo(this string ip)
        {
            ip.MatchInetAddress(out var isIpAddress);
            if (isIpAddress)
            {
                var address = await GetPhysicsAddressInfo(ip);
                if (address.Status == 0)
                {
                    string detail = $"{address.AddressResult.FormattedAddress} {address.AddressResult.AddressComponent.Direction}{address.AddressResult.AddressComponent.Distance ?? "0"}米";
                    List<string> pois = address.AddressResult.Pois.Select(p => $"{p.AddressDetail}{p.Name} {p.Direction}{p.Distance ?? "0"}米").ToList();
                    return new Tuple<string, List<string>>(detail, pois);
                }
                return new Tuple<string, List<string>>("IP地址不正确", new List<string>());
            }
            return new Tuple<string, List<string>>($"{ip}不是一个合法的IP地址", new List<string>());
        }

        /// <summary>
        /// 根据IP地址获取详细地理信息对象
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static async Task<PhysicsAddress> GetPhysicsAddressInfo(this string ip)
        {
            ip.MatchInetAddress(out var isIpAddress);
            if (isIpAddress)
            {
                string ak = "";// CoreConfig.Configuration["AppSettings:BaiduAK"];
                if (string.IsNullOrEmpty(ak))
                {
                    throw new Exception("未配置BaiduAK，请先在您的应用程序web.config或者App.config中的AppSettings节点下添加BaiduAK配置节(注意大小写)");
                }
                using (HttpClient client = new HttpClient() { BaseAddress = new Uri("http://api.map.baidu.com") })
                {
                    client.DefaultRequestHeaders.Referrer = new Uri("http://lbsyun.baidu.com/jsdemo.htm");
                    var task = client.GetAsync($"/location/ip?ak={ak}&ip={ip}&coor=bd09ll").ContinueWith(async t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                        {
                            return null;
                        }
                        var res = await t;
                        if (res.IsSuccessStatusCode)
                        {
                            var ipAddress = JsonConvert.DeserializeObject<BaiduIP>(await res.Content.ReadAsStringAsync());
                            if (ipAddress.Status == 0)
                            {
                                LatiLongitude point = ipAddress.AddressInfo.LatiLongitude;
                                string result = client.GetStringAsync($"/geocoder/v2/?location={point.Y},{point.X}&output=json&pois=1&radius=1000&latest_admin=1&coordtype=bd09ll&ak={ak}").Result;
                                PhysicsAddress address = JsonConvert.DeserializeObject<PhysicsAddress>(result);
                                if (address.Status == 0)
                                {
                                    return address;
                                }
                            }
                            else
                            {
                                using (var client2 = new HttpClient { BaseAddress = new Uri("http://ip.taobao.com") })
                                {
                                    return await await client2.GetAsync($"/service/getIpInfo.php?ip={ip}").ContinueWith(async tt =>
                                    {
                                        if (tt.IsFaulted || tt.IsCanceled)
                                        {
                                            return null;
                                        }
                                        var result = await tt;
                                        if (result.IsSuccessStatusCode)
                                        {
                                            TaobaoIP taobaoIp = JsonConvert.DeserializeObject<TaobaoIP>(await result.Content.ReadAsStringAsync());
                                            if (taobaoIp.Code == 0)
                                            {
                                                return new PhysicsAddress()
                                                {
                                                    Status = 0,
                                                    AddressResult = new AddressResult()
                                                    {
                                                        FormattedAddress = taobaoIp.IpData.Country + taobaoIp.IpData.Region + taobaoIp.IpData.City,
                                                        AddressComponent = new AddressComponent()
                                                        {
                                                            Province = taobaoIp.IpData.Region
                                                        },
                                                        Pois = new List<Pois>()
                                                    }
                                                };
                                            }
                                        }
                                        return null;
                                    });
                                }
                            }
                        }
                        return null;
                    });
                    return await await task;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据IP地址获取ISP
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetISP(this string ip)
        {
            if (ip.MatchInetAddress())
            {
                using (var client = new HttpClient { BaseAddress = new Uri("http://ip.taobao.com") })
                {
                    var task = client.GetAsync($"/service/getIpInfo.php?ip={ip}").ContinueWith(async t =>
                    {
                        if (t.IsFaulted)
                        {
                            return $"未能找到{ip}的ISP信息";
                        }
                        var result = await t;
                        if (result.IsSuccessStatusCode)
                        {
                            TaobaoIP taobaoIp = JsonConvert.DeserializeObject<TaobaoIP>(await result.Content.ReadAsStringAsync());
                            if (taobaoIp.Code == 0)
                            {
                                return taobaoIp.IpData.Isp;
                            }
                        }
                        return $"未能找到{ip}的ISP信息";
                    });
                    return task.Result.Result;
                }
            }
            return $"{ip}不是一个合法的IP";
        }

        #endregion

        /// <summary>
        /// 上传图片到百度图床
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task<string> UploadImageAsync(Stream stream)
        {
            using (HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sp1.baidu.com"),
            })
            {
                httpClient.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("Mozilla/5.0"));
                using (var bc = new StreamContent(stream))
                {
                    bc.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = "1.jpg",
                        Name = "image"
                    };
                    bc.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                    using (var content = new MultipartFormDataContent { bc })
                    {
                        return await await httpClient.PostAsync("/70cHazva2gU2pMbgoY3K/n/image?needJson=true", content).ContinueWith(async t =>
                        {
                            if (t.IsCanceled || t.IsFaulted)
                            {
                                Console.WriteLine("发送请求出错了" + t.Exception);
                                return string.Empty;
                            }
                            var res = await t;
                            if (res.IsSuccessStatusCode)
                            {
                                string s = await res.Content.ReadAsStringAsync();
                                var token = JObject.Parse(s);
                                if ((int)token["errno"] == 0)
                                {
                                    s = (string)token["data"]["imageUrl"];
                                    return s;
                                }
                                s = (string)token["errmsg"];
                                return s;
                            }
                            return string.Empty;
                        });
                    }
                }
            }
        }
    }
}