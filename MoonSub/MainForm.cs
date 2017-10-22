using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoonSub
{
    public partial class MainForm : Form
    {
        IOSDb osdbProxy;
        string CDFormat = Options.CurrentOptions.CDFormat;
        string FileFormat = Options.CurrentOptions.FileFormat;
        string FolderFormat = Options.CurrentOptions.FolderFormat;
        string theToken;

        List<string> movieFormats = Options.CurrentOptions.MovieFormats.Split(',').ToList();
        List<string> subtitleFormats = Options.CurrentOptions.SubtitleFormats.Split(',').ToList();
        string[] langs;
        List<langMap> theLangMap = Utilities.generateLangMap();
        int dlCount = 0;
        List<MovieFile> myFiles = new List<MovieFile>();

        string inputPath = string.Empty;
        string outputPath = string.Empty;
        string languagePriority = string.Empty;
        List<string> languageSequence = new List<string>();

        string[] tmp;
        bool subtitleFound = false;

        public MainForm()
        {
            InitializeComponent();
            Options.ApplyTheme(this);

            checkRename.Checked = Options.CurrentOptions.Rename;
            checkNew.Checked = Options.CurrentOptions.IgnoreSubtitles;
            checkOrganize.Checked = Options.CurrentOptions.OrganizeFolders;
            checkData.Checked = Options.CurrentOptions.DownloadData;
            
            lblversion.Text = "Version: " + Program.GetCurrentVersionToString();
            ostxt.Text = Utilities.GetOS();
            bittxt.Text = Utilities.GetBitness();
        }

        private void EmptyLine()
        {
            infoBox.Items.Add(string.Empty);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options.SaveSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select the folder that has all your movies...";
            dialog.RootFolder = Environment.SpecialFolder.Desktop;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = dialog.SelectedPath;
                inputPath = dialog.SelectedPath.ToLowerInvariant();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Common movie files|*.avi;*.mkv;*.mp4;*.m4v";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = dialog.FileName;
                inputPath = dialog.FileName.ToLowerInvariant();
            }
        }

        private void checkRename_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.Rename = checkRename.Checked;
        }

        private void checkNew_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.IgnoreSubtitles = checkNew.Checked;
        }

        private void checkData_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.DownloadData = checkData.Checked;
        }

        private void checkOrganize_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.OrganizeFolders = checkOrganize.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputPath) && !string.IsNullOrEmpty(GenerateLanguageCodes()))
            {
                infoBox.Items.Clear();

                Search(inputPath, outputPath, GenerateLanguageCodes(), false, Options.CurrentOptions.Rename, Options.CurrentOptions.IgnoreSubtitles, Options.CurrentOptions.DownloadData, Options.CurrentOptions.OrganizeFolders, Options.CurrentOptions.DownloadData);
            }
            else if (string.IsNullOrEmpty(inputPath) && !string.IsNullOrEmpty(GenerateLanguageCodes()))
            {
                infoBox.Items.Clear();
                infoBox.Items.Add("Add a movie file or folder containing movies");
            }
            else if (!string.IsNullOrEmpty(inputPath) && string.IsNullOrEmpty(GenerateLanguageCodes()))
            {
                infoBox.Items.Clear();
                infoBox.Items.Add("Select at least one language");
            }
            else
            {
                infoBox.Items.Clear();
                infoBox.Items.Add("Add a movie file or folder containing movies");
                infoBox.Items.Add("Select at least one language");
            }
        }

        private string Get3CodeStr(string the2CodeStr)
        {
            string c3 = "";
            foreach (string l2code in the2CodeStr.Split(','))
            {
                foreach (langMap l in theLangMap)
                {
                    if (l.two.Contains(l2code))
                    {
                        if (!c3.Contains(l.three))
                        {
                            c3 += "," + l.three;
                        }
                    }
                }
            }
            if (c3 != "") { c3 = c3.Substring(1); }
            return c3;
        }

        private string Get2CodeStr(string the2CodeStr)
        {
            string c3 = "";
            foreach (string l2code in the2CodeStr.Split(','))
            {
                foreach (langMap l in theLangMap)
                {
                    if (l.two.Contains(l2code))
                    {
                        if (!c3.Contains(l.two))
                        {
                            c3 += "," + l.two;
                        }
                    }
                }
            }
            if (c3 != "") { c3 = c3.Substring(1); }
            return c3;
        }

        private List<string> GenerateLanguageSequence()
        {
            if (languageList.GetItemChecked(languageList.SelectedIndex))
            {
                if (!languageSequence.Contains(languageList.SelectedItem.ToString())) languageSequence.Add(languageList.SelectedItem.ToString());
            }
            else
            {
                if (languageSequence.Contains(languageList.SelectedItem.ToString())) languageSequence.Remove(languageList.SelectedItem.ToString());
            }

            return languageSequence;
        }

        private string GenerateLanguageCodes()
        {
            string result = string.Empty;

            foreach (string s in languageSequence)
            {
                int i = theLangMap.FindIndex(x => x.desc == s);

                if (i != -1)
                {
                    result += theLangMap[i].two + ",";
                }
            }

            if (result.Length > 0)
            {
                result = result.Substring(0, result.Length - 1);    
            }
            return result;
        }

        private void languageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            languagePriority = string.Empty;

            foreach (string s in GenerateLanguageSequence())
            {
                languagePriority += s + ",";
            }

            if (languagePriority.Length > 0)
            {
                languagePriority = languagePriority.Substring(0, languagePriority.Length - 1);
            }

            lblPriority.Text = "Priority: " + languagePriority.Replace(",", ", ");
        }

        private void Search(string FolderArg, string outputPath, string LangArg, bool overwrite, bool rename, bool newOnly, bool nfo, bool folders, bool imdb)
        {
            subtitleFound = false;

            try
            {
                infoBox.Items.Add("Searching for movie files...");

                if (File.Exists(FolderArg))
                {
                    if (outputPath == "")
                    {
                        outputPath = Path.GetDirectoryName(FolderArg);
                    }

                    MovieFile theFile = new MovieFile();
                    theFile.filename = FolderArg;
                    theFile.getOldSubtitle(subtitleFormats, theLangMap, LangArg);
                    myFiles.Add(theFile);
                }
                else if (Directory.Exists(FolderArg))
                {
                    if (outputPath == "")
                    {
                        outputPath = FolderArg;
                    }
                    foreach (string extension in movieFormats)
                    {
                        foreach (string filename in Utilities.GetFilesByExtensions(FolderArg, "." + extension, SearchOption.AllDirectories))
                        {
                            MovieFile theFile = new MovieFile();
                            theFile.filename = filename;
                            theFile.getOldSubtitle(subtitleFormats, theLangMap, LangArg);
                            if ((newOnly && (theFile.oldSubtitle == "")) || (!newOnly))
                            {
                                myFiles.Add(theFile);
                            }
                        }
                    }
                    infoBox.Items.Add("Found " + myFiles.Count.ToString() + " movies");
                }
                else
                {
                    infoBox.Items.Add("The folder or file given does not exist");
                }

                if (myFiles.Count != 0)
                {
                    infoBox.Items.Add("Creating subtitle requests from movies...");

                    langs = Get3CodeStr(LangArg).Split(',');
                    List<string> l3 = new List<string>(langs);
                    List<string> l2 = new List<string>(LangArg.Split(','));

                    int i = 0;
                    List<List<subInfo>> allSis = new List<List<subInfo>>();
                    List<subInfo> sis = new List<subInfo>();
                    foreach (MovieFile theFile in myFiles)
                    {
                        if ((newOnly && (theFile.oldSubtitle == "")) || (!newOnly))
                        {
                            foreach (string lang in langs)
                            {
                                try
                                {
                                    if (sis.Count >= 40)
                                    {
                                        allSis.Add(sis);
                                        sis = new List<subInfo>();
                                    }
                                    subInfo si = new subInfo();
                                    si.sublanguageid = lang;
                                    theFile.hash = Utilities.ToHexadecimal(Utilities.ComputeMovieHash(theFile.filename));
                                    si.moviehash = theFile.hash;
                                    si.moviebytesize = new FileInfo(theFile.filename).Length.ToString();
                                    sis.Add(si);
                                    i++;

                                }
                                catch (Exception ex)
                                {
                                    infoBox.Items.Add("Error with file: " + theFile.filename);
                                    infoBox.Items.Add(ex.Message);
                                }
                            }
                        }
                    }
                    if (sis.Count > 0)
                    {
                        allSis.Add(sis);
                    }

                    infoBox.Items.Add("Connecting...");

                    osdbProxy = XmlRpcProxyGen.Create<IOSDb>();
                    osdbProxy.Url = "http://api.opensubtitles.org/xml-rpc";
                    osdbProxy.KeepAlive = false;
                    if (myFiles.Count == 0) { infoBox.Items.Add("No movies found"); }
                    XmlRpcStruct Login = osdbProxy.LogIn("", "", "en", "vroksub");
                    theToken = Login["token"].ToString();

                    infoBox.Items.Add("Searching for subtitles...");

                    subrt SubResults = new subrt();
                    List<subRes> lstSubResults = new List<subRes>();
                    try
                    {
                        foreach (List<subInfo> theSis in allSis)
                        {
                            subrt tempSubResults = osdbProxy.SearchSubtitles(theToken, theSis.ToArray());
                            lstSubResults.AddRange(tempSubResults.data);
                            SubResults.seconds += tempSubResults.seconds;
                        }
                        SubResults.data = lstSubResults.ToArray();
                    }
                    catch (Exception e)
                    {

                    }

                    if (SubResults != null)
                    {
                        BindingList<subRes> g = new BindingList<subRes>(SubResults.data);
                        dlCount = 0;
                        foreach (MovieFile mf in myFiles)
                        {
                            try
                            {
                                if ((newOnly && (mf.oldSubtitle == "")) || (!newOnly))
                                {
                                    if (mf.SelectBestSubtitle(g, l3))
                                    {
                                        subtitleFound = true;
                                        infoBox.Items.Add("Subtitles found");
                                        infoBox.Items.Add(mf.subRes.MovieName + " - " + mf.subRes.LanguageName);
                                        dlCount++;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                infoBox.Items.Add("Couldn't choose subtitle for: " + mf.filename);
                                infoBox.Items.Add(ex.Message);
                            }
                        }

                        if (subtitleFound)
                        {
                            infoBox.Items.Add("Downloading subtitles...");
                        }
                        else
                        {
                            infoBox.Items.Add("No subtitles found");
                        }

                        string[] ids = new string[dlCount];
                        List<string> lstids = new List<string>();
                        List<List<string>> allids = new List<List<string>>();
                        int k = 0;
                        foreach (MovieFile myf in myFiles)
                        {
                            if (lstids.Count >= 40)
                            {
                                allids.Add(lstids);
                                lstids = new List<string>();
                            }
                            if (myf.subtitleId != null)
                            {
                                lstids.Add(myf.subtitleId);
                                k++;
                            }
                        }
                        if (lstids.Count > 0)
                        {
                            allids.Add(lstids);
                        }
                        subdata files = new subdata();
                        List<subtitle> thesubs = new List<subtitle>();
                        foreach (List<string> theList in allids)
                        {
                            subdata tempfiles = osdbProxy.DownloadSubtitles(theToken, lstids.ToArray());
                            thesubs.AddRange(tempfiles.data);
                            files.seconds += tempfiles.seconds;
                        }
                        files.data = thesubs.ToArray();


                        if (imdb)
                        {
                            infoBox.Items.Add("Fetching IMDb details...");

                            foreach (MovieFile myf in myFiles)
                            {
                                if (myf.subRes != null)
                                {
                                    try
                                    {
                                        myf.imdbinfo = osdbProxy.GetIMDBMovieDetails(theToken, "0" + myf.subRes.IDMovieImdb).data;
                                    }
                                    catch //(Exception ex)
                                    {
                                        //infoBox.Items.Add("Error fetching IMDb data for: " + myf.filename + " ERROR: " + ex.Message);
                                    }
                                }
                            }

                            infoBox.Items.Add("Downloading covers...");

                            WebClient Client = new WebClient();
                            Client.Encoding = Encoding.UTF8;

                            foreach (MovieFile myf in myFiles)
                            {
                                if (myf.imdbinfo != null)
                                {
                                    if ((myf.imdbinfo.cover != null) && (myf.imdbinfo.cover != ""))
                                    {
                                        try
                                        {
                                            Stream strm = Client.OpenRead(myf.imdbinfo.cover);
                                            FileStream writecover = new FileStream(Path.GetDirectoryName(myf.filename) + "\\" + Path.GetFileNameWithoutExtension(myf.filename) + ".jpg", FileMode.Create);
                                            int a;
                                            do
                                            {
                                                a = strm.ReadByte();
                                                writecover.WriteByte((byte)a);
                                            }
                                            while (a != -1);
                                            writecover.Position = 0;
                                            File.Copy(Path.GetDirectoryName(myf.filename) + "\\" + Path.GetFileNameWithoutExtension(myf.filename) + ".jpg", Path.GetDirectoryName(myf.filename) + "\\" + Path.GetFileName(myf.filename) + ".jpg");
                                            if (folders)
                                            {
                                                File.Copy(Path.GetDirectoryName(myf.filename) + "\\" + Path.GetFileNameWithoutExtension(myf.filename) + ".jpg", Path.GetDirectoryName(myf.filename) + "\\folder.jpg");
                                            }
                                            strm.Close();
                                            writecover.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            infoBox.Items.Add("Error saving cover for: " + myf.filename);
                                            infoBox.Items.Add(ex.Message);
                                        }
                                    }
                                }
                            }
                        }

                        if (subtitleFound)
                        {
                            infoBox.Items.Add("Saving subtitles...");
                        }

                        foreach (subtitle s in files.data)
                        {
                            foreach (MovieFile m in myFiles)
                            {
                                try
                                {
                                    if (m.subtitleId == s.idsubtitlefile)
                                    {
                                        m.subtitle = Utilities.DecodeAndDecompress(s.data);
                                        if (outputPath != FolderArg)
                                        {
                                            if (!Directory.Exists(outputPath))
                                            {
                                                Directory.CreateDirectory(outputPath);
                                            }
                                            if (!File.Exists(outputPath + "\\" + Path.GetFileName(m.filename)))
                                            {
                                                try
                                                {
                                                    File.Move(m.filename, outputPath + "\\" + Path.GetFileName(m.filename));
                                                    m.originalfilename = Path.GetFileName(m.filename);
                                                    m.filename = outputPath + "\\" + Path.GetFileName(m.filename);
                                                }
                                                catch //(Exception ex)
                                                {
                                                    //infoBox.Items.Add("Error moving movie: " + m.filename + " ERROR: " + ex.Message);
                                                }
                                            }
                                        }
                                        if (folders)
                                        {
                                            m.newFolder(outputPath, FolderFormat);
                                        }
                                        if (rename)
                                        {
                                            m.rename(FileFormat, CDFormat);
                                        }
                                        if (nfo)
                                        {
                                            m.saveNfo();
                                        }
                                        m.saveSubtitle(overwrite);
                                        continue;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    infoBox.Items.Add("Error saving subtitle for: " + m.filename);
                                    infoBox.Items.Add(ex.Message);
                                }
                            }
                        }
                    }

                    infoBox.Items.Add("Disconnecting...");

                    osdbProxy.LogOut(theToken);
                }
            }
            catch (Exception ex)
            {
                infoBox.Items.Add("Generic error:");
                infoBox.Items.Add(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OptionsForm f = new OptionsForm(this);
            f.ShowDialog(this);
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            myFiles.Clear();

            tmp = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            
            try
            {
                txtInput.Text = tmp[0];
                inputPath = tmp[0];
            }
            catch { }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                return;
            }

            e.Effect = DragDropEffects.None;
        }
    }
}
