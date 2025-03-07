﻿using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace NossoQueijo.Aplicacao
{
    public class EstoquePorDataAplicacao : IEstoquePorDataAplicacao
    {
        private readonly IEstoquePorDataRepositorio _estoquePorDataRepositorio;

        public EstoquePorDataAplicacao(IEstoquePorDataRepositorio estoquePorDataRepositorio)
        {
            _estoquePorDataRepositorio = estoquePorDataRepositorio;
        }

        public NotificationResult Adicionar(EstoquePorData entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if ((entidade.idFichaProducao > 0) && (entidade.Produto.idProduto > 0))
                    {
                        _estoquePorDataRepositorio.Adicionar(entidade);
                        notificationResult.Add("Estoque por data cadastrada com sucesso.");
                    }
                }
                notificationResult.Result = entidade;
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }
        public NotificationResult Atualizar(EstoquePorData entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if ((entidade.idFichaProducao > 0) && (entidade.Produto.idProduto > 0))
                    {
                        _estoquePorDataRepositorio.Atualizar(entidade);
                        notificationResult.Add("Estoque por data atualizado com sucesso.");
                    }
                }
                notificationResult.Result = entidade;
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<EstoquePorData> ListarTodos()
        {
            return _estoquePorDataRepositorio.ListarTodos();
        }

        public NotificationResult BuscarPorIdFichaProducao(int idFichaProducao)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _estoquePorDataRepositorio.BuscarPorIdFichaProducao(idFichaProducao);
                    notificationResult.Add("Encontrado com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if ((inicio != null) 
                        && (fim != null) 
                        && (inicio < fim) 
                        && (inicio < DateTime.Now))
                    {
                        notificationResult.Result = _estoquePorDataRepositorio.ListarPorPeriodo(inicio, fim);
                        notificationResult.Add("Lista gerada com sucesso.");
                    }

                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult ListaPorIdProduto(int idProduto)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _estoquePorDataRepositorio.ListarPorIdProduto(idProduto);
                    notificationResult.Add("Encontrados com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult RemoverPorIdFichaProducao(int idFichaProducao)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    _estoquePorDataRepositorio.RemoverPorIdFichaProducao(idFichaProducao);
                    notificationResult.Add("Removido com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult Remover(EstoquePorData estoquePorData)
        {
            var notificationResult = new NotificationResult();            
            try
            {
                if (notificationResult.IsValid)
                {
                    _estoquePorDataRepositorio.Remover(estoquePorData);
                    notificationResult.Add("Removido com sucesso");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }
    }
}
