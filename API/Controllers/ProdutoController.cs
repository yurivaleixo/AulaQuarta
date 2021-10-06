using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
 
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        
        private readonly DataContext _context;
        public ProdutoController( DataContext context ){
            
           
            _context = context;

        }
        //POST:  /api/produto/create
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Produto produto){

            produto.Categoria = _context.Categorias.Find(produto.CategoriaId);
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created(" ", produto);
            
        }

        //GET: /api/produto/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => 
        Ok(_context.Produtos
        .Include(produto => produto.Categoria.CriadoEm)
        .ToList());

        //GET: api/produto/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id){

            //Buscar um objeto pela chave primária
            Produto produto = _context.Produtos.Find(id);
            if(produto == null){

                return NotFound(); 
            }
            return Ok(produto);

        }

        //GET: api/produto/delete/Bolacha
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete(string name){

            //Where
            //Buscar um objeto pelo nome 
            //.Include(produto => produto.Categoria)
            //Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Nome = name);
            //Produto produto = _context.Produtos
            //.FirstOrDefault(produto => produto.CategoriaId = 3);
            Produto produto = _context.Produtos.FirstOrDefault(produto => produto.Nome == name);
            if(produto == null){

                return NotFound(); 
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(_context.Produtos.ToList());

        }
    }
}