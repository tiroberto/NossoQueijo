﻿using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface ITipoUsuarioAplicacao
    {
        public NotificationResult Salvar(TipoUsuario entidade);
        public IEnumerable<TipoUsuario> ListarTodos();
        public TipoUsuario BuscarPorId(int id);
        public NotificationResult RemoverPersonalizado(int id);
    }
}
