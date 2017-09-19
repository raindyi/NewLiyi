using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Article.Core
{
    public class ArticleAnalysisFactory
    {
        #region Veriable

        private static ArticleAnalysisFactory _factory = null;
        private static object _lockObj = new object();
        #endregion

        #region Structure

        public static ArticleAnalysisFactory Instance()
        {
            lock (_lockObj)
            {
                if (_factory == null)
                {
                    _factory=new ArticleAnalysisFactory();
                }
                return _factory;
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Gets the analysis instance by analysis type.
        /// </summary>
        /// <param name="analysisType">analysis type</param>
        /// <returns>If there not match any type,return null</returns>
        public IAnalysis CreateAnalysis(Int32 analysisType)
        {
            switch (analysisType)
            {
                case 1:
                {
                        return new AnalysisWechatOfficialAccount();
                }
                default:
                {
                    return null;
                }
            }
        }

        #endregion
    }
    
}
