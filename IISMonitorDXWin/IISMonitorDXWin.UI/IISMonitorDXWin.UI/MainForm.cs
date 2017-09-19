using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IISMonitorDX.Core;
using IISMonitorDX.Model;

namespace IISMonitorDXWin.UI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        #region Veriable

        private Timer _timer = null;
        #endregion

        #region Structure
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Function
        private void Init()
        {
            InitControl();
            InitControlEvent();
        }

        private void InitControl()
        {
            _timer=new Timer();
        }

        private void InitControlEvent()
        {
            buttonStart.Click += buttonStart_Click;
            buttonStop.Click += buttonStop_Click;
            _timer.Tick += _timer_Tick;
        }

        private void Monitor()
        {
            IISModel iisModel= MonitorAction.Instance().GetIISInformation();

        }

        private void AddLog(string log)
        {
            String msg = String.Format("[{0}]<{1}> {2} {3}", FormatHelper.FormatTime(FormatTimeEnum.TIME_HH_MM_SS_FF), result.MsgNumber, result.Message, System.Environment.NewLine);
        }

        #endregion

        #region Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }
        void buttonStop_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void buttonStart_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        void _timer_Tick(object sender, EventArgs e)
        {

        }
        #endregion

       
    }
}
