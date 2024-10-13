namespace Smart_POS.Models
{
    
    internal class StockListModel
    {
        public List<StockListItemModel> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<LinkModel> links { get; set; }
    }
}
