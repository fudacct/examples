using System;
using System.Collections.Generic;
using System.Text;

namespace Replaceifelse
{
    public class HdfsStorageType : IStorageType
    {
        public void uploadFile(string file) {
            Console.WriteLine("文件"+file+"已上传到hdfs服务器");
        }
    }
}
