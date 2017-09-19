namespace IISMonitorDXWin.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerControlMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.buttonStart = new DevExpress.XtraEditors.SimpleButton();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.buttonStop = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).BeginInit();
            this.splitContainerControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControlMain
            // 
            this.splitContainerControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlMain.Horizontal = false;
            this.splitContainerControlMain.IsSplitterFixed = true;
            this.splitContainerControlMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlMain.Name = "splitContainerControlMain";
            this.splitContainerControlMain.Panel1.Controls.Add(this.buttonStop);
            this.splitContainerControlMain.Panel1.Controls.Add(this.buttonStart);
            this.splitContainerControlMain.Panel1.MinSize = 60;
            this.splitContainerControlMain.Panel1.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.splitContainerControlMain.Panel1.Text = "PanelButtons";
            this.splitContainerControlMain.Panel2.Controls.Add(this.richTextBoxLog);
            this.splitContainerControlMain.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControlMain.Panel2.Text = "Panel2";
            this.splitContainerControlMain.Size = new System.Drawing.Size(632, 480);
            this.splitContainerControlMain.SplitterPosition = 60;
            this.splitContainerControlMain.TabIndex = 0;
            this.splitContainerControlMain.Text = "splitContainerControlMain";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 5);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 50);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(5, 5);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(622, 405);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(93, 5);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 50);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 480);
            this.Controls.Add(this.splitContainerControlMain);
            this.Name = "MainForm";
            this.Text = "IISMonitor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlMain)).EndInit();
            this.splitContainerControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlMain;
        private DevExpress.XtraEditors.SimpleButton buttonStart;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private DevExpress.XtraEditors.SimpleButton buttonStop;

    }
}

