﻿using DL.Common.Win32;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace DL.Common.Html
{
    /// <summary>
    ///1、获取HTML<br/>
    ///1.1获取指定页面的HTML代码 GetHtml(string url, string postData, bool isPost, CookieContainer cookieContainer)<br/>
    ///1.2获取HTMLGetHtml(string url, CookieContainer cookieContainer)<br/>
    ///2、获取字符流<br/>
    ///2.1获取字符流GetStream(string url, CookieContainer cookieContainer)<br/>
    ///3、清除HTML标记 <br/>
    ///3.1清除HTML标记  NoHTML(string Htmlstring)<br/>
    ///4、匹配页面的链接 <br/>
    ///4.1获取页面的链接正则 GetHref(string HtmlCode)<br/>
    ///5、匹配页面的图片地址<br/>
    /// 5.1匹配页面的图片地址 GetImgSrc(string HtmlCode, string imgHttp)<br/>
    ///5.2匹配<img src="" />中的图片路径实际链接  GetImg(string ImgString, string imgHttp)<br/>
    ///6、抓取远程页面内容<br/>
    /// 6.1以GET方式抓取远程页面内容 Get_Http(string tUrl)<br/>
    /// 6.2以POST方式抓取远程页面内容 Post_Http(string url, string postData, string encodeType)<br/>
    ///7、压缩HTML输出<br/>
    ///7.1压缩HTML输出 ZipHtml(string Html)<br/>
    ///8、过滤HTML标签<br/>
    /// 8.1过滤指定HTML标签 DelHtml(string s_TextStr, string html_Str)  <br/>
    /// 8.2过滤HTML中的不安全标签 RemoveUnsafeHtml(string content)<br/>
    /// HTML转行成TEXT HtmlToTxt(string strHtml)<br/>
    /// 字符串转换为 HtmlStringToHtml(string str)<br/>
    /// html转换成字符串HtmlToString(string strHtml)<br/>
    /// 获取URL编码<br/>
    /// 判断URL是否有效<br/>
    /// 返回 HTML 字符串的编码解码结果
    /// </summary>
    public static partial class HtmlTools
    {
        #region 私有字段

        private static string contentType = "application/x-www-form-urlencoded";
        private static string accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg," + " application/x-shockwave-flash, application/x-silverlight, " + "application/vnd.ms-excel, application/vnd.ms-powerpoint, " + "application/msword, application/x-ms-application," + " application/x-ms-xbap," + " application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
        private static string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1;" + " .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
        private static int delay = 1000;
        private static int currentTry;

        #endregion

        #region 公有属性

        /// <summary> 
        /// 获取网页源码时使用的编码
        /// </summary> 
        public static Encoding Encoding { get; set; } = Encoding.GetEncoding("utf-8");

        /// <summary>
        /// 网络延迟
        /// </summary>
        public static int NetworkDelay
        {
            get
            {
                Random r = new Random();
                return r.Next(delay, delay * 2);
                // return (r.Next(delay / 1000, delay / 1000 * 2)) * 1000;
            }
            set
            {
                delay = value;
            }
        }

        /// <summary>
        /// 最大尝试次数
        /// </summary>
        public static int MaxTry { get; set; } = 300;

        #endregion

        #region 1、获取HTML

        /// <summary>
        /// 去除html标签后并截取字符串
        /// </summary>
        /// <param name="html">源html</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static string RemoveHtmlTag(this string html, int length = 0)
        {
            string strText = Regex.Replace(html, "<[^>]+>", "");
            strText = Regex.Replace(strText, "&[^;]+;", "");
            if (length > 0 && strText.Length > length)
            {
                return strText.Substring(0, length);
            }

            return strText;
        }

        /// <summary>
        /// 获取HTML
        /// </summary>
        /// <param name="_"></param>
        /// <param name="url">地址</param>
        public static string GetHtml(this HttpClient _, string url)
        {
            return _.GetAsync(url).ContinueWith(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    return string.Empty;
                }

                var resp = task.Result;
                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadAsStringAsync().Result;
                }

                return string.Empty;
            }).Result;
        }

        #endregion

        #region 2、获取字符流

        ///  <summary>
        ///  2.1获取字符流
        ///  </summary>
        /// ---------------------------------------------------------------------------------------------------------------
        ///  示例:
        ///  System.Net.CookieContainer cookie = new System.Net.CookieContainer(); 
        ///  Stream s = HttpHelper.GetStream("http://www.baidu.com", cookie);
        ///  picVerify.Image = Image.FromStream(s);
        /// ---------------------------------------------------------------------------------------------------------------
        /// <param name="_"></param>
        /// <param name="url">地址</param>
        public static Stream GetStream(this HttpClient _, string url)
        {
            return _.GetAsync(url).ContinueWith(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    return null;
                }

                var resp = task.Result;
                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadAsStreamAsync().Result;
                }

                return null;
            }).Result;
        }

        #endregion

        #region 3、清除HTML标记

        /// <summary>
        /// 清理Word文档转html后的冗余标签属性
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string ClearHtml(this string html)
        {
            string s = Regex.Match(Regex.Replace(html, @"background-color:#?\w{3,7}|font-family:'?[\w|\(|\)]*'?;?", string.Empty), @"<body[^>]*>([\s\S]*)<\/body>").Groups[1].Value.Replace("&#xa0;", string.Empty);
            s = Regex.Replace(s, @"\w+-?\w+:0\w+;?", string.Empty); //去除多余的零值属性
            s = Regex.Replace(s, "alt=\"(.+?)\"", string.Empty); //除去alt属性
            s = Regex.Replace(s, @"-aw.+?\s", string.Empty); //去除Word产生的-aw属性
            return s;
        }

        ///<summary>   
        ///3.1清除HTML标记   
        ///</summary>   
        ///<param name="htmlstring">包括HTML的源码</param>   
        ///<returns>已经去除后的文字</returns>   
        public static string RemoveHtml(this string htmlstring)
        {
            //删除脚本   
            htmlstring = Regex.Replace(htmlstring, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML   
            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);
            htmlstring = regex.Replace(htmlstring, "");
            htmlstring = Regex.Replace(htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "-->", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "<!--.*", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            htmlstring.Replace("<", "");
            htmlstring.Replace(">", "");
            htmlstring.Replace("\r\n", "");

            return htmlstring;
        }

        #endregion

        #region 4、匹配页面的链接

        #region 4.1获取页面的链接正则

        /// <summary>
        /// 4.1获取页面的链接正则
        /// </summary>
        /// <param name="HtmlCode">html代码</param>
        public static string GetHref(this string HtmlCode)
        {
            string MatchVale = "";
            string Reg = @"(h|H)(r|R)(e|E)(f|F) *= *('|"")?((\w|\\|\/|\.|:|-|_)+)[\S]*";
            foreach (Match m in Regex.Matches(HtmlCode, Reg))
            {
                MatchVale += (m.Value).ToLower().Replace("href=", "").Trim() + "|";
            }

            return MatchVale;
        }

        #endregion

        #region  4.2取得所有链接URL

        /// <summary>
        /// 4.2取得所有链接URL
        /// </summary>
        /// <param name="html">html代码</param>
        /// <returns>提取到的url</returns>
        public static string GetAllUrl(this string html)
        {
            StringBuilder sb = new StringBuilder();
            Match m = Regex.Match(html.ToLower(), "<a href=(.*?)>.*?</a>");
            while (m.Success)
            {
                sb.AppendLine(m.Result("$1"));
                m.NextMatch();
            }

            return sb.ToString();
        }

        #endregion

        #region 4.3获取所有连接文本

        /// <summary>
        /// 4.3获取所有连接文本
        /// </summary>
        /// <param name="html">html代码</param>
        /// <returns>所有的带链接的a标签</returns>
        public static string GetAllLinkText(this string html)
        {
            StringBuilder sb = new StringBuilder();
            Match m = Regex.Match(html.ToLower(), "<a href=.*?>(1,100})</a>");

            while (m.Success)
            {
                sb.AppendLine(m.Result("$1"));
                m.NextMatch();
            }

            return sb.ToString();
        }

        #endregion

        #endregion

        #region  5、匹配页面的图片地址

        /// <summary>
        /// 替换html的img路径为绝对路径
        /// </summary>
        /// <param name="html"></param>
        /// <param name="imgDest"></param>
        /// <returns></returns>
        public static string ReplaceHtmlImgSource(this string html, string imgDest) => html.Replace("<img src=\"", "<img src=\"" + imgDest + "/");

        /// <summary>
        /// 将src的绝对路径换成相对路径
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ConvertImgSrcToRelativePath(this string s)
        {
            return Regex.Replace(s, @"<img src=""(http:\/\/.+?)/", @"<img src=""/");
        }

        private static readonly Regex ImgRegex = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<src>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>");

        /// <summary>
        /// 匹配html的所有img标签集合
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static MatchCollection MatchImgTags(this string html) => ImgRegex.Matches(html);

        /// <summary>
        /// 匹配html的一个img标签
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static Match MatchImgTag(this string html) => ImgRegex.Match(html);

        /// <summary>
        /// 获取html中第一个img标签的src
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string MatchFirstImgSrc(this string html)
        {
            string src = ImgRegex.Match(html).Groups["src"].Value;
            int index = src.IndexOf("\"", StringComparison.Ordinal);
            if (index > 0)
            {
                src = src.Substring(0, index);
            }

            return src;
        }

        /// <summary>
        /// 随机获取html代码中的img标签的src属性
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string MatchRandomImgSrc(this string html)
        {
            var collection = ImgRegex.Matches(html);
            if (collection.Count > 0)
            {
                string src = collection[new Random().StrictNext(collection.Count)].Groups["src"].Value;
                int index = src.IndexOf("\"", StringComparison.Ordinal);
                if (index > 0)
                {
                    src = src.Substring(0, index);
                }

                return src;
            }

            return string.Empty;
        }

        #endregion

        #region 6、抓取远程页面内容

        /// <summary>
        /// 6.1以GET方式抓取远程页面内容
        /// </summary>
        /// <param name="_"></param>
        /// <param name="tUrl">URL</param>
        public static string Get_Http(this HttpWebRequest _, string tUrl)
        {
            string strResult;
            try
            {
                var hwr = (HttpWebRequest)WebRequest.Create(tUrl);
                hwr.Timeout = 19600;
                var hwrs = (HttpWebResponse)hwr.GetResponse();
                Stream myStream = hwrs.GetResponseStream();
                var sr = new StreamReader(myStream, Encoding.Default);
                var sb = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    sb.Append(sr.ReadLine() + "\r\n");
                }

                strResult = sb.ToString();
                hwrs.Close();
            }
            catch (Exception ee)
            {
                strResult = ee.Message;
            }

            return strResult;
        }

        /// <summary>
        /// 6.2以POST方式抓取远程页面内容
        /// </summary>
        /// <param name="_"></param>
        /// <param name="url">URL</param>
        /// <param name="postData">参数列表</param>
        /// <param name="encodeType">编码类型</param>
        public static string Post_Http(this HttpWebRequest _, string url, string postData, string encodeType)
        {
            string strResult;
            try
            {
                Encoding encoding = Encoding.GetEncoding(encodeType);
                byte[] POST = encoding.GetBytes(postData);
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = POST.Length;
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(POST, 0, POST.Length); //设置POST
                newStream.Close();
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
                strResult = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }

            return strResult;
        }

        #endregion

        #region 7、压缩HTML输出

        /// <summary>
        /// 7.1压缩HTML输出
        /// </summary>
        /// <param name="html">html</param>
        public static string ZipHtml(this string html)
        {
            html = Regex.Replace(html, @">\s+?<", "><"); //去除HTML中的空白字符
            html = Regex.Replace(html, @"\r\n\s*", "");
            html = Regex.Replace(html, @"<body([\s|\S]*?)>([\s|\S]*?)</body>", @"<body$1>$2</body>", RegexOptions.IgnoreCase);
            return html;
        }

        #endregion

        #region 8、过滤HTML标签

        #region 8.1过滤指定HTML标签

        /// <summary>
        /// 8.1过滤指定HTML标签
        /// </summary>
        /// <param name="sTextStr">要过滤的字符</param>
        /// <param name="htmlStr">a img p div</param>
        public static string DelHtml(this string sTextStr, string htmlStr)
        {
            string rStr = "";
            if (!string.IsNullOrEmpty(sTextStr))
            {
                rStr = Regex.Replace(sTextStr, "<" + htmlStr + "[^>]*>", "", RegexOptions.IgnoreCase);
                rStr = Regex.Replace(rStr, "</" + htmlStr + ">", "", RegexOptions.IgnoreCase);
            }

            return rStr;
        }

        #endregion

        #region 8.2过滤HTML中的不安全标签

        /// <summary>
        /// 8.2过滤HTML中的不安全标签，去掉尖括号
        /// </summary>
        /// <param name="content">html代码</param>
        /// <returns>过滤后的安全内容</returns>
        public static string RemoveUnsafeHtml(this string content)
        {
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }

        #endregion

        #endregion

        #region 转换HTML操作

        #region HTML转行成TEXT

        /// <summary>
        /// HTML转行成TEXT HtmlToTxt(string strHtml)
        /// </summary>
        /// <param name="strHtml">html代码</param>
        /// <returns>普通文本</returns>
        public static string HtmlToTxt(this string strHtml)
        {
            string[] aryReg =
            {
                @"<script[^>]*?>.*?</script>",
                @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
                @"([\r\n])[\s]+",
                @"&(quot|#34);",
                @"&(amp|#38);",
                @"&(lt|#60);",
                @"&(gt|#62);",
                @"&(nbsp|#160);",
                @"&(iexcl|#161);",
                @"&(cent|#162);",
                @"&(pound|#163);",
                @"&(copy|#169);",
                @"&#(\d+);",
                @"-->",
                @"<!--.*\n"
            };

            string strOutput = strHtml;
            foreach (var t in aryReg)
            {
                Regex regex = new Regex(t, RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, string.Empty);
            }

            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");
            return strOutput;
        }

        #endregion

        #region 字符串转换为 Html

        /// <summary>
        /// 字符串转换为 HtmlStringToHtml(string str)
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>html标签</returns>
        public static string StringToHtml(this string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br />");
            str = str.Replace("\r", "<br />");
            str = str.Replace("\r\n", "<br />");
            return str;
        }

        #endregion

        #region Html转换成字符串

        /// <summary>
        /// html转换成字符串
        /// </summary>
        /// <param name="strHtml">html代码</param>
        /// <returns>安全的字符串</returns>
        public static string HtmlToString(this string strHtml)
        {
            strHtml = strHtml.Replace("<br>", "\r\n");
            strHtml = strHtml.Replace(@"<br />", "\r\n");
            strHtml = strHtml.Replace(@"<br/>", "\r\n");
            strHtml = strHtml.Replace("&gt;", ">");
            strHtml = strHtml.Replace("&lt;", "<");
            strHtml = strHtml.Replace("&nbsp;", " ");
            strHtml = strHtml.Replace("&quot;", "\"");
            strHtml = Regex.Replace(strHtml, @"<\/?[^>]+>", "", RegexOptions.IgnoreCase);
            return strHtml;
        }

        #endregion

        #endregion

        #region 获取URL编码

        /// <summary>
        /// 获取URL编码
        /// </summary>
        /// <param name="_"></param>
        /// <param name="url">URL</param>
        /// <returns>编码类型</returns>
        public static string GetEncoding(this HttpWebRequest _, string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 20000;
            request.AllowAutoRedirect = false;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK || response.ContentLength >= 1024 * 1024)
                {
                    return Encoding.Default.BodyName;
                }

                var reader = response.ContentEncoding.Equals("gzip") ? new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)) : new StreamReader(response.GetResponseStream(), Encoding.ASCII);

                string html = reader.ReadToEnd();
                Regex regCharset = new Regex(@"charset\b\s*=\s*(?<charset>[^""]*)");
                if (regCharset.IsMatch(html))
                {
                    return regCharset.Match(html).Groups["charset"].Value;
                }

                if (response.CharacterSet != string.Empty)
                {
                    return response.CharacterSet;
                }
            }

            return Encoding.Default.BodyName;
        }

        #endregion

        #region 返回 HTML 字符串的编码解码结果

        /// <summary>
        /// 返回 HTML 字符串的编码结果
        /// </summary>
        /// <param name="inputData">字符串</param>
        /// <returns>编码结果</returns>
        public static string HtmlEncode(string inputData)
        {
            return HttpUtility.HtmlEncode(inputData);
        }

        /// <summary>
        /// 返回 HTML 字符串的解码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        #endregion

        /// <summary>
        /// 获取Cookie集合
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="cookieString">Cookie的键</param>
        /// <returns>Cookie键值集合</returns>
        public static CookieCollection GetCookieCollection(this CookieCollection cookie, string cookieString)
        {
            Regex re = new Regex("([^;,]+)=([^;,]+);Domain=([^;,]+);Path=([^;,]+)", RegexOptions.IgnoreCase);
            foreach (Match m in re.Matches(cookieString))
            {
                //name,   value,   path,   domain   
                Cookie c = new Cookie(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value, m.Groups[3].Value);
                cookie.Add(c);
            }

            return cookie;
        }

        #region 从HTML中获取文本,保留br,p,img

        /// <summary>
        /// 从HTML中获取文本,保留br,p,img
        /// </summary>
        /// <param name="HTML">html代码</param>
        /// <returns>保留br,p,img的文本</returns>
        public static string GetTextFromHTML(this string HTML)
        {
            Regex regEx = new Regex(@"</?(?!br|/?p|img)[^>]*>", RegexOptions.IgnoreCase);

            return regEx.Replace(HTML, "");
        }

        #endregion

        #region 获取HTML页面内制定Key的Value内容

        /// <summary>
        /// 获取HTML页面内制定Key的Value内容
        /// </summary>
        /// <param name="html">html源代码</param>
        /// <param name="key">键</param>
        /// <returns>获取到的值</returns>
        public static string GetHiddenKeyValue(this string html, string key)
        {
            string result = "";
            string sRegex = string.Format("<input\\s*type=\"hidden\".*?name=\"{0}\".*?\\s*value=[\"|'](?<value>.*?)[\"|'^/]", key);
            Regex re = new Regex(sRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            Match mc = re.Match(html);
            if (mc.Success)
            {
                result = mc.Groups[1].Value;
            }

            return result;
        }

        #endregion

        /// <summary>
        /// 替换回车换行符为html换行符
        /// </summary>
        /// <param name="str">html</param>
        public static string StrFormat(this string str)
        {
            str = str.Replace("\r\n", "<br />");
            str = str.Replace("\n", "<br />");
            var str2 = str;

            return str2;
        }

        /// <summary>
        /// 替换html字符
        /// </summary>
        /// <param name="strHtml">html</param>
        public static string EncodeHtml(this string strHtml)
        {
            if (strHtml != "")
            {
                strHtml = strHtml.Replace(",", "&def");
                strHtml = strHtml.Replace("'", "&dot");
                strHtml = strHtml.Replace(";", "&dec");
                return strHtml;
            }

            return "";
        }

        /// <summary>
        /// 为脚本替换特殊字符串
        /// </summary>
        /// <param name="str"> </param>
        /// <returns> </returns>
        [Obsolete("不建议使用", true)]
        public static string ReplaceStrToScript(string str)
        {
            str = str.Replace("\\", "\\\\");
            str = str.Replace("'", "\\'");
            str = str.Replace("\"", "\\\"");
            return str;
        }
    }
}