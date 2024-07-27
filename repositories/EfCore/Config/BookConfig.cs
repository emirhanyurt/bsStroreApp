


using entites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace webApi.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(

                new Book { Id = 1, CategoryId=1, Title = "Hacivat Karagöz", Price = 65 },
                new Book { Id = 2, CategoryId = 2, Title = "Dede Korkut", Price = 105 },
                new Book { Id = 3, CategoryId = 1, Title = "Mesnevi", Price = 65 }


                );
        }
    }
}
