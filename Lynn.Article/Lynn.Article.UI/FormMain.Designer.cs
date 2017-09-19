namespace Lynn.Article.UI
{
    partial class FormMain
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
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.ButtonAnalysis = new System.Windows.Forms.Button();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.buttonSimpleAnalysis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(12, 12);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(760, 20);
            this.textBoxUrl.TabIndex = 0;
            // 
            // ButtonAnalysis
            // 
            this.ButtonAnalysis.Location = new System.Drawing.Point(13, 38);
            this.ButtonAnalysis.Name = "ButtonAnalysis";
            this.ButtonAnalysis.Size = new System.Drawing.Size(75, 23);
            this.ButtonAnalysis.TabIndex = 1;
            this.ButtonAnalysis.Text = "(&A)nalysis";
            this.ButtonAnalysis.UseVisualStyleBackColor = true;
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.BackColor = System.Drawing.Color.Teal;
            this.richTextBoxMessage.ForeColor = System.Drawing.Color.White;
            this.richTextBoxMessage.Location = new System.Drawing.Point(13, 67);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.Size = new System.Drawing.Size(759, 483);
            this.richTextBoxMessage.TabIndex = 2;
            this.richTextBoxMessage.Text = "";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(175, 38);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "C(&l)ear";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonPreview
            // 
            this.buttonPreview.Location = new System.Drawing.Point(256, 38);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(75, 23);
            this.buttonPreview.TabIndex = 4;
            this.buttonPreview.Text = "Previe(&w)";
            this.buttonPreview.UseVisualStyleBackColor = true;
            // 
            // buttonSimpleAnalysis
            // 
            this.buttonSimpleAnalysis.Location = new System.Drawing.Point(94, 38);
            this.buttonSimpleAnalysis.Name = "buttonSimpleAnalysis";
            this.buttonSimpleAnalysis.Size = new System.Drawing.Size(75, 23);
            this.buttonSimpleAnalysis.TabIndex = 5;
            this.buttonSimpleAnalysis.Text = "SA(&n)alysis";
            this.buttonSimpleAnalysis.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.buttonSimpleAnalysis);
            this.Controls.Add(this.buttonPreview);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.ButtonAnalysis);
            this.Controls.Add(this.textBoxUrl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.Text = "AnslysisArticle";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button ButtonAnalysis;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.Button buttonSimpleAnalysis;
    }
}

