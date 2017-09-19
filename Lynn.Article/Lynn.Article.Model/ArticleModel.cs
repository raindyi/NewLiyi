using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.Article.Model
{

    public class BasicArticleModel
    {
        public String Title { get; set; }
        public DateTime? PublicTime { get; set; }
        public String Author { get; set; }
        public SiteModel Site { get; set; }
        public HandlingResult Result { get; set; }
    }

    public class ArticleModel :BasicArticleModel
    {
        public SortedList<Int32,ContentModel> ContentModels { get; set; } 
    }
    public class SimpleArticleModel : BasicArticleModel
    {
        public String ContentModels { get; set; }
    }

    public class SiteModel
    {
        public String Name { get; set; }
        public String Url { get; set; }
        public Int32 Category { get; set; }
    }

    public class ContentModel
    {
        public String Type { get; set; }
        public String Detial { get; set; }
    }


}
