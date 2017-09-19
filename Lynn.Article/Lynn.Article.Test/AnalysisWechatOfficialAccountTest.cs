using System;
using Lynn.Article.Core;
using Lynn.Article.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lynn.Article.Test
{
    [TestClass]
    public class AnalysisWechatOfficialAccountTest
    {
        [TestMethod]
        public void AnalysisTest_文章分析()
        {
            ArticleDownAction action=new ArticleDownAction();
            String url = "https://mp.weixin.qq.com/s/CwsiuQ10q-WQ9dROvPAhWQ";
            String html= action.GetHtml(url);
            AnalysisWechatOfficialAccount analysis=new AnalysisWechatOfficialAccount();
            ArticleModel model= analysis.Analysis(html);
            String json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            Assert.IsTrue(model.Result.Successed);
        }

        [TestMethod]
        public void AnalysisTest_简单分析()
        {
            ArticleDownAction action = new ArticleDownAction();
            String url = "https://mp.weixin.qq.com/s/CwsiuQ10q-WQ9dROvPAhWQ";
            String html = action.GetHtml(url);
            AnalysisWechatOfficialAccount analysis = new AnalysisWechatOfficialAccount();
            SimpleArticleModel model = analysis.SimpleAnalysis(html);
            String json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            Assert.IsTrue(model.Result.Successed);
        }

    }
}
