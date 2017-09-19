using System;
using System.Net;
using System.Text;

namespace Lynn.Article.Core
{
    public class ArticleDownAction
    {
        #region Veriable

        private WebClient _client;
        #endregion

        #region Structure

        public ArticleDownAction()
        {
            _client = new WebClient();
            _client.Headers.Add(HttpRequestHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            _client.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8,zh-CN;q=0.6,zh;q=0.4");
            _client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/7.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E; InfoPath.3)");
            _client.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
        }

        #endregion

        #region Function

        public string GetHtml(string url)
        {
            var htmldata = _client.DownloadData(url);
            String html = Encoding.UTF8.GetString(htmldata);
            return html;
        }

        #endregion
    }
}