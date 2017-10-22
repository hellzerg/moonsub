using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace MoonSub
{
    public static class Utilities
    {
        public static string GetOS()
        {
            return (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName", "");
        }

        public static string GetBitness()
        {
            string bitness = "";

            if (Environment.Is64BitOperatingSystem == true)
            {
                bitness = "You are working with 64-bit architecture";
            }
            else
            {
                bitness = "You are working with 32-bit architecture";
            }

            return bitness;
        }
        
        public static byte[] ComputeMovieHash(string filename)
        {
            byte[] result;
            using (Stream input = File.OpenRead(filename))
            {
                result = ComputeMovieHash(input);
            }
            return result;
        }

        public static byte[] ComputeMovieHash(Stream input)
        {
            long lhash, streamsize;
            streamsize = input.Length;
            lhash = streamsize;

            long i = 0;
            byte[] buffer = new byte[sizeof(long)];
            while (i < 65536 / sizeof(long) && (input.Read(buffer, 0, sizeof(long)) > 0))
            {
                i++;
                lhash += BitConverter.ToInt64(buffer, 0);
            }

            input.Position = Math.Max(0, streamsize - 65536);
            i = 0;
            while (i < 65536 / sizeof(long) && (input.Read(buffer, 0, sizeof(long)) > 0))
            {
                i++;
                lhash += BitConverter.ToInt64(buffer, 0);
            }
            input.Close();
            byte[] result = BitConverter.GetBytes(lhash);
            Array.Reverse(result);
            return result;
        }

        public static string ToHexadecimal(byte[] bytes)
        {
            StringBuilder hexBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                hexBuilder.Append(bytes[i].ToString("x2"));
            }
            return hexBuilder.ToString();
        }

        public static string[] GetFilesByExtensions(string path, string extensions, SearchOption option)
        {
            List<string> result = new List<string>();
            InternalGetFiles(path, option, extensions.Split(';'), result);
            return result.ToArray();
        }

        private static void InternalGetFiles(string path, SearchOption option, string[] extensions, List<string> result)
        {
            // Get the files.
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                // Get the extension of the file.
                string ext = Path.GetExtension(file);
                // Validate the extension against the searched extensions.
                foreach (string p in extensions)
                {
                    if (ext == p)
                    {
                        result.Add(file);
                        break;
                    }
                }
            }

            // Returns if only top directory is requested.
            if (option == SearchOption.TopDirectoryOnly)
                return;
            // Get all other directories.
            foreach (string directory in Directory.GetDirectories(path))
            {
                InternalGetFiles(directory, option, extensions, result);
            }
        }

        public static byte[] Decode(string str)
        {
            byte[] decbuff = Convert.FromBase64String(str);
            return decbuff;
        }

        public static byte[] DecodeAndDecompress(string str)
        {
            return Decompress(Decode(str));
        }

        static public byte[] Decompress(byte[] b)
        {
            MemoryStream ms = new MemoryStream(b.Length);
            ms.Write(b, 0, b.Length);
            // last 4 bytes of GZipStream = length of decompressed data
            ms.Seek(-4, SeekOrigin.Current);
            byte[] lb = new byte[4];
            ms.Read(lb, 0, 4);
            int len = BitConverter.ToInt32(lb, 0);
            ms.Seek(0, SeekOrigin.Begin);
            byte[] ob = new byte[len];
            GZipStream zs = new GZipStream(ms, CompressionMode.Decompress);
            zs.Read(ob, 0, len);
            return ob;
        }

        public static List<langMap> generateLangMap()
        {
            List<langMap> theLangMap = new List<langMap>();
            theLangMap.Add(new langMap("cs", "cze,ces", "Czech"));
            theLangMap.Add(new langMap("fi", "fin", "Finnish"));
            theLangMap.Add(new langMap("tr", "tur", "Turkish"));
            theLangMap.Add(new langMap("sv", "swe", "Swedish"));
            theLangMap.Add(new langMap("sk", "slo,slk", "Slovak"));
            theLangMap.Add(new langMap("bg", "bul", "Bulgarian"));
            theLangMap.Add(new langMap("fr", "fre,fra", "French"));
            theLangMap.Add(new langMap("ar", "ara", "Arabic"));
            theLangMap.Add(new langMap("vi", "vie", "Vietnamese"));
            theLangMap.Add(new langMap("sr", "scc,srp", "Serbian"));
            theLangMap.Add(new langMap("mk", "mac,mkd", "FYROM"));
            theLangMap.Add(new langMap("ko", "kor", "Korean"));
            theLangMap.Add(new langMap("et", "est", "Estonian"));
            theLangMap.Add(new langMap("zh", "chi,zho", "Chinese"));
            theLangMap.Add(new langMap("hr", "scr,hrv", "Croatian"));
            theLangMap.Add(new langMap("gl", "glg", "Galician"));
            theLangMap.Add(new langMap("ja", "jpn", "Japanese"));
            theLangMap.Add(new langMap("el,gr", "gre,ell", "Greek"));
            theLangMap.Add(new langMap("en", "eng", "English"));
            theLangMap.Add(new langMap("da", "dan", "Danish"));
            theLangMap.Add(new langMap("de", "ger,deu", "German"));
            theLangMap.Add(new langMap("he", "heb", "Hebrew"));
            theLangMap.Add(new langMap("id", "ind", "Indonesian"));
            theLangMap.Add(new langMap("it", "ita", "Italian"));
            theLangMap.Add(new langMap("es", "spa", "Spanish"));
            theLangMap.Add(new langMap("no", "nor", "Norwegian"));
            theLangMap.Add(new langMap("nl", "dut,nld", "Dutch"));
            theLangMap.Add(new langMap("pl", "pol", "Polish"));
            theLangMap.Add(new langMap("fa", "per,fas", "Persian"));
            theLangMap.Add(new langMap("hu", "hun", "Hungarian"));
            theLangMap.Add(new langMap("pt", "por", "Portuguese"));
            theLangMap.Add(new langMap("ro", "rum,ron", "Romanian"));
            theLangMap.Add(new langMap("ru", "rus", "Russian"));
            return theLangMap;
        }

        public static string parseLangCodeFromFile(string filename, List<langMap> langs)
        {
            string name = Path.GetFileNameWithoutExtension(filename);
            string[] nameSplit = name.Split('.');
            string langCode = nameSplit[nameSplit.Length - 1];
            foreach (langMap l in langs)
            {
                if (l.two.Contains(langCode))
                {
                    return langCode;
                }
            }
            return "";
        }

        public static string FilenameFromTitle(string name)
        {
            // first trim the raw string
            string safe = name.Trim();

            // trim out illegal characters
            safe = Regex.Replace(safe, "[^a-zA-Z0-9\\- ]", "");

            return safe;
        }
    }
}
