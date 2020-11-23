using System;
using System.Collections.Generic;
using System.Text;

namespace Replaceifelse
{
    class FastDfsStorageType : IStorageType
    {
        public void uploadFile(string file)
        {
            Console.WriteLine("文件" + file + "已上传到fastdfs服务器");
        }
    }
}
