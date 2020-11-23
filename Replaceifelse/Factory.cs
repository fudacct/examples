using System;
using System.Collections.Generic;
using System.Text;

namespace Replaceifelse
{
    public class Factory
    {
        private const string LOCAL = "local";
        private const string FTP = "ftp";
        private const string FASTDFS = "fastdfs";
        private const string HDFS = "hdfs";

        public static IStorageType storageTypeCreater(String storageType) {
            IStorageType istorageType = null;
            switch (storageType) {
                case LOCAL:
                    istorageType = new LocalStorageType();
                    break;
                case FTP:
                    istorageType = new FtpStorageType();
                    break;
                case FASTDFS:
                    istorageType = new FastDfsStorageType();
                    break;
                case HDFS:
                    istorageType = new HdfsStorageType();
                    break;
            }
            return istorageType;

        }

    }
}
