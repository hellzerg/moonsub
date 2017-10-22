using System.Collections.Generic;
using System.ComponentModel;
using CookComputing.XmlRpc;
using System.IO;
using System;
using System.Windows.Forms;

namespace MoonSub
{
    public class imdbdata
    {
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string year { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string id { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string duration { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string[] certification { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string cover { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public XmlRpcStruct cast { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string[] genres { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string[] aka { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string plot { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string title { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string trivia { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string rating { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public XmlRpcStruct directors { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string tagline { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string votes { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string[] country { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string goofs { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string[] language { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public XmlRpcStruct writers { get; set; }
    }


    public class subRes
    {
        public string IDSubtitle { get; set; }
        public string IDSubtitleFile { get; set; }
        public string SubAuthorComment { get; set; }
        public string LanguageName { get; set; }
        public string UserID { get; set; }
        public string MovieNameEng { get; set; }
        public string MovieByteSize { get; set; }
        public string IDMovie { get; set; }
        public string MovieYear { get; set; }
        public string SubHash { get; set; }
        public string MovieHash { get; set; }
        public string SubFormat { get; set; }
        public string SubBad { get; set; }
        public string SubDownloadsCnt { get; set; }
        public string SubLanguageID { get; set; }
        public string IDMovieImdb { get; set; }
        public string MovieTimeMS { get; set; }
        public string SubActualCD { get; set; }
        public string MovieReleaseName { get; set; }
        public string SubRating { get; set; }
        public string SubDownloadLink { get; set; }
        public string ZipDownloadLink { get; set; }
        public string IDSubMovieFile { get; set; }
        public string ISO639 { get; set; }
        public string SubSumCD { get; set; }
        public string SubSize { get; set; }
        public string UserNickName { get; set; }
        public string SubAddDate { get; set; }
        public string MovieName { get; set; }
        public string MovieImdbRating { get; set; }
        public string SubFileName { get; set; }
    }

    public class subrt
    {
        public subRes[] data { get; set; }
        public double seconds { get; set; }
    }

    public class subInfo
    {
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string sublanguageid { get; set; }
        public string moviehash { get; set; }
        public string moviebytesize { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string imdbid { get; set; }
    }

    public class imdbheader
    {
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public double seconds { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public imdbdata data;
    }

    public class subdata
    {
        public string status { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public subtitle[] data;
        public double seconds { get; set; }
    }

    public class subtitle
    {
        public string idsubtitlefile { get; set; }
        public string data { get; set; }
    }

    public class MovieFile
    {
        public byte[] cover { get; set; }
        public string hash { get; set; }
        public string filename { get; set; }
        public string originalfilename { get; set; }
        public string originalfolder { get; set; }
        public subRes subRes { get; set; }
        public byte[] subtitle { get; set; }
        public string subtitleId { get; set; }
        public string oldSubtitle { get; set; }
        public imdbdata imdbinfo { get; set; }
        public string oldSubtitleLang { get; set; }
        public string GetSubtitleFileName()
        {
            return Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + "." + subRes.ISO639 + "." + subRes.SubFormat;
        }

        public string GetName()
        {
            return Path.GetFileNameWithoutExtension(filename);
        }

        public void saveSubtitle(bool overwrite)
        {
            string filenameToWrite = GetSubtitleFileName();
            if (File.Exists(filenameToWrite))
            {
                if (overwrite)
                {
                    File.Delete(filenameToWrite);
                }
                else
                {
                    return;
                }
            }
            FileStream fStream = new FileStream(GetSubtitleFileName(), FileMode.CreateNew);

            BinaryWriter bw = new BinaryWriter(fStream);

            bw.Write(subtitle);

            bw.Close();

            fStream.Close();
        }

        public void getOldSubtitle(List<string> subtitleFormats, List<langMap> theLangMap, string langSeq)
        {
            List<string> langSeqSplit = new List<string>(langSeq.Split(','));
            FileInfo myf = new FileInfo(filename);
            string[] theFiles = Directory.GetFiles(myf.DirectoryName, Path.GetFileNameWithoutExtension(filename) + ".*");

            string bestOldSubFile = "";
            string bestOldSubFileLang = "";

            foreach (string file in theFiles)
            {
                if (file == filename) { continue; }
                string ext = Path.GetExtension(file);
                if (subtitleFormats.Contains(ext.Replace(".", "")))
                {
                    if ((langSeqSplit.Count == 1) || (langSeqSplit.Contains("el") && (langSeqSplit.Count == 2)))
                    {
                        if (file.Contains(langSeqSplit[0]))
                        {
                            bestOldSubFile = file;
                        }
                    }
                    else
                    {
                        string l = Utilities.parseLangCodeFromFile(file, theLangMap);
                        if (bestOldSubFile == "")
                        {
                            bestOldSubFile = file;
                            if (l != "") { bestOldSubFileLang = l; }
                            continue;
                        }
                        if ((l != "") && (langSeqSplit.IndexOf(l) != -1))
                        {
                            if (bestOldSubFileLang == "")
                            {
                                bestOldSubFileLang = l;
                                bestOldSubFile = file;
                                continue;
                            }
                            if (langSeqSplit.IndexOf(l) < langSeqSplit.IndexOf(bestOldSubFileLang))
                            {
                                bestOldSubFile = file;
                                bestOldSubFileLang = l;
                            }
                        }
                    }
                }
            }
            oldSubtitle = bestOldSubFile;
            oldSubtitleLang = bestOldSubFileLang;

            if ((langSeqSplit.Count == 1) || (langSeqSplit.Contains("el") && (langSeqSplit.Count == 2)))
            {
                if (!oldSubtitle.Contains(langSeqSplit[0]))
                {
                    oldSubtitle = "";
                    oldSubtitleLang = "";
                }
            }
        }

        public bool SelectBestSubtitle(BindingList<subRes> subs, List<string> ls)
        {
            subRes best = null;
            foreach (subRes tr in subs)
            {
                if (hash == tr.MovieHash)
                {
                    if (best == null) { best = tr; continue; }
                    if (ls.IndexOf(tr.SubLanguageID) < ls.IndexOf(best.SubLanguageID))
                    {
                        best = tr;
                    }
                }
            }
            if (best != null)
            {
                foreach (subRes tr in subs)
                {
                    if (hash == tr.MovieHash)
                    {
                        if (best.SubLanguageID == tr.SubLanguageID)
                        {
                            try
                            {
                                if (float.Parse(tr.SubRating) > float.Parse(best.SubRating))
                                {
                                    best = tr;
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
            }
            if (best != null)
            {
                subtitleId = best.IDSubtitleFile;
                subRes = best;
                return true;
            }
            return false;
        }

        public void rename(string FileFormat, string CDFormat)
        {
            if (subRes != null)
            {
                string cdStr = "";
                if (subRes.SubActualCD == "1")
                {
                    if (subRes.SubSumCD != "1")
                    {
                        cdStr = CDFormat.Replace("%C", "1");
                    }
                }
                else if (subRes.SubActualCD != "")
                {
                    cdStr = CDFormat.Replace("%C", subRes.SubActualCD);
                }

                if (subRes.MovieName != "")
                {
                    string newName = Path.GetDirectoryName(filename) + "\\" + FileFormat + Path.GetExtension(filename);
                    newName = newName.Replace("%M", Utilities.FilenameFromTitle(subRes.MovieName));
                    newName = newName.Replace("%Y", subRes.MovieYear);
                    newName = newName.Replace("%C", cdStr);
                    
                    if (!File.Exists(newName))
                    {
                        try
                        {
                            File.Move(filename, newName);
                            originalfilename = Path.GetFileName(filename);
                            filename = newName;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error renaming movie: " + filename + "\n" + ex.Message);
                        }
                    }
                }
            }
        }

        public void newFolder(string rootFolder, string FolderFormat)
        {
            if (subRes != null)
            {
                if (subRes.MovieName != "")
                {
                    string newName = rootFolder + "\\" + FolderFormat;
                    newName = newName.Replace("%M", Utilities.FilenameFromTitle(subRes.MovieName));
                    newName = newName.Replace("%Y", subRes.MovieYear);
                    if (!Directory.Exists(newName))
                    {
                        try
                        {
                            Directory.CreateDirectory(newName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Could not create directory: " + filename + "\n" + ex.Message);
                        }
                    }
                    if (Path.GetDirectoryName(filename) != newName)
                    {
                        try
                        {
                            originalfolder = Path.GetDirectoryName(filename);
                            File.Move(filename, newName + "\\" + Path.GetFileName(filename));
                            filename = newName + "\\" + Path.GetFileName(filename);

                            if (File.Exists(rootFolder + "\\" + Path.GetFileNameWithoutExtension(filename) + ".jpg"))
                            {
                                File.Move(rootFolder + "\\" + Path.GetFileNameWithoutExtension(filename) + ".jpg", newName + "\\" + Path.GetFileNameWithoutExtension(filename) + ".jpg");
                            }
                            if (File.Exists(rootFolder + "\\" + "folder.jpg"))
                            {
                                File.Move(rootFolder + "\\" + "folder.jpg", newName + "\\folder.jpg");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Could not move file to new directory: " + filename + "\n" + ex.Message);
                        }
                    }

                }
            }
        }

        public void saveNfo()
        {
            try
            {
                if (subRes != null)
                {
                    List<string> lstNfo = new List<string>();
                    lstNfo.Add("Name: " + subRes.MovieName);
                    lstNfo.Add("Year: " + subRes.MovieYear);
                    lstNfo.Add("URL: " + "http://www.imdb.com/title/tt0" + subRes.IDMovieImdb);
                    lstNfo.Add("Rating: " + subRes.MovieImdbRating);

                    if (imdbinfo != null)
                    {
                        addCSV("Directors", imdbinfo.directors.Values, lstNfo);
                        addCSV("Cast", imdbinfo.cast.Values, lstNfo);
                        addCSV("Genres", imdbinfo.genres, lstNfo);
                        addString("Duration", imdbinfo.duration, lstNfo);
                        addString("Plot", imdbinfo.plot, lstNfo);
                        addCSV("Languages", imdbinfo.language, lstNfo);
                        addCSV("Countries", imdbinfo.country, lstNfo);
                        addCSV("Aka", imdbinfo.aka, lstNfo);

                        // null reference exception
                        // addCSV("Writers", imdbinfo.writers.Values, lstNfo);

                        addString("Tagline", imdbinfo.tagline, lstNfo);
                        addString("Goofs", imdbinfo.goofs, lstNfo);
                        addString("Trivia", imdbinfo.trivia, lstNfo);
                        addCSV("Certification", imdbinfo.certification, lstNfo);
                    }

                    if ((originalfilename != null) && (originalfilename != filename))
                    {
                        lstNfo.Add("Original File: " + originalfilename);
                    }

                    if ((originalfolder != null) && (originalfolder != Path.GetDirectoryName(filename)))
                    {
                        lstNfo.Add("Original Folder: " + originalfolder);
                    }

                    lstNfo.Add("IMDB ID: " + subRes.IDMovieImdb);
                    lstNfo.Add("Hash: " + subRes.MovieHash);
                    lstNfo.Add("Release: " + subRes.MovieReleaseName);
                    lstNfo.Add("CD: " + subRes.SubActualCD + "/" + subRes.SubSumCD);
                    lstNfo.Add("Subtitle Used: " + subRes.ZipDownloadLink);
                    lstNfo.Add("Subtitle Hash: " + subRes.SubHash);
                    string nfoFileName = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + ".txt";

                    if (File.Exists(nfoFileName)) { File.Delete(nfoFileName); }
                    using (StreamWriter writer = File.AppendText(nfoFileName))
                    {
                        foreach (string line in lstNfo)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing NFO file: " + filename + " ERROR: " + ex.Message);
            }
        }

        private void addString(string Title, string Value, List<string> lstNfo)
        {
            if ((Value != null) && (Value != ""))
            {
                lstNfo.Add(Title + ": " + Value);
            }
        }

        private string addCSV(string title, System.Collections.ICollection array, List<string> lstNfo)
        {
            string s = "";
            if ((array != null) && (array.Count > 0))
            {
                foreach (string a in array)
                {
                    if (!string.IsNullOrEmpty(a))
                    {
                        s = s + ", " + a;
                    }
                }
                s = s.Substring(1);
                lstNfo.Add(title + ": " + s);
            }
            return s;
        }

        private string addCSV(string title, string[] array, List<string> lstNfo)
        {
            string s = "";
            if (array != null)
            {
                foreach (string a in array)
                {
                    s = s + "," + a;
                }
                s = s.Substring(1);
                lstNfo.Add(title + ": " + s);
            }
            return s;
        }
    }

    public interface IOSDb : IXmlRpcProxy
    {
        [XmlRpcMethod("ServerInfo")]
        XmlRpcStruct ServerInfo();

        [XmlRpcMethod("LogIn")]
        XmlRpcStruct LogIn(string username, string password, string language, string useragent);

        [XmlRpcMethod("LogOut")]
        XmlRpcStruct LogOut(string token);

        [XmlRpcMethod("SearchSubtitles")]
        subrt SearchSubtitles(string token, subInfo[] subs);

        [XmlRpcMethod("DownloadSubtitles")]
        subdata DownloadSubtitles(string token, string[] subs);

        [XmlRpcMethod("GetIMDBMovieDetails")]
        imdbheader GetIMDBMovieDetails(string token, string imdbid);
    }

    public class langMap
    {
        public string two { get; set; }
        public string three { get; set; }
        public string desc { get; set; }

        public langMap(string ttwo, string tthree, string tdesc)
        {
            two = ttwo;
            three = tthree;
            desc = tdesc;
        }
    }
}
