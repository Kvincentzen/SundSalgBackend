using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SundSalgBackend.Models.Configuration
{
    public class CounselorConfiguration : IEntityTypeConfiguration<Counselor>
    {
        public void Configure(EntityTypeBuilder<Counselor> builder)
        {
            builder.HasData(
                new Counselor
                {
                    Id = 1,
                    Name = "Mads Madsen",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                    Picture = "",
                    Price = 299.99
                },
                new Counselor
                {
                    Id = 2,
                    Name = "Hanne Hansen",
                    Desc = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                    Picture = "",
                    Price = 420.00
                }
            );
        }
    }
}
