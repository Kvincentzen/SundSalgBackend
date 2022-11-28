using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SundSalgBackend.Models.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
                (
                    new Product
                    {
                        Id = 1,
                        Name = "Protein Pulver",
                        Desc = "Med banan og chokolade smag",
                        Picture = "",
                        Price = 125,
                        PriceId = "price_1M97kuJYRgEBAqqdoaKBOfkY"
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Kreatin Pulver",
                        Desc = "Brug max 5g om dagen",
                        Picture = "",
                        Price = 119.95,
                        PriceId = ""
                    }
                );
        }
    }
}
