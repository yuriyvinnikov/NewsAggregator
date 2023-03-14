using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntitiesConfig;

public class NewsAgencyConfiguration : IEntityTypeConfiguration<NewsAgency>
{
    public void Configure(EntityTypeBuilder<NewsAgency> builder)
    {
        builder.Property(x => x.Name).IsRequired();

        builder
            .HasOne(x => x.JobSettings)
            .WithOne(x => x.NewsAgency)
            .HasForeignKey<JobSettings>(x => x.NewsAgencyId);
    }
}
