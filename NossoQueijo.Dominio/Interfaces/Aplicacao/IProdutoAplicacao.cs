﻿using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IProdutoAplicacao
    {
        public NotificationResult Salvar(Produto entidade);
        public IEnumerable<Produto> ListarTodos();
        public Produto BuscarPorId(int id);
        public NotificationResult RemoverPersonalizado(int id);
    }
}
