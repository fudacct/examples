using System;
using System.Collections.Generic;
using System.Text;

namespace Replaceifelse
{
    public class LocalStorageStrategy : StorageStrategy
    {
        public override void uploadFile(string file)
        {
            Console.WriteLine("文件{0}已上传到{1}服务器", file, ";local");
        }
    }
}
