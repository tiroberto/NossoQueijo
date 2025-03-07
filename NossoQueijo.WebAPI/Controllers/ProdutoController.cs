﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Aplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NossoQueijo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAplicacao appProduto;

        public ProdutoController(IProdutoAplicacao ProdutoAplicacao)
        {
            appProduto = ProdutoAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<Produto> ListarTodos() => appProduto.ListarTodos();

        [HttpGet("listar-paginado")]
        public dynamic ListarTodos(int pagina) => appProduto.ListarTodosPaginado(pagina);

        [HttpGet("buscar-um")]
        public NotificationResult BuscarPorId(int id) => appProduto.BuscarPorId(id);

        [HttpPost("salvar")]
        public NotificationResult Salvar(Produto Produto) => appProduto.Salvar(Produto);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appProduto.Remover(id);
    }
}
