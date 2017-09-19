using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lynn.Article.UI
{
    public partial class FormPreview : Form
    {
        public String HtmlFilePath { get; set; }

        public FormPreview()
        {
            InitializeComponent();
        }

        private void FormPreview_Load(object sender, EventArgs e)
        {
            webBrowserMain.Navigate(HtmlFilePath);
        }
    }
}
