using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lynn.Article.Core;
using Lynn.Article.Model;

namespace Lynn.Article.UI
{
    public partial class FormMain : Form
    {
        #region Veriable
        private static object _lockObj= new object();
        private static Boolean _state = false;
        private SimpleArticleModel _simpleArticleModel = null;
        private String _filePath = "";
        #endregion

        #region Structure
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Fucntion

        private void Init()
        {
            InitControl();
        }

        private void InitControl()
        {
            ButtonAnalysis.Click += ButtonAnalysis_Click;
            buttonClear.Click += ButtonClear_Click;
            buttonPreview.Click += ButtonPreview_Click;
            buttonSimpleAnalysis.Click += ButtonSimpleAnalysis_Click;
        }

       

        private void SimpleAnalysis()
        {
            _state = true;
            SetControlEnable(buttonSimpleAnalysis, false);
            if (!String.IsNullOrEmpty(textBoxUrl.Text.TrimStart().TrimEnd()))
            {
                IAnalysis analysis = ArticleAnalysisFactory.Instance().CreateAnalysis(1);
                if (analysis != null)
                {
                    ArticleDownAction downAction = new ArticleDownAction();
                    String html = downAction.GetHtml(textBoxUrl.Text.TrimStart().TrimEnd());
                    _simpleArticleModel = analysis.SimpleAnalysis(html);
                    String articleJson = Newtonsoft.Json.JsonConvert.SerializeObject(_simpleArticleModel);
                    StringBuilder builder=new StringBuilder();
                    builder.AppendFormat("<html><body>{0}</body></html>", _simpleArticleModel.ContentModels);
                    _filePath = String.Format(@"{0}html\\htmltest_{1}.html", AppDomain.CurrentDomain.BaseDirectory,DateTime.Now.ToString("ffff"));
                    File.WriteAllText(_filePath,builder.ToString(),Encoding.Unicode);
                    //_filePath = string.Format("file:///{0}", _filePath);
                    AddMessage(articleJson);
                }
                else
                {
                    AddMessage("暂时还未支持该站点的文章采集，程序猿正在紧张处理中！！！");
                }
            }
            else
            {
                AddMessage("请输入需要采集的文章地址！");
            }
            _state = false;
            SetControlEnable(buttonSimpleAnalysis, true);
        }
        private void Analysis()
        {
            _state = true;
            SetControlEnable(ButtonAnalysis, false);
            if (!String.IsNullOrEmpty(textBoxUrl.Text.TrimStart().TrimEnd()))
            {
                IAnalysis analysis = ArticleAnalysisFactory.Instance().CreateAnalysis(1);
                if (analysis != null)
                {
                    ArticleDownAction downAction = new ArticleDownAction();
                    String html = downAction.GetHtml(textBoxUrl.Text.TrimStart().TrimEnd());
                    ArticleModel article= analysis.Analysis(html);
                    String articleJson = Newtonsoft.Json.JsonConvert.SerializeObject(article);
                    AddMessage(articleJson);
                }
                else
                {
                    AddMessage("暂时还未支持该站点的文章采集，程序猿正在紧张处理中！！！");
                }
            }
            else
            {
                AddMessage("请输入需要采集的文章地址！");
            }
            _state = false;
            SetControlEnable(ButtonAnalysis,true);
        }

        private void AddMessage(String message)
        {
            if (richTextBoxMessage.InvokeRequired)
            {
                richTextBoxMessage.Invoke((MethodInvoker)(() => { AddMessageInvoke(message); }));
            }
            else
            {
                AddMessageInvoke(message);
            }
        }

        private void AddMessageInvoke(String message)
        {
            String msg = String.Format("  [{0}]    {1}{2}", DateTime.Now.ToString("dd HH:mm:ss"), message, System.Environment.NewLine);
            //if (richTextBoxMessage.TextLength > 2000)
            //{
            //    _logMsg.Info(richTextBoxLog.Text);
            //    richTextBoxMessage.Text = "";
            //}
            richTextBoxMessage.Text += msg;
            richTextBoxMessage.SelectionStart = richTextBoxMessage.TextLength;
            richTextBoxMessage.ScrollToCaret();
        }
        private void SetControlEnable(Control sender, Boolean enable)
        {
            if (sender.InvokeRequired)
            {
                sender.Invoke((MethodInvoker)(() => { SetControlEnableInvoke(sender, enable); }));
            }
            else
            {
                SetControlEnableInvoke(sender, enable);
            }
        }

        private void SetControlEnableInvoke(Control sender, Boolean enable)
        {
            sender.Enabled = enable;
        }
        #endregion

        #region Event
        private void FormMain_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void ButtonAnalysis_Click(object sender, EventArgs e)
        {
            lock (_lockObj)
            {
                if (_state)
                {
                    AddMessage("已经存在分析任务，请稍后尝试！");
                    return;
                }
            }
            Thread t=new Thread(new ThreadStart(Analysis));
            t.Start();
        }
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            lock (_lockObj)
            {
                if (_state)
                {
                    AddMessage("已经存在分析任务，请稍后尝试！");
                    return;
                }
            }
           richTextBoxMessage.Clear();
        }
        private void ButtonSimpleAnalysis_Click(object sender, EventArgs e)
        {
            lock (_lockObj)
            {
                if (_state)
                {
                    AddMessage("已经存在分析任务，请稍后尝试！");
                    return;
                }
            }
            Thread t = new Thread(new ThreadStart(SimpleAnalysis));
            t.Start();
        }

        private void ButtonPreview_Click(object sender, EventArgs e)
        {
            if (_simpleArticleModel != null)
            {
                //Process.Start("iexplore.exe", _filePath);  //直接打开IE浏览器，打开指定页
                Process.Start(_filePath);
            }
        }
        #endregion
    }
}
