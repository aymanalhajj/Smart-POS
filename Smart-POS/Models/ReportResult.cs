using System.Collections.Generic;

namespace Smart_POS.Models
{
    public class ReportResult<T>
    {
        public List<T>? Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
