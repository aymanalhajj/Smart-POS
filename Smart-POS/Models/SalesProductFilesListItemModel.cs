using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SalesProductFilesListItemModel
    {
        public object FileId { get; set; }

        public string FilePath { get; set; }

        public string FileMimeType { get; set; }

        public string FileSize { get; set; }

        public object IsThumbnail { get; set; }

        public object ProductId { get; set; }
    }
}
