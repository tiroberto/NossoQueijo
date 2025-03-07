﻿using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace NossoQueijo.Aplicacao
{
    public class FichaProducaoAplicacao : IFichaProducaoAplicacao
    {
        private readonly IFichaProducaoRepositorio _fichaProducaoRepositorio;

        public FichaProducaoAplicacao(IFichaProducaoRepositorio fichaProducaoRepositorio)
        {
            _fichaProducaoRepositorio = fichaProducaoRepositorio;
        }

        public NotificationResult Salvar(FichaProducao entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idFichaProducao == 0)
                    {
                        entidade.EstoquePorData.Quantidade = entidade.QntdProduzida;
                        entidade.idFichaProducao = _fichaProducaoRepositorio.AdicionarPersonalizado(entidade);
                        notificationResult.Add("Ficha de produção cadastrada com sucesso.");
                        if(entidade.idFichaProducao > 0)
                        {
                            notificationResult.Result = entidade;
                            return notificationResult;
                        }
                    }
                    else
                    {
                        _fichaProducaoRepositorio.AtualizarPersonalizado(entidade);
                        notificationResult.Add("Ficha de produção atualizada com sucesso.");
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

        public IEnumerable<FichaProducao> ListarTodos()
        {
            return _fichaProducaoRepositorio.ListarTodos();
        }

        public NotificationResult ListarPorIdUsuarioPaginado(int idUsuario, int pagina)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    
                    notificationResult.Result = _fichaProducaoRepositorio.ListarPorIdUsuarioPaginado(idUsuario, pagina);
                    notificationResult.Add("Encontrado com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult ListarPorPeriodoPaginado(DateTime inicio, DateTime fim, int pagina)
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
                        notificationResult.Result = _fichaProducaoRepositorio.ListarPorPeriodoPaginado(inicio, fim, pagina);
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

        public NotificationResult BuscarPorId(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _fichaProducaoRepositorio.BuscarPorId(id);
                    notificationResult.Add("Encontrado com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult Remover(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    _fichaProducaoRepositorio.RemoverPersonalizado(id);
                    notificationResult.Result = true;
                    notificationResult.Add("Removido com sucesso");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                notificationResult.Result = false;
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }
    }
}
