using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NCMConverter
{
    public class NeteaseCrypt
    {
        const string DLL_PATH = "taurusxin.LibNcmDump.dll";
        [DllImport(DLL_PATH)]
        private static extern IntPtr CreateNeteaseCrypt(string path);

        [DllImport(DLL_PATH)]
        private static extern int Dump(IntPtr NeteaseCrypt);

        [DllImport(DLL_PATH)]
        private static extern void FixMetadata(IntPtr NeteaseCrypt);

        [DllImport(DLL_PATH)]
        private static extern void DestroyNeteaseCrypt(IntPtr NeteaseCrypt);

        private IntPtr NeteaseCryptClass = IntPtr.Zero;

        /// <summary>
        /// 创建 NeteaseCrypt 类的实例。
        /// </summary>
        /// <param name="FileName">网易云音乐 ncm 加密文件路径</param>
        public NeteaseCrypt(string FileName)
        {
            NeteaseCryptClass = CreateNeteaseCrypt(FileName);
        }

        /// <summary>
        /// 启动转换过程。
        /// </summary>
        /// <returns>返回一个整数，指示转储过程的结果。如果成功，返回0；如果失败，返回1。</returns>
        public int Dump()
        {
            return Dump(NeteaseCryptClass);
        }

        /// <summary>
        /// 修复音乐文件元数据。
        /// </summary>
        public void FixMetadata()
        {
            FixMetadata(NeteaseCryptClass);
        }
    }
}
