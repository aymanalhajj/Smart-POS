namespace Smart_POS.Models
{
    internal class InvoiceListModel
    {
        public List<InvoiceListItemModel> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<LinkModel> links { get; set; }
    }

    public class LinkModel
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

}
