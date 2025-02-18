﻿using DevIO.NerdStore.Core.Data;

namespace DevIO.NerdStore.Pedido.Domain.Pedidos;

public interface IPedidoRepository : IRepository<Pedido>
{
    Task<Pedido?> ObterPorId(Guid id);

    Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId);

    void Adicionar(Pedido pedido);

    void Atualizar(Pedido pedido);

    Task<PedidoItem?> ObterItemPorId(Guid id);

    Task<PedidoItem?> ObterItemPorPedido(Guid pedidoId, Guid produtoId);
}
