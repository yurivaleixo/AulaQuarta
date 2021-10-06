using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;


namespace API.Controllers
{
    [ApiController]
    [Route("api/Categoria")]
    public class CategoriaController: ControllerBase
    {

        private readonly DataContext _context;
        public CategoriaController( DataContext context ){
            
            _context = context;

        }

        //POST:  /api/Categoria/create
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Categoria categoria){

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return Created(" ", categoria);
            
        }

         //GET: /api/categoria/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Categorias.ToList());
        
    }
}