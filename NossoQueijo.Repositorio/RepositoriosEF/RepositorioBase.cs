﻿using NossoQueijo.Dominio.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected Contexto Contexto { get; }
        private DbSet<T> Entidade { get; }

        public RepositorioBase()
        {
            Contexto = new Contexto();
            Entidade = Contexto.Set<T>();
        }

        public T Adicionar(T entidade, bool saveChanges = true)
        {
            Entidade.Add(entidade);
            if (saveChanges)
                SaveChanges();

            return entidade;
        }

        public void Atualizar(T entidade, bool saveChanges = true)
        {
            Entidade.Update(entidade);
            if (saveChanges)
                SaveChanges();
        }

        public bool Remover(T entidade, bool saveChanges = true)
        {
            Entidade.Remove(entidade);
            if (saveChanges)
            {
                SaveChanges();
                return true;
            }
            else
                return false;
        }

        public void SaveChanges()
        {
            Contexto.SaveChanges();
        }
    }
}
