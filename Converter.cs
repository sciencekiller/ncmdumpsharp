using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace NCMConverter
{
    public static class Converter
    {
        public static async Task GetDllFile()
        {
            if(File.Exists(Path.Combine(Environment.CurrentDirectory, "taurusxin.libncmdump.dll")))
            {
                File.Delete(Path.Combine(Environment.CurrentDirectory, "taurusxin.libncmdump.dll"));
            }
            var url = "https://ghproxy.sciencekill.top/github.com/sciencekiller/ncmdumpsharp/releases/download/dll/taurusxin.libncmdump.dll";
            var path = Path.Combine(Environment.CurrentDirectory, "taurusxin.libncmdump.dll");
            var http = new HttpClient();
            var request=new HttpRequestMessage(HttpMethod.Get, url);
            var response = await http.SendAsync(request);
            using (var fs = File.Open(path, FileMode.Create)) 
            {
                using (var ms = response.Content.ReadAsStream())
                {
                    await ms.CopyToAsync(fs);
                }
            }
            return;
        }
        public static int Convert(string filepath,string outputpath="default")
        {
            if(!File.Exists(Path.Combine(Environment.CurrentDirectory, "taurusxin.libncmdump.dll")))
            {
                return -1;
            }
            NeteaseCrypt neteaseCrypt = new NeteaseCrypt(filepath);
            int result = neteaseCrypt.Dump();
            neteaseCrypt.FixMetadata();
            neteaseCrypt.Destroy();
            if(outputpath!="default")
            {
                string fileSuffix;
                if (File.Exists(filepath.Replace("ncm", "flac"))){
                    fileSuffix = "flac";
                }
                else
                {
                    fileSuffix = "mp3";
                }
                string sourceFileName = filepath.Replace("ncm", fileSuffix);
                string fileName=Path.GetFileName(sourceFileName);
                string destFileName=Path.Combine(outputpath, fileName);
                File.Move(sourceFileName, destFileName, true);
            }
            return result;
        }
        public static int ConvertDir(string filepath,string outputpath="default")
        {
            string[] files = Directory.GetFiles(filepath, "*.ncm");
            int result = 0;
            foreach(string file in files)
            {
                int tp=Convert(file, outputpath);
                if (tp == 0) result++;
            }
            return result;
        }
    }
}
