using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quanlythietbi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace quanlythietbi.Data.Configurations
{
    public class DonViConfiguration : IEntityTypeConfiguration<DonVi>
    {
        public void Configure(EntityTypeBuilder<DonVi> builder)
        {
            builder.ToTable("DonVis");
            builder.HasKey(x => x.DonViId);
            builder.Property(x => x.DonViId).UseIdentityColumn();
            builder.Property(x => x.DonViName).IsRequired().HasMaxLength(100).IsUnicode();
        }
    }
}
