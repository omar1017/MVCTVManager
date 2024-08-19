using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_Domain
{
    public class TVShow
    {
        public Guid TVShowID {  get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string ReleaseDate {  get; set; }
        public decimal Rating {  get; set; }
        public string URL {  get; set; }
        public Language Language { get; set; }
        public Guid LanguageID { get; set; }
        public Attachment Attachment { get; set; }
        public Guid AttachmentID { get; set; }
        public TVShow() { }
    }
}
