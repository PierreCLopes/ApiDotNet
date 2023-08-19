using ApiDotNet.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace ApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> _produtos = new List<Produto>();

        [HttpPost]
        public ActionResult<Produto> PostProduto(ProdutoPost prProduto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            var vProduto = new Produto(_produtos.Count + 1,
                                       prProduto.Nome,
                                       prProduto.Valor);
            _produtos.Add(vProduto);

            return new ObjectResult(vProduto)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetProduto(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            var vProduto = _produtos.FirstOrDefault(p => p.Id == id);

            if (vProduto == null)
            {
                return NotFound();
            }

            return Ok(vProduto);
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetProdutos() 
        { 
            return _produtos; 
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> DeleteProduto(int id) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            var vProduto = _produtos.FirstOrDefault(p => p.Id == id);

            if (vProduto == null)
            {
                return NotFound();
            }

            _produtos.Remove(vProduto);

            return Ok(vProduto);
        }

        [HttpPatch("{id}")]
        public ActionResult<Produto> PatchProduto(int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            var vProduto = _produtos.FirstOrDefault(p => p.Id == id);

            if (vProduto == null)
            {
                return NotFound();
            }

            //-- Como vProduto aponta pro local da memoria que esta armazenado na lista, funciona assim
            vProduto.Nome = produto.Nome;
            vProduto.Valor = produto.Valor;

            return Ok(vProduto);
        }
    }
}