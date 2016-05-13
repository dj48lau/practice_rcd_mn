using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class File
    {
        public int FileId { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public DateTime CreationDate { get; set; }
        public int FileTypeId { get; set; }
        public string Owner { get; set; }
        public virtual FileType FileType { get; set; }
    }
}
