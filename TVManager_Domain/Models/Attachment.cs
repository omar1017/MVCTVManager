using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_Domain
{
    public class Attachment
    {
        public Guid AttachmentID { get; set; }
        public string Path {  get; set; }
        public string Name { get; set; }
        public string FileType {  get; set; }
        public Attachment() 
        {
            this.AttachmentID = Guid.NewGuid();
        }
    }
}
