﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntitiesConfig
{
    public class JobSettingsConfiguration : IEntityTypeConfiguration<JobSettings>
    {
        public void Configure(EntityTypeBuilder<JobSettings> builder)
        {
            builder.Property(x => x.NewsAgency).IsRequired();
            builder.Property(x => x.RssFeedUrl).IsRequired();
            builder.Property(x => x.CronExpression).IsRequired();
            builder.Property(x => x.CronExpression).IsRequired();
            builder.Property(x => x.StartAutomatically).HasDefaultValue(true);
        }
    }
}
