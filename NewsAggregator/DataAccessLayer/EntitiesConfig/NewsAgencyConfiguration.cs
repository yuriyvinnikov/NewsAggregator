using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntitiesConfig;

public class NewsAgencyConfiguration : IEntityTypeConfiguration<NewsAgencyRssFeed>
{
    public void Configure(EntityTypeBuilder<NewsAgencyRssFeed> builder)
    {
        builder.Property(x => x.Name).IsRequired();

        builder
            .HasOne(x => x.JobSettings)
            .WithOne(x => x.NewsAgencyRssFeed)
            .HasForeignKey<JobSettings>(x => x.NewsAgencyRssFeedId);

        builder
            .HasOne(x => x.NewsStorageMetaData)
            .WithOne(x => x.NewsAgencyRssFeed)
            .HasForeignKey<NewsStorageMetaData>(x => x.NewsAgencyRssFeedId);
    }
}
