namespace SundSalgBackend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? PriceId { get; set; }
        public string? Desc { get; set; }
        public string? Picture { get; set; }
    }
}
