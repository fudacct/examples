using System;
using System.Collections.Generic;
using System.Text;

namespace Replaceifelse
{
    public class FtpStorageStrategy : StorageStrategy
    {
        public override void uploadFile(string file)
        {
            Console.WriteLine("文件{0}已上传到{1}服务器", file, "ftp");
        }
    }
}
