using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.Property(x => x.Title)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
            builder.Property(x => x.Type)
            .HasColumnType("SMALLINT");
            builder.Property(x => x.Amount);
            builder.Property(x => x.CreateAt);
            builder.Property(x => x.PaidOrReceivedAt);
            builder.Property(x => x.UserId);
            

        }
    }
}
