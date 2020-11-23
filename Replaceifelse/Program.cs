using System;

namespace Replaceifelse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            FileClient fileClient = new FileClient();
            Console.WriteLine("卫语句输出");
            //if else 
            fileClient.uploadFile("hdfs", "ifelse.txt");
            //with out if else
            fileClient.uploadFileWithoutElse("hdfs", "ifelse.txt");

            Console.WriteLine("工厂模式输出");
            //factory build object工厂模式
            IStorageType storageType = Factory.storageTypeCreater("hdfs");
            storageType.uploadFile("simpleFactory.txt");
            storageType = Factory.storageTypeCreater("fastdfs");
            storageType.uploadFile("simpleFactory.txt");
            storageType = Factory.storageTypeCreater("ftp");
            storageType.uploadFile("simpleFactory.txt");
            storageType = Factory.storageTypeCreater("local");
            storageType.uploadFile("simpleFactory.txt");

            Console.WriteLine("策略模式输出");
            //策略模式
            StorageContext storageContext = new StorageContext(new LocalStorageStrategy());
            storageContext.uploadFileAction("策略模式");
            storageContext = new StorageContext(new FtpStorageStrategy());
            storageContext.uploadFileAction("策略模式");
            storageContext = new StorageContext(new FastDfsStorageStrategy());
            storageContext.uploadFileAction("策略模式");
            storageContext = new StorageContext(new HdfsStorageStrategy());
            storageContext.uploadFileAction("策略模式");

        }



    }

    /// <summary>
    /// if else 版本
    /// </summary>
    public class FileClient
    {
        private static string LOCAL = "local";
        private static string FTP = "ftp";
        private static string FASTDFS = "fastdfs";
        private static string HDFS = "hdfs";
        //if else 上传文件
        public void uploadFile(string storageType, string file)
        {
            if (storageType.Equals(LOCAL))
            {
                Console.WriteLine("文件" + file + "已上传到 本地服务器");
            }
            else if (storageType.Equals(FTP))
            {
                Console.WriteLine("文件" + file + "已上传到 ftp服务器");
            }
            else if (storageType.Equals(FASTDFS))
            {
                Console.WriteLine("文件" + file + "已上传到 fastdfs服务器");
            }
            else if (storageType.Equals(HDFS))
            {
                Console.WriteLine("文件" + file + "已上传到 hdfs服务器");
            }
            else
            {
                Console.WriteLine("输入的文件类型错误");
            }
        }
        // with out if else
        public void uploadFileWithoutElse(string storageType, string file)
        {
            if (storageType.Equals(LOCAL))
            {
                Console.WriteLine("文件" + file + "已上传到 本地服务器");
                return;
            }
            if (storageType.Equals(FTP))
            {
                Console.WriteLine("文件" + file + "已上传到 ftp服务器");
                return;
            }
            if (storageType.Equals(FASTDFS))
            {
                Console.WriteLine("文件" + file + "已上传到 fastdfs服务器");
                return;
            }
            if (storageType.Equals(HDFS))
            {
                Console.WriteLine("文件" + file + "已上传到 hdfs服务器");
                return;
            }
            Console.WriteLine("输入的文件类型错误");
        }

    }


}
