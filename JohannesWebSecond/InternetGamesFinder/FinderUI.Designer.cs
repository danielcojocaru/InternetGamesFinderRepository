namespace InternetGamesFinder
{
    partial class FinderUI
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
            this.btnWebBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKeywordsBrowse = new System.Windows.Forms.Button();
            this.lblWeb = new System.Windows.Forms.Label();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnErrors = new System.Windows.Forms.Button();
            this.lblSearching = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btnWebBrowse
            // 
            this.btnWebBrowse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebBrowse.Location = new System.Drawing.Point(12, 31);
            this.btnWebBrowse.Name = "btnWebBrowse";
            this.btnWebBrowse.Size = new System.Drawing.Size(71, 23);
            this.btnWebBrowse.TabIndex = 3;
            this.btnWebBrowse.Text = "Browse";
            this.btnWebBrowse.UseVisualStyleBackColor = true;
            this.btnWebBrowse.Click += new System.EventHandler(this.btnWebBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Browse the file that contains the WEBSITES.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Browse the file that contains the KEYWORDS.";
            // 
            // btnKeywordsBrowse
            // 
            this.btnKeywordsBrowse.Enabled = false;
            this.btnKeywordsBrowse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeywordsBrowse.Location = new System.Drawing.Point(12, 93);
            this.btnKeywordsBrowse.Name = "btnKeywordsBrowse";
            this.btnKeywordsBrowse.Size = new System.Drawing.Size(71, 23);
            this.btnKeywordsBrowse.TabIndex = 5;
            this.btnKeywordsBrowse.Text = "Browse";
            this.btnKeywordsBrowse.UseVisualStyleBackColor = true;
            this.btnKeywordsBrowse.Click += new System.EventHandler(this.btnKeywordsBrowse_Click);
            // 
            // lblWeb
            // 
            this.lblWeb.AutoSize = true;
            this.lblWeb.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeb.Location = new System.Drawing.Point(86, 35);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(182, 15);
            this.lblWeb.TabIndex = 7;
            this.lblWeb.Text = "Websites successfully browsed.";
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyword.Location = new System.Drawing.Point(86, 97);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(184, 15);
            this.lblKeyword.TabIndex = 8;
            this.lblKeyword.Text = "Keywords successfully browsed.";
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(12, 146);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(258, 29);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search Games";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnGames
            // 
            this.btnGames.Enabled = false;
            this.btnGames.Location = new System.Drawing.Point(12, 211);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(123, 23);
            this.btnGames.TabIndex = 12;
            this.btnGames.Text = "Show Games";
            this.btnGames.UseVisualStyleBackColor = true;
            this.btnGames.Click += new System.EventHandler(this.btnGames_Click);
            // 
            // btnErrors
            // 
            this.btnErrors.Enabled = false;
            this.btnErrors.Location = new System.Drawing.Point(147, 211);
            this.btnErrors.Name = "btnErrors";
            this.btnErrors.Size = new System.Drawing.Size(123, 23);
            this.btnErrors.TabIndex = 13;
            this.btnErrors.Text = "Show Errors";
            this.btnErrors.UseVisualStyleBackColor = true;
            this.btnErrors.Click += new System.EventHandler(this.btnErrors_Click);
            // 
            // lblSearching
            // 
            this.lblSearching.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearching.ForeColor = System.Drawing.Color.Blue;
            this.lblSearching.Location = new System.Drawing.Point(13, 124);
            this.lblSearching.Name = "lblSearching";
            this.lblSearching.Size = new System.Drawing.Size(258, 15);
            this.lblSearching.TabIndex = 14;
            this.lblSearching.Text = "Searching keywords in Website number: 0.";
            this.lblSearching.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSearching.Visible = false;
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(12, 181);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(258, 23);
            this.pBar.Step = 1;
            this.pBar.TabIndex = 16;
            this.pBar.Visible = false;
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(89, 266);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(98, 76);
            this.webBrowser.TabIndex = 17;
            // 
            // FinderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 245);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.lblSearching);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.btnErrors);
            this.Controls.Add(this.btnGames);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblKeyword);
            this.Controls.Add(this.lblWeb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnKeywordsBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWebBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FinderUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Games on Web";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWebBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKeywordsBrowse;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnErrors;
        private System.Windows.Forms.Label lblSearching;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}

