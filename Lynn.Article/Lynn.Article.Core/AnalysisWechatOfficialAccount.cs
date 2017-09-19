using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lynn.Article.Model;
using HtmlAgilityPack;

namespace Lynn.Article.Core
{
    public class AnalysisWechatOfficialAccount :IAnalysis
    {
        #region 
        //private Regex regImage=new Regex("(http|ftp|https):\\/\\/[\\w\\-_]+(\\.[\\w\\-_]+)+([\\w\\-\\.,@?^=%&amp;:/~\\+#]*[\\w\\-\\@?^=%&amp;/~\\+#])?");
        //private Regex regText = new Regex("");
        private Regex regClass=new Regex("class=\"[\\w_ -. ]*\"");
        private Regex regImage = new Regex("data-src");
        private String[] _typeContian=new String[] {"IMG", "P", "SPAN", "#TEXT", "SECTION"};
        #endregion

        #region 
        #endregion

        #region Function
        public ArticleModel Analysis(string articleHtml)
        {
            ArticleModel model = new ArticleModel();
            model.Result=new HandlingResult();
            HtmlDocument htmlDocument=new HtmlDocument();
            htmlDocument.LoadHtml(articleHtml);
            try
            {
                HtmlNode hnTitle= htmlDocument.GetElementbyId("activity-name");
                model.Title = hnTitle != null ? hnTitle.InnerText.Trim() : "";
                HtmlNode hnPubTime = htmlDocument.GetElementbyId("post-date");
                model.PublicTime = hnPubTime != null ? DateTime.Parse(hnPubTime.InnerText.Trim()) : DateTime.Parse("1990-01-01");
                model.Author = hnPubTime != null ? hnPubTime.NextSibling.NextSibling.InnerText.Trim() : "";
                model.Site=new SiteModel();
                HtmlNode hnSiteName = htmlDocument.GetElementbyId("post-user");
                model.Site.Name= hnSiteName != null ? hnSiteName.InnerText.Trim() : "";
                model.Site.Category = 1;
                model.ContentModels=new SortedList<int, ContentModel>();
                HtmlNode hnContent = htmlDocument.GetElementbyId("js_content");
                Int32 cnt = 0;
                if (hnContent.HasChildNodes)
                {
                    HtmlNode hnsections = hnContent.ChildNodes["section"];
                    if (hnsections.HasChildNodes)
                    {
                        foreach (var childhn in hnsections.ChildNodes)
                        {
                            if (childhn.Name.ToUpper().Equals("IMG"))
                            {
                                cnt++;
                                model.ContentModels.Add(cnt, new ContentModel()
                                {
                                    Detial = AnalysisImage(childhn),
                                    Type = "IMG"
                                });
                                continue;
                            }
                            if (childhn.Name.ToUpper().Equals("P") || childhn.Name.ToUpper().Equals("SPAN") || childhn.Name.ToUpper().Equals("#TEXT"))
                            {
                                cnt++;
                                model.ContentModels.Add(cnt, new ContentModel()
                                {
                                    Detial = AnalysisText(childhn),
                                    Type = "TXT"
                                });
                                continue;
                            }
                            if (childhn.Name.Equals("section"))
                            {
                                if (childhn.FirstChild != null)
                                {
                                    foreach (var sectionhn in childhn.FirstChild.ChildNodes)
                                    {
                                        cnt++;
                                        var hn = sectionhn;
                                        if (!_typeContian.Contains(sectionhn.Name.ToUpper()))
                                        {
                                            hn = sectionhn.FirstChild;
                                        }
                                        if (hn.Name.ToUpper().Equals("IMG"))
                                        {
                                            model.ContentModels.Add(cnt, new ContentModel()
                                            {
                                                Detial = AnalysisImage(hn),
                                                Type = "IMG"
                                            });
                                            continue;
                                        }
                                        if (hn.Name.ToUpper().Equals("P")|| hn.Name.ToUpper().Equals("SPAN") || hn.Name.ToUpper().Equals("#TEXT"))
                                        {
                                            model.ContentModels.Add(cnt, new ContentModel()
                                            {
                                                Detial = AnalysisText(hn),
                                                Type = "TXT"
                                            });
                                            continue;
                                        }
                                        if (hn.Name.ToUpper().Equals("SECTION"))
                                        {
                                            model.ContentModels.Add(cnt, new ContentModel()
                                            {
                                                Detial = AnalysisSection(hn),
                                                Type = "FIX"
                                            });
                                            continue;
                                        }
                                    }
                                }
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                model.Result.Successed = false;
                model.Result.Result = ex;
                model.Result.Message = "分析文章过程出现异常，请查看详细的堆栈信息！";
            }
            return model;
        }

        public SimpleArticleModel SimpleAnalysis(String articleHtml)
        {
            //class="[\w_-. ]*"
            SimpleArticleModel model = new SimpleArticleModel();
            model.Result = new HandlingResult();
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(articleHtml);
            try
            {
                HtmlNode hnTitle = htmlDocument.GetElementbyId("activity-name");
                model.Title = hnTitle != null ? hnTitle.InnerText.Trim() : "";
                HtmlNode hnPubTime = htmlDocument.GetElementbyId("post-date");
                model.PublicTime = hnPubTime != null ? DateTime.Parse(hnPubTime.InnerText.Trim()) : DateTime.Parse("1990-01-01");
                model.Author = hnPubTime != null ? hnPubTime.NextSibling.NextSibling.InnerText.Trim() : "";
                model.Site = new SiteModel();
                HtmlNode hnSiteName = htmlDocument.GetElementbyId("post-user");
                model.Site.Name = hnSiteName != null ? hnSiteName.InnerText.Trim() : "";
                model.Site.Category = 1;
                model.ContentModels = "";
                HtmlNode hnContent = htmlDocument.GetElementbyId("js_content");
                Int32 cnt = 0;
                if (hnContent!=null && hnContent.HasChildNodes)
                {
                    model.ContentModels=regClass.Replace(hnContent.InnerHtml,"");
                    model.ContentModels = regImage.Replace(hnContent.InnerHtml, "src");
                }
            }
            catch (Exception ex)
            {
                model.Result.Successed = false;
                model.Result.Result = ex;
                model.Result.Message = "分析文章过程出现异常，请查看详细的堆栈信息！";
            }
            return model;
        }

        //private void AnalysisSection(SortedList<Int32, ContentModel> models,HtmlNode section)
        //{

        //}
        private String AnalysisSection(HtmlNode section)
        {
            StringBuilder builder=new StringBuilder();
            if (section.HasChildNodes)
            {
                foreach (var hn in section.ChildNodes)
                {
                    if (hn.Name.ToUpper().Equals("IMG"))
                    {
                        builder.AppendFormat("<img data-src=\"{0}\" />", AnalysisImage(hn));
                    }
                    if (hn.Name.ToUpper().Equals("P"))
                    {
                        builder.AppendFormat("<p>{0}</p>", AnalysisText(hn));
                    }
                    if (hn.Name.ToUpper().Equals("SECTION"))
                    {
                        builder.Append(AnalysisSection(hn));
                    }
                }
            }
            return builder.ToString();
        }

        private String AnalysisImage(HtmlNode section)
        {
            return section.Attributes["data-src"].Value;
        }

        //private ContentModel AnalysisImage(HtmlNode section)
        //{
        //    ContentModel model=new ContentModel();
        //    model.Type = "IMG";
        //    model.Detial = section.Attributes["data-src"].Value;
        //    return model;
        //}

        private String AnalysisText(HtmlNode section)
        {
            StringBuilder builder = new StringBuilder();
            if (section.HasChildNodes)
            {
                foreach (var hn in section.ChildNodes)
                {
                    if (hn.Name.ToUpper().Equals("#TEXT"))
                    {
                        builder.Append(hn.InnerText.Trim());
                    }
                    if (hn.Name.ToUpper().Equals("BR"))
                    {
                        builder.Append("<br>");
                    }
                    if (hn.Name.ToUpper().Equals("IMG"))
                    {
                        builder.AppendFormat("<img data-src=\"{0}\"/>",AnalysisImage(hn));
                    }
                    if (hn.HasChildNodes)
                    {
                        builder.Append(AnalysisText(hn));
                    }
                }
            }
            else
            {
                builder.Append(section.InnerText.Trim());
            }
            return builder.ToString();
        }

        //private ContentModel AnalysisText(HtmlNode section)
        //{
        //    ContentModel model = new ContentModel();
        //    model.Type = "TXT";
        //    StringBuilder builder=new StringBuilder();
        //    if (section.HasChildNodes)
        //    {
        //        foreach (var hn in section.ChildNodes)
        //        {
        //            if (hn.Name.ToUpper().Equals("#TEXT"))
        //            {
        //                builder.Append(hn.InnerText.Trim());
        //            }
        //            if (hn.Name.ToUpper().Equals("BR"))
        //            {
        //                builder.Append("<br>");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        builder.Append(section.InnerText.Trim());
        //    }
        //    model.Detial = builder.ToString();
        //    return model;
        //}



        #endregion

    }
}