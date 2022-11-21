﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceManagement.Domain.Balances.Entities;
using PersonalFinanceManagement.Domain.Balances.Enums;

namespace PersonalFinanceManagement.Infra.Data.Mappings
{
    internal class InstallmentMapping : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> builder)
        {
            builder.ToTable("Installments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnOrder(1);

            builder.Property(p => p.BalanceId)
                .HasColumnOrder(2);

            builder.Property(p => p.Reference)
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(p => p.Number)
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnOrder(5)
                .HasDefaultValue(InstallmentStatusEnum.Created)
                .IsRequired();

            builder.Property(p => p.Value)
                .HasColumnOrder(6)
                .IsRequired();

            builder.Property(p => p.AmountPaid)
                .HasColumnOrder(7)
                .IsRequired();

            builder.Property(p => p.DeletedAt)
                .HasColumnOrder(8)
                .IsRequired(false);

            builder.HasOne(p => p.Balance)
                .WithMany(o => o.Installments)
                .HasForeignKey(p => p.BalanceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(p => p.Errors);
        }
    }
}
