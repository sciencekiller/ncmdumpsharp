using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCMConverter
{
    public static class Converter
    {
        public static async Task GetDllFile()
        {

        }
        public static int Convert(string filepath,string outputpath="default")
        {
            NeteaseCrypt neteaseCrypt = new NeteaseCrypt(filepath);
            int result = neteaseCrypt.Dump();
            neteaseCrypt.FixMetadata();
            
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
    }
}
