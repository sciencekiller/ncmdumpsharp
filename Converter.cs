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
        public static async Task RemoveLocalDLLFile()
        {
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, "taurusxin.libncmdump.dll")))
            {
                File.Delete(Path.Combine(Environment.CurrentDirectory, "taurusxin.libncmdump.dll"));
            }
        }
        public static async Task GetDllFile(bool overwrite)
        {
            if(overwrite) {
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "taurusxin.libncmdump.dll")))
                {
                    File.Delete(Path.Combine(Environment.CurrentDirectory, "taurusxin.libncmdump.dll"));
                }
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
        public static int Convert(string filepath,string outputpath="default",bool overwrite=false)
        {
            string destFileName;
            if(!File.Exists(Path.Combine(Environment.CurrentDirectory, "taurusxin.libncmdump.dll")))
            {
                return -1;
            }
            if (File.Exists(filepath.Replace("ncm", "flac")))
            {
                File.Delete(filepath.Replace("ncm", "flac"));
            }
            if (File.Exists(filepath.Replace("ncm", "mp3")))
            {
                File.Delete(filepath.Replace("ncm", "mp3"));
            }
            if(outputpath!="default")
            {
                if (File.Exists(Path.Combine(outputpath, Path.GetFileName(filepath.Replace("ncm", "flac")))))
                {
                    File.Delete(Path.Combine(outputpath, Path.GetFileName(filepath.Replace("ncm", "flac"))));
                }
                if (File.Exists(Path.Combine(outputpath, Path.GetFileName(filepath.Replace("ncm", "mp3")))))
                {
                    File.Delete(Path.Combine(outputpath, Path.GetFileName(filepath.Replace("ncm", "mp3"))));
                }
            }


            Console.WriteLine("[Job] Converting file: "+filepath);
            NeteaseCrypt neteaseCrypt = new NeteaseCrypt(filepath);
            int result = neteaseCrypt.Dump();
            neteaseCrypt.FixMetadata();
            neteaseCrypt.Destroy();
            if(outputpath!="default")
            {
                Directory.CreateDirectory(outputpath);
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
                destFileName=Path.Combine(outputpath, fileName);
                File.Move(sourceFileName, destFileName, true);
            }
            else
            {
                string fileSuffix;
                if (File.Exists(filepath.Replace("ncm", "flac")))
                {
                    fileSuffix = "flac";
                }
                else
                {
                    fileSuffix = "mp3";
                }
                string sourceFileName = filepath.Replace("ncm", fileSuffix);
                destFileName = sourceFileName;
            }
            Console.WriteLine("[Complete] Converted file: " + destFileName);
            return result;
        }
        public static int ConvertDir(string filepath,string outputpath="default",bool scanalldir=false,bool overwrite=false)
        {
            string[] files = scanalldir ? Directory.GetFiles(filepath, "*.ncm",SearchOption.AllDirectories) : Directory.GetFiles(filepath, "*.ncm");
            int result = 0;
            foreach(string file in files)
            {
                int tp=Convert(file, outputpath,overwrite);
                if (tp == 0) result++;
            }
            return result;
        }
    }
}
