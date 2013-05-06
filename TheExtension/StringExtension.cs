using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;


namespace TheExtension
{
    public static class StringExtension
    {
        public static DateTime ToDate(this String x)
        {
            DateTime result = default(DateTime);
            if (!DateTime.TryParse(x, out result))
            {
                throw new Exception(string.Format("fail to parse '{0}' to DateTime type", x));
            }

            return result;
        }

        public static FileInfo ToFileInfo(this String x, bool createIfNotExist = false)
        {
            Uri filePath;
            try
            {
                filePath = new Uri(x);

            }
            catch (UriFormatException ex)
            {
                throw ex;
            }

            var info = new FileInfo(filePath.AbsolutePath);
            if (info.Exists)
            {
                return info;
            }
            else
            {
                if (createIfNotExist)
                {
                    using (var newFile = info.Create())
                    {

                    }
                    return info;
                }
            }

            return null;
        }

        public static DirectoryInfo ToDirectoryInfo(this string x, bool createIfNotExist = false)
        {
            Uri filePath;
            try
            {
                filePath = new Uri(x);

            }
            catch (UriFormatException ex)
            {
                throw ex;
            }

            var directoryInfo = new DirectoryInfo(filePath.AbsolutePath);

            if (directoryInfo.If<DirectoryInfo>(y => y.Exists))
            {
                return directoryInfo;
            }
            else
            {
                directoryInfo.IfThen<DirectoryInfo>(z => createIfNotExist, w => w.Create());
                return directoryInfo.If<DirectoryInfo>(y => y.Exists) ? directoryInfo : null;

            }
        }

        public static IEnumerable<String> ToIEnumerable(this String x, string seperator = " ", bool removeEmpty = true)
        {
            var splitOption = removeEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
            var strArray = x.Split(new string[] { seperator }, splitOption);
            if (!(strArray.Length > 0))
            {
                return null;
            }
            else
            {
                return strArray.ToList() as IEnumerable<String>;
            }
        }

        public static void Donwload(this String x, DirectoryInfo directory)
        {
            directory.IfThen<DirectoryInfo>(y => y == null, y => { throw new ArgumentException("Specified directory can't be found"); });

            Uri filePath;

            filePath = new Uri(x);

            filePath.IfThen<Uri>(z => !z.IsAbsoluteUri, z => { throw new ArgumentException("Given Uri is not valid"); });

            var fileExtension = filePath.AbsoluteUri.ToIEnumerable(".").Last();

            var textArray = "js,html,css,htm,xhtml,txt".ToIEnumerable(",").ToArray();

            var imgArray = "jpg,jpeg,png,gif,tiff".ToIEnumerable(",").ToArray();

            
            var fileName = filePath.AbsoluteUri.ToIEnumerable("/").Last();
            var fileInfo = (directory.FullName + @"\" + fileName).ToFileInfo(true);

            var request = (HttpWebRequest)WebRequest.Create(filePath);
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.13) Gecko/20101203 Firefox/3.6.13";
            var response = (HttpWebResponse)request.GetResponse();
            using (var responseStream = response.GetResponseStream())
            {
                var buffer = new byte[32 * 1024];
                var fs = fileInfo.OpenWrite();
                int offset = 0;
                int byteRead = 0;
                do
                {
                    byteRead = responseStream.Read(buffer, 0, buffer.Length);
                    fs.Write(buffer, 0, byteRead);
                    offset += byteRead;
                }
                while (byteRead > 0);
                fs.Flush();
                fs.Close();
            }
            
        }


    }
}
