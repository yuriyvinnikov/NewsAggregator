using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntitiesConfig
{
    public class NewsStorageMetaDataConfiguration : IEntityTypeConfiguration<NewsStorageMetaData>
    {
        public void Configure(EntityTypeBuilder<NewsStorageMetaData> builder)
        {
            builder.Property(x => x.TableName).IsRequired();

            builder
                .HasOne(x => x.NewsAgencyRssFeed)
                .WithOne(x => x.NewsStorageMetaData)
                .HasForeignKey<NewsAgencyRssFeed>(x => x.NewsStorageMetaDataId);
        }
    }
}
