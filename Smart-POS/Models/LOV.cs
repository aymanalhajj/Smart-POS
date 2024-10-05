namespace Smart_POS.Models
{
    public class LOV
    {
        public List<Item>? Items { get; set; }
    }
    public class Item
    {
        public string? name { get; set; }
        public int id { get; set; }
    }
}
