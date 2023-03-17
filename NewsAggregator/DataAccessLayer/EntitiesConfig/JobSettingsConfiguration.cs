using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntitiesConfig;

public class JobSettingsConfiguration : IEntityTypeConfiguration<JobSettings>
{
    public void Configure(EntityTypeBuilder<JobSettings> builder)
    {
        builder.Property(x => x.NewsAgencyRssFeed).IsRequired();
        builder.Property(x => x.RssFeedUrl).IsRequired();
        builder.Property(x => x.CronExpression).IsRequired();
        builder.Property(x => x.CronExpression).IsRequired();
        builder.Property(x => x.StartAutomatically).HasDefaultValue(true);


        builder
            .HasOne(x => x.NewsAgencyRssFeed)
            .WithOne(x => x.JobSettings)
            .HasForeignKey<NewsAgencyRssFeed>(x => x.JobSettingsId);
    }
}
