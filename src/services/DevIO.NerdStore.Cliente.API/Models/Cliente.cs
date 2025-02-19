﻿using DevIO.NerdStore.Core.DomainObjects;

namespace DevIO.NerdStore.Clientes.API.Models;

public class Cliente : Entity, IAggregateRoot
{
    public string? Nome { get; private set; }
    public Email? Email { get; private set; }
    public Cpf? Cpf { get; private set; }
    public bool Excluido { get; private set; }
    public Endereco? Endereco { get; private set; }

    protected Cliente() { }

    public Cliente(Guid id, string? nome, string? email, string? cpf)
    {
        Id = id;
        Nome = nome;
        Email = new(email);
        Cpf = new(cpf);
        Excluido = false;
    }

    public void TrocarEmail(string email) => Email = new(email);

    public void AtribuirEndereco(Endereco endereco) => Endereco = endereco;
}