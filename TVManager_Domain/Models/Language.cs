using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_Domain
{
    public class Language
    {
        public Guid LanguageID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Language() { }
    }
}
