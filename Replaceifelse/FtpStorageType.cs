using System;
using System.Collections.Generic;
using System.Text;

namespace Replaceifelse
{
    class FtpStorageType : IStorageType
    {
        public void uploadFile(string file)
        {
            Console.WriteLine("文件" + file + "已上传到ftp服务器");
        }
    }
}
