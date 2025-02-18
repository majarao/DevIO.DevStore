﻿using DevIO.NerdStore.Pedidos.Domain.Pedidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.NerdStore.Pedidos.Infra.Data.Mappings;

public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
{
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.ProdutoNome)
            .IsRequired()
            .HasColumnType("varchar(250)");

        builder
            .HasOne(c => c.Pedido)
            .WithMany(c => c.PedidoItems);

        builder.ToTable("PedidoItems");
    }
}
