using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace InternetGamesFinder
{
    public partial class FinderUI : Form
    {
        private string _webPath;
        private string _wordPath;
        private string _sitesWithGamesPath;
        private string _sitesWithErrorsPath;

        List<string> _sites = new List<string>();

        private int indexSite;

        public int IndexSite
        {
            get { return indexSite; }
            set
            {
                indexSite = value;
                this.pBar.PerformStep();
            }
        }

        List<string> _words = new List<string>();

        List<string> sitesWithGames = new List<string>();
        List<string> sitesWithErrors = new List<string>();

        private bool programMustStop = true;

        System.Timers.Timer timer = new System.Timers.Timer(1);
        private string currentTimerSite;

        public FinderUI()
        {
            InitializeComponent();
            lblKeyword.Text = "";
            lblWeb.Text = "";

            webBrowser.DocumentCompleted += WebKitBrowser_DocumentCompleted;
            webBrowser.ScriptErrorsSuppressed = true;

            timer = new System.Timers.Timer();
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!this.programMustStop)
            {
                string currentSite = this._sites[this.IndexSite];
                if (this.currentTimerSite == currentSite)
                {
                    if (this.IndexSite + 1 != this._sites.Count && !this.programMustStop)
                    {
                        string mess = string.Format("{0}: {1}  |||  Error: {2}", this.IndexSite.ToString(), currentSite, "Could not be readed.");
                        this.sitesWithErrors.Add(mess);

                        this.IndexSite++;
                        FirstMethod();
                    }
                }
            }
        }

        private void WebKitBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!this.programMustStop)
            {
                SecondMethod();
            }
        }

        private void btnWebBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                //fd.InitialDirectory = @"C:\Users\DanielCo\Documents\Visual Studio 2015\Projects\JohannesWebSecond\JohannesWeb\bin\Debug\Files";
                fd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                fd.Multiselect = false;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    this._webPath = fd.FileName;
                    btnKeywordsBrowse.Enabled = true;

                    // I make the path for the files SitesWithGames and SitesWithErrors and I write there the titles:
                    this._sitesWithGamesPath = Path.GetDirectoryName(fd.FileName) + "\\SitesWithGames.txt";
                    this._sitesWithErrorsPath = Path.GetDirectoryName(fd.FileName) + "\\SitesWithErrors.txt";
                    File.WriteAllText(this._sitesWithGamesPath, string.Empty);
                    File.WriteAllText(this._sitesWithErrorsPath, string.Empty);

                    using (StreamWriter sw = new StreamWriter(this._sitesWithGamesPath))
                    {
                        sw.WriteLine("The sites that contain GAMES are:");
                    }

                    using (StreamWriter sw = new StreamWriter(this._sitesWithErrorsPath))
                    {
                        sw.WriteLine("The sites that contain ERRORS are:");
                    }

                    this._sites = CopyFileToList(this._sites, this._webPath);
                    lblWeb.Text = string.Format("{0} WEBSITES to search in", this._sites.Count);
                    this.pBar.Maximum = this._sites.Count;
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Something went wrong when trying to upload the file.\n{0}\nPlease try again.", ex.Message);
                MessageBox.Show(message);
            }
        }

        private List<string> CopyFileToList(List<string> theList, string path)
        {
            try
            {
                theList = new List<string>();

                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        theList.Add(line);
                    }
                }
                return theList;
            }
            catch (Exception ex)
            {
                string message = string.Format("There is a problem creating the lists.\n{0}", ex.Message);
                MessageBox.Show(message);
                return null;
            }

        }


        private void btnKeywordsBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.InitialDirectory = this._webPath;
                fd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                fd.Multiselect = false;

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    this._wordPath = fd.FileName;
                    btnSearch.Enabled = true;

                    this._words = CopyFileToList(this._words, this._wordPath);
                    lblKeyword.Text = string.Format("{0} KEYWORDS to search", this._words.Count);
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Something went wrong when trying to upload the file.\n{0}\nPlease try again.", ex.Message);
                MessageBox.Show(message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchStart();
        }

        private void SearchStart()
        {
            if (btnSearch.Text == "Search Games")
            {
                this.programMustStop = false;
                MessageBox.Show("Please wait untill the Program searches all the sites. This could take a few minutes. You will recive a confirmation when the job is done.");
                btnSearch.Text = "Cancel";
                lblSearching.Visible = true;
                btnWebBrowse.Enabled = false;
                btnKeywordsBrowse.Enabled = false;
                this.btnGames.Enabled = false;
                this.btnErrors.Enabled = false;
                this.pBar.Visible = true;

                this.IndexSite = 0;
                FirstMethod();
            }
            else
            {
                this.programMustStop = true;
                CopyListsToFile();
                btnSearch.Text = "Search Games";
                this.btnGames.Enabled = true;
                this.btnErrors.Enabled = true;
                btnWebBrowse.Enabled = true;
                btnKeywordsBrowse.Enabled = true;
                this.pBar.Visible = false;
                this.pBar.Value = 0;
                lblSearching.Text = string.Format("Searched keywords only for {0} websites.", this.IndexSite++.ToString());
                string messageForMessBox = string.Format("Research terminated but not finished.\nSearched keywords only for {0} websites.", this.IndexSite++.ToString());
                MessageBox.Show(messageForMessBox);
            }
        }

        private void FirstMethod()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                string currentSite = this._sites[this.IndexSite];

                lblSearching.Text = string.Format("Searching keywords in Website number: {0}.", (this.IndexSite + 1).ToString());

                try
                {
                    this.currentTimerSite = currentSite;

                    timer.Interval = 30000;
                    timer.AutoReset = false;
                    timer.Enabled = true;

                    webBrowser.Navigate(currentSite);
                }
                catch (Exception ex)
                {
                    if (!this.sitesWithErrors.Contains(currentSite))
                    {
                        string mess = string.Format("{0}: {1}  |||  Error: {2}", this.IndexSite.ToString(), currentSite, ex.Message);
                        this.sitesWithErrors.Add(mess);
                    }
                }
            }));
            
        }

        private void SecondMethod()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                string pageContent = webBrowser.DocumentText.ToLower();
                string currentSite = this._sites[this.IndexSite];

                foreach (string word in this._words)
                {
                    if (!this.sitesWithGames.Contains(currentSite) && pageContent.Contains(word.ToLower()))
                    {
                        this.sitesWithGames.Add(currentSite);
                        break;
                    }
                }

                if (this.IndexSite + 1 != this._sites.Count && !this.programMustStop)
                {
                    this.IndexSite++;
                    FirstMethod();
                }
                else
                {
                    MessageBox.Show("Research complete for all {0} websites.", this._sites.Count.ToString());

                    CopyListsToFile();

                    ResearchCompleteChangeForm();
                }
            }));
        }

        private void ResearchCompleteChangeForm()
        {
            this.btnSearch.Text = "Search Games";
            this.btnGames.Enabled = true;
            this.btnErrors.Enabled = true;
            this.lblSearching.Text = string.Format("Research complete for all {0} websites.", this._sites.Count.ToString());
            btnKeywordsBrowse.Enabled = true;
            btnWebBrowse.Enabled = true;
            this.pBar.Visible = false;
            this.pBar.Value = 0;
        }

        private void CopyListsToFile()
        {
            try
            {
                //using (var fs = new FileStream(this._sitesWithGamesPath, FileMode.Truncate))
                //{
                //}

                //using (var fs = new FileStream(this._sitesWithErrorsPath, FileMode.Truncate))
                //{
                //}

                using (StreamWriter sw = new StreamWriter(this._sitesWithGamesPath))
                {
                    sw.WriteLine("The sites with GAMES are:");
                    foreach (string site in this.sitesWithGames)
                    {
                        sw.WriteLine(site);
                    }
                }
                this.sitesWithGames.Clear();

                using (StreamWriter sw = new StreamWriter(this._sitesWithErrorsPath))
                {
                    sw.WriteLine("The sites with ERRORS  are:");
                    foreach (string site in this.sitesWithErrors)
                    {
                        sw.WriteLine(site);
                    }
                }
                this.sitesWithErrors.Clear();
            }
            catch (Exception ex)
            {
                btnGames.Enabled = false;
                btnErrors.Enabled = false;

                string message = string.Format("There was a probleme copying the sites to the files.\n{0}", ex.Message);
                MessageBox.Show(message);
            }

        }

        private void btnGames_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this._sitesWithGamesPath);
        }

        private void btnErrors_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this._sitesWithErrorsPath);
        }


    }
}
