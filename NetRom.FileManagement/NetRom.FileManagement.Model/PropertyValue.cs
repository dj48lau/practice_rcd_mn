using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRom.FileManagement.Model
{
    public class PropertyValue
    {
        public int PropertyValueId { get; set; }
        public string Value { get; set; }
        public int PropertyId { get; set; }
        public int FileId { get; set; }
    }
}
