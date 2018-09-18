using Ecommerce.DAL;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ecommerce.Controllers
{
    [RoutePrefix("api/Produto")]

    public class ProdutoAPIController : ApiController
    {

        //get: api/Produto/Produtos
        [Route("Produtos")]
        public List<Produto> GetProdutos()
        {
            return ProdutoDAO.RetornarProdutos();
        }


        //Get: api/Produto/ProdutosCategoria
        [Route("ProdutosCategoria/{categoriaId}")] 
        public List<Produto> GetProdutosCategoria(int categoriaId)
        {
            return ProdutoDAO.BuscarPorCategoria(categoriaId);
        }

        //Get: api/Produto/ProdutoPorId/5
        [Route("ProdutoPorId/{produtoId}")]
        public dynamic GetProdutoPorId(int produtoId)
        {
            Produto produto = ProdutoDAO.BuscarProduto(produtoId);
            List<Categoria> categorias = CategoriaDAO.RetornarCategorias();
            if(produto != null)
            {
                dynamic produtoDinamico = new {
                    Nome = produto.Nome,
                    Preco = produto.Preco.ToString("C2"),
                    Categoria = categorias,
                    DataEnvio = DateTime.Now
                };
                return new { Produto = produtoDinamico };
            }
            return NotFound();
        }

        [Route("CadastrarProduto")]
        public IHttpActionResult PostCadastrarProduto(Produto produto){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ProdutoDAO.CadastrarProduto(produto))
            {
                return Created("", produto);
            }
            else
            {
                return Conflict();
            }
        }

    }
}
