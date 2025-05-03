using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_POS.Models
{
    public class SalesProductFilesListItemModel
    {
        [JsonProperty("file_id")]
        public object FileId { get; set; }

        [JsonProperty("file_path")]
        public string FilePath { get; set; }

        [JsonProperty("file_mime_type")]
        public string FileMimeType { get; set; }

        [JsonProperty("file_size")]
        public string FileSize { get; set; }

        [JsonProperty("is_thumbnail")]
        public object IsThumbnail { get; set; }

        [JsonProperty("product_id")]
        public object ProductId { get; set; }
    }
}
