using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_Domain
{
    public class Language
    {
        public Guid LanguageID { get; set; }
        public string Name { get; set; }
        public Language() {
            this.LanguageID = Guid.NewGuid();
        }
        public Language(string name) 
        { 
            this.Name = name;
            this.LanguageID = Guid.NewGuid();
        }
    }
}
