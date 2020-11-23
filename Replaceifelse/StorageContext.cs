using System;
using System.Collections.Generic;
using System.Text;

namespace Replaceifelse
{
    public class StorageContext
    {
        private StorageStrategy storageStrategy;
        public StorageContext(StorageStrategy storageStrategy) {
            this.storageStrategy = storageStrategy;
        }
        public void uploadFileAction(string file) {
            storageStrategy.uploadFile(file);
        }
    }
}
